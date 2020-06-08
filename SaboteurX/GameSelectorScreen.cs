using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using QuickType;
using SaboteurX.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaboteurX
{
    public partial class GameSelectorScreen : Form
    {
        #region Hacks
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Card_moveForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region Variables
        public PlayerInformation information;
        List<KeyValuePair<string, LobbyModel>> lobbies = new List<KeyValuePair<string, LobbyModel>>();
        int lobbyNumber = 0;
        Label selectedLabel;
        #endregion

        async void GetLobbies()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://corupta-ddd6d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = await client.GetAsync("lobbies");
            var temporaryList = response.ResultAs<Dictionary<string, LobbyModel>>().ToList();
            lobbies = new List<KeyValuePair<string,LobbyModel>>();
            temporaryList.ForEach((kvp) => { if(kvp.Value.Active)lobbies.Add(kvp); });
            var IsInGame = FindIfInGame();
            if (IsInGame.Value!=null)
            {
                this.Hide();
                var frm = new LobbyWaitingRoom(IsInGame,information);
                try
                {
                    frm.ShowDialog();
                }
                catch { }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var itemsMarkedForRemove = new List<KeyValuePair<string, LobbyModel>>();
                lobbies.ForEach((lobby) => {
                    if (lobby.Value.Started)
                        itemsMarkedForRemove.Add(lobby);
                });
                itemsMarkedForRemove.ForEach((lb) => lobbies.Remove(lb));
                lobbies.RemoveAt(0);
                LoadLobby();
            }
        }
        KeyValuePair<string, LobbyModel> FindIfInGame()
        {
            KeyValuePair<string, LobbyModel> response = new KeyValuePair<string, LobbyModel>();
            lobbies.ForEach((lobby) => 
            lobby.Value.Players.ForEach((player) => { if (new PlayerInformation(player).name == information.name) response = lobby; }));
            return response;
        }
        void LoadLobby()
        {
            try
            {
                this.bunifuCards1.Controls.OfType<LobbyItem>().ToList().ForEach((itemremove) => this.bunifuCards1.Controls.Remove(itemremove));
                LobbyItem item = new LobbyItem(lobbies[lobbyNumber], this);
                item.Location = new Point(this.Width / 2 - item.Width / 2+10, this.Height / 2 - item.Height / 2-40);
                this.bunifuCards1.Controls.Add(item);
            }
            catch { }
            CheckLabelsViz();
        }
        public GameSelectorScreen(PlayerInformation information)
        {
            this.information = information;
            
            InitializeComponent();
            
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            GetLobbies();
            this.lbl_create_lobby.Text = lbl_create_lobby.Tag.ToString().Split(';')[0].ToAsciiArt();
        }

        private void GameSelectorScreen_Load(object sender, EventArgs e)
        {
            
        }



        private void Lbl_close_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Lbl_maximize_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            this.WindowState = FormWindowState.Maximized;
            LoadLobby();
        }

        private void Lbl_minimize_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            this.WindowState = FormWindowState.Minimized;
        }

        private void Lbl_right_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            if (lobbies.Count>lobbyNumber+1)
            {
                lobbyNumber++;
            }
            LoadLobby();
        }

        private void Lbl_left_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            if (0 <= lobbyNumber - 1)
            {
                lobbyNumber--;
            }
            LoadLobby();
        }
        private void CheckLabelsViz()
        {
            if (lobbies.Count <= lobbyNumber + 1)
            {
                lbl_right.Hide();
            }
            else
            {
                lbl_right.Show();
            }
            if (lobbyNumber == 0)
            {
                lbl_left.Hide();
            }
            else
            {
                lbl_left.Show();
            }
        }
        public LobbyModel FromInfoToLobby(PlayerInformation info)
        {
            var model = new LobbyModel
            {
                Players = new List<string>() { info.ToCompressedString() },
                Moves = new List<MoveModel>(),
                Messages = new List<string>() { $"{info.name} created the lobby." },
                Started = false,
                Active = true,
                Host = info.name
            };
            return model;
        }
        async void MakeNewLobby()
        {
            try
            {
                IFirebaseConfig config = new FirebaseConfig
                {
                    BasePath = "https://corupta-ddd6d.firebaseio.com/"
                };
                IFirebaseClient client = new FirebaseClient(config);
                var model = FromInfoToLobby(information);
                PushResponse response = await client.PushAsync("lobbies", model);
                FirebaseResponse response2 = await client.GetAsync("lobbies");
                var temporaryList = response2.ResultAs<Dictionary<string, LobbyModel>>().ToList();
                lobbies = new List<KeyValuePair<string, LobbyModel>>();
                temporaryList.ForEach((kvp) => lobbies.Add(kvp));
                var lobby = FindIfInGame();
                var waitingRoom = new LobbyWaitingRoom(lobby, information);
                this.Hide();
                if (waitingRoom.ShowDialog() == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                }
                this.Close();
            }
            catch
            {
                lbl_create_lobby.Enabled = true;
            }

        }
        private void Lbl_create_lobby_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            lbl_create_lobby.Enabled = false;
            MakeNewLobby();
        }

        private void Timer_animation_Tick(object sender, EventArgs e)
        {
            if(selectedLabel!=null)
            {
                if(selectedLabel.Tag.ToString().Split(';')[1]=="NO")
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

        private void Lbl_create_lobby_MouseLeave(object sender, EventArgs e)
        {
            selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";NO";
            selectedLabel.Text = (selectedLabel.Tag.ToString().Split(';')[0]).ToAsciiArt(); 
            selectedLabel = null;
        }

        private void Lbl_create_lobby_MouseEnter(object sender, EventArgs e)
        {
            selectedLabel = (Label)sender;
            selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";YES";
            selectedLabel.Text = ("-" + selectedLabel.Tag.ToString().Split(';')[0] + "-").ToAsciiArt();
        }
    }
}
