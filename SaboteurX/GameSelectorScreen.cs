using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using QuickType;
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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public PlayerInformation information;
        List<KeyValuePair<string, LobbyModel>> lobbies = new List<KeyValuePair<string, LobbyModel>>();
        int lobbyNumber = 0;
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
            temporaryList.ForEach((kvp) => lobbies.Add(kvp));
            var IsInGame = FindIfInGame();
            if (IsInGame.Value!=null)
            {
                this.Hide();
                var frm = new LobbyWaitingRoom(IsInGame,information);
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                loadLobby();
            }
        }
        KeyValuePair<string, LobbyModel> FindIfInGame()
        {
            KeyValuePair<string, LobbyModel> response = new KeyValuePair<string, LobbyModel>();
            lobbies.ForEach((lobby) => 
            lobby.Value.Players.ForEach((player) => { if (new PlayerInformation(player).name == information.name) response = lobby; }));
            return response;
        }
        void loadLobby()
        {
            this.bunifuCards1.Controls.OfType<LobbyItem>().ToList().ForEach((itemremove) => this.bunifuCards1.Controls.Remove(itemremove));
            LobbyItem item = new LobbyItem(lobbies[lobbyNumber], this);
            item.Location = new Point(210, 200);
            this.bunifuCards1.Controls.Add(item);
        }
        public GameSelectorScreen(PlayerInformation information)
        {
            this.information = information;
            
            InitializeComponent();
            
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            GetLobbies();
        }

        private void GameSelectorScreen_Load(object sender, EventArgs e)
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

        private void lbl_maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void lbl_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbl_join_Click(object sender, EventArgs e)
        {
            if(lobbies.Count>lobbyNumber+1)
            {
                lobbyNumber++;
            }
            loadLobby();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (0 <= lobbyNumber - 1)
            {
                lobbyNumber--;
            }
            loadLobby();
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
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://corupta-ddd6d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            var model = FromInfoToLobby(information);
            PushResponse response = await client.PushAsync("lobbies", model);
            this.Hide();
            FirebaseResponse response2 = await client.GetAsync("lobbies");
            var temporaryList = response2.ResultAs<Dictionary<string, LobbyModel>>().ToList();
            lobbies = new List<KeyValuePair<string, LobbyModel>>();
            temporaryList.ForEach((kvp) => lobbies.Add(kvp));
            var lobby = FindIfInGame();
            var waitingRoom = new LobbyWaitingRoom(lobby,information);
            waitingRoom.ShowDialog();
            this.Close();

        }
        private void lbl_create_lobby_Click(object sender, EventArgs e)
        {
            MakeNewLobby();
        }
    }
}
