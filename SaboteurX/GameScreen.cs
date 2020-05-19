using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;
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
    public partial class GameScreen : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        LobbyModel game;
        string id;
        PlayerInformation me;
        public GameScreen(string id,LobbyModel game, PlayerInformation me)
        {
            InitializeComponent();
            this.game = game;
            this.id = id;
            this.me = me;
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            this.lbl_chat_title.Text = "Chat".ToAsciiArt();
            this.TransparencyKey = Color.LimeGreen;
            this.BackColor = Color.LimeGreen;
            LoadLobby();
        }

        void LoadLobby()
        {
            txt_chat_screen.Text = "";
            game.Messages.ForEach((message) => this.txt_chat_screen.Text += $"{message}\n");
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

        private async void UpdateData()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://corupta-ddd6d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            var ngame = JsonConvert.DeserializeObject<LobbyModel>((await client.GetAsync($"lobbies/{id}")).Body);
            if(ngame!=game)
            {
                game = ngame;
                LoadLobby();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void lbl_send_message_Click(object sender, EventArgs e)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://corupta-ddd6d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            game.Messages.Add($"{me.name}: {txt_message.Text}");
            txt_message.Text = "";
            client.Update($"lobbies/{id}", game);
            LoadLobby();
        }

        private void txt_message_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                lbl_send_message_Click(null, null);
            }
        }
    }
}
