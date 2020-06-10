using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using QuickType;
using SaboteurX.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinFormAnimation;

namespace SaboteurX
{
    public partial class LobbyWaitingRoom : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        readonly string id;
        public LobbyModel lobby;
        readonly PlayerInformation playerInfo;
        LobbySettingsModel settingsModel = new LobbySettingsModel();
        bool isHost = false;
        bool updateInformation = true;
        Label selectedLabel;
        public int miner = 3;
        public int saboteur = 3;
        public int archeolog = 2;
        public LobbyWaitingRoom(KeyValuePair<string,LobbyModel> lobby, PlayerInformation playerInfo)
        {
            
            InitializeComponent();
            id = lobby.Key;
            this.lobby = lobby.Value;
            this.playerInfo = playerInfo;
            LoadInformation();
        }

        void LoadInformation()
        {
            isHost = (playerInfo.name == lobby.Host);
            if (lobby.Started)
            {
                GameScreen game = new GameScreen(id,lobby,playerInfo);
                this.Hide();
                updateInformation = false;
                if(game.ShowDialog()==DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            else
            {
                var lbl_players = new List<Label>()
                { lbl_name_0, lbl_name_1, lbl_name_2, lbl_name_3, lbl_name_4, lbl_name_5, lbl_name_6, lbl_name_7 };
                var pbox_players = new List<PictureBox>()
                { pbox_player_0, pbox_player_1, pbox_player_2, pbox_player_3, pbox_player_4, pbox_player_5, pbox_player_6, pbox_player_7 };
                for (int i = 0; i < lbl_players.Count; i++)
                {
                    lbl_players[i].Tag = "Empty;NO";
                    lbl_players[i].Text = "Empty".ToAsciiArt();
                }
                for (int i = 0; i < lobby.Players.Count; i++)
                {
                    var player = new PlayerInformation(lobby.Players[i]);
                    lbl_players[i].Tag = $"{player.name};NO";
                    lbl_players[i].Text = player.name.ToAsciiArt();
                    pbox_players[i].Image = player.GetPictureBitmap(pbox_players[i].Width,pbox_players[i].Height);
                }
                this.BackColor = Color.LimeGreen;
                this.TransparencyKey = Color.LimeGreen;
                lbl_quit.Text = "Quit".ToAsciiArt();
                if (isHost)
                {
                    lbl_start.Show();
                    lbl_settings.Show();
                    lbl_start.Text = "Start".ToAsciiArt();
                    lbl_settings.Text = "Settings".ToAsciiArt();
                }
                else
                {
                    lbl_start.Hide();
                    lbl_settings.Hide();
                    lbl_start.Text = "";
                    lbl_settings.Text = "";
                }
            }

        }
        private void LobbyWaitingRoom_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            new Animator(new WinFormAnimation.Path(0, 1, 250, 100)).Play(this, Animator.KnownProperties.Opacity);
        }

        private void card_moveForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lbl_start_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            lbl_start.Enabled = false;
            StartGame();
        }

        private async void StartGame()
        {
            try
            {
                IFirebaseConfig config = new FirebaseConfig
                {
                    BasePath = "https://corupta-ddd6d.firebaseio.com/"
                };
                IFirebaseClient client = new FirebaseClient(config);
                lobby.Started = true;
                lobby.discardsLeft = 3;
                lobby.indexOfTarget = (new Random()).Next(0, 3);
                lobby.height = settingsModel.Height;
                lobby.width = settingsModel.Width;

                lobby.remainingCards = settingsModel.RemainingCards;
                lobby.startingPoint = settingsModel.StartingPoint;
                lobby.diamondsNeeded = settingsModel.DiamondsNeeded;

                this.lobby.Players.ForEach((player) =>
                {
                    Random rnd = new Random();
                    int newRole = CardHelpers.RandomRoleGenerator(ref miner, ref saboteur, ref archeolog);
                    lobby.roles.Add(newRole);
                    List<Card> paths = new List<Card>();
                    lobby.cards.Add(new List<Card>());
                    for (int i = 0; i < 5; i++)
                    {
                        lobby.cards.Last().Add(CardHelpers.RandomCardGenerator());
                    }
                    lobby.effects.Add(player.Split(';')[0], CardHelpers.PowerUp.Build);
                });
                await client.UpdateAsync($"lobbies/{id}", lobby);
            }
            catch
            {
                lbl_start.Enabled = true;
            }
        }
        private void lbl_quit_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            lbl_quit.Enabled = false;
            QuitLobby();
        }
        private async void QuitLobby()
        {
            try
            {
                IFirebaseConfig config = new FirebaseConfig
                {
                    BasePath = "https://corupta-ddd6d.firebaseio.com/"
                };
                IFirebaseClient client = new FirebaseClient(config);
                if (isHost)
                {
                    lobby.Active = false;
                    lobby.Players.Clear();
                }
                else
                {
                    lobby.Players.Remove(playerInfo.ToCompressedString());
                }
                await client.UpdateAsync($"lobbies/{id}", lobby);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                lbl_quit.Enabled = false;
            }
        }

        private void timer_update_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }
        private async void UpdateData()
        {
            if (updateInformation)
            {
                IFirebaseConfig config = new FirebaseConfig
                {
                    BasePath = "https://corupta-ddd6d.firebaseio.com/"
                };
                IFirebaseClient client = new FirebaseClient(config);
                var nlobby = JsonConvert.DeserializeObject<LobbyModel>((await client.GetAsync($"lobbies/{id}")).Body);
                if (nlobby != lobby)
                {
                    lobby = nlobby;
                    LoadInformation();
                }
            }
        }

        private void lbl_minimize_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            this.WindowState = FormWindowState.Minimized;

        }

        private void timer_animation_Tick(object sender, EventArgs e)
        {
            if (selectedLabel != null)
            {
                if (selectedLabel.Tag.ToString().Split(';')[1] == "NO")
                {
                    selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";YES";
                    selectedLabel.Text = ("-" + selectedLabel.Tag.ToString().Split(';')[0] + "-").ToAsciiArt();
                }
                else
                {
                    selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";NO";
                    selectedLabel.Text = (selectedLabel.Tag.ToString().Split(';')[0]).ToAsciiArt();
                }
            }
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {
            selectedLabel = (Label)sender;
            selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";YES";
            selectedLabel.Text = ("-" + selectedLabel.Tag.ToString().Split(';')[0] + "-").ToAsciiArt();
        }
        private void Label_MouseLeave(object sender, EventArgs e)
        {
            selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";NO";
            selectedLabel.Text = (selectedLabel.Tag.ToString().Split(';')[0]).ToAsciiArt();
            selectedLabel = null;
        }

        private void lbl_settings_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            LobbySettings dialog = new LobbySettings(ref settingsModel);
            this.Hide();
            dialog.ShowDialog();
            this.Show();
        }
        private void LabelZoomOut(object sender, EventArgs e)
        {
            ((Label)sender).Font = new Font(((Label)sender).Font.Name, ((Label)sender).Font.Size - 1);
        }
        private void LabelZoomIn(object sender, EventArgs e)
        {
            ((Label)sender).Font = new Font(((Label)sender).Font.Name, ((Label)sender).Font.Size + 1);
        }
    }


}
