using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using QuickType;
using SaboteurX.Game;
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
    public partial class LobbyWaitingRoom : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        string id;
        LobbyModel lobby;
        PlayerInformation playerInfo;
        bool isHost = false;
        bool updateInformation = true;
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
                game.ShowDialog();
                this.Close();
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
                    lbl_start.Text = "Start".ToAsciiArt();
                else
                    lbl_start.Text = "";
            }

        }
        private void LobbyWaitingRoom_Load(object sender, EventArgs e)
        {

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
            this.Close();
        }

        private void lbl_start_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private async void StartGame()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://corupta-ddd6d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            lobby.Started = true;
            lobby.remainingCards = 100;
            this.lobby.Players.ForEach((player) => {
                Random rnd = new Random();
                lobby.roles.Add(rnd.Next(0, 2));
                List<Card> paths = new List<Card>();
                lobby.cards.Add(new List<Card>());
                for(int i = 0;i<5;i++)
                {
                    lobby.cards.Last().Add(CardHelpers.RandomCardGenerator()) ;
                }
            });
            await client.UpdateAsync($"lobbies/{id}", lobby);
        }
        private void lbl_quit_Click(object sender, EventArgs e)
        {
            QuitLobby();
        }
        private async void QuitLobby()
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
            this.Hide();
            await client.UpdateAsync($"lobbies/{id}", lobby);

            this.Close();
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
        private void bunifuCards2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void lbl_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
