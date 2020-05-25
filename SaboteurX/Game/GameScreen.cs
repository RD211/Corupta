using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
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
    public partial class GameScreen : Form
    {
        #region Hacks
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        #region Variables
        LobbyModel game;
        string id;
        PlayerInformation me;
        #endregion

        Image gameImage;
        Board board = new Board();
        int myId;
        int selectedCard = -1;
        public GameScreen(string id,LobbyModel game, PlayerInformation me)
        {
            InitializeComponent();
            this.game = game;
            this.id = id;
            this.me = me;
            for (int i = 0; i < this.game.Players.Count; i++)
            {
                if (this.game.Players[i].Split(';')[0] == me.name)
                {
                    myId = i;
                    break;
                }
            }
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            this.lbl_chat_title.Text = "Chat".ToAsciiArt();
            this.TransparencyKey = Color.LimeGreen;
            this.BackColor = Color.LimeGreen;
            LoadLobby();

            board.ChangeAt(new Card(new List<Tuple<CardHelpers.Gate, CardHelpers.Gate>>() { new Tuple<CardHelpers.Gate, CardHelpers.Gate>(CardHelpers.Gate.Up, CardHelpers.Gate.Down) }, 
                CardHelpers.Orientation.Angle0, 
                CardHelpers.Special.Diamond), 5, 5);
            gameImage = board.image;
            
        }
        void LoadLobby()
        {
            txt_chat_screen.Text = "";
            game.Messages.ForEach((message) => this.txt_chat_screen.Text += $"{message}\n");
            var pictureBoxes = new PictureBox[] { pbox_avatar_1, pbox_avatar_2, pbox_avatar_3, pbox_avatar_4, pbox_avatar_5, pbox_avatar_6, pbox_avatar_7, pbox_avatar_8 }; ;
            for(int i =  0;i<game.Players.Count;i++)
            {
                pictureBoxes[i].Image = new PlayerInformation(game.Players[i]).GetPictureBitmap(pictureBoxes[i].Width,pictureBoxes[i].Height);
            }
            var pictureCards = new PictureBox[] { pbox_card_1, pbox_card_2, pbox_card_3, pbox_card_4, pbox_card_5 };

            for(int i = 0;i<5;i++)
            {
                pictureCards[i].Image = this.game.cards[myId][i].image;
            }
            List<string> rolesToStrings = new List<string>() { "Miner", "Saboteur", "Arheologist" };
            this.lbl_role.Text = rolesToStrings[game.roles[myId]];
            this.lbl_player.Text = (game.Players[game.currentPlayer].Split(';')[0]+"s turn").ToAsciiArt();
            this.game.Moves.ForEach((move) => {
                if (move.destination.Split(';')[0] == "1")
                {
                    this.board.ChangeAt(move.card, int.Parse(move.destination.Split(';')[1]), int.Parse(move.destination.Split(';')[2]));
                }
            });
        }
        private void card_moveForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #region Close max and min buttons
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
        #endregion

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
            game.Messages.Add($"{me.name}: {txt_message.Text}");
            txt_message.Text = "";
            UpdateLobby();
            LoadLobby();
        }
        private void UpdateLobby()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://corupta-ddd6d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
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

        private Point startingPoint = Point.Empty;
        private Point movingPoint = Point.Empty;
        private bool panning = false;

        void pbox_game_MouseDown(object sender, MouseEventArgs e)
        {
            panning = true;
            startingPoint = new Point(e.Location.X - movingPoint.X,
                                      e.Location.Y - movingPoint.Y);
        }

        void pbox_game_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
        }

        void pbox_game_MouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                movingPoint = new Point(e.Location.X - startingPoint.X,
                                        e.Location.Y - startingPoint.Y);
                if (movingPoint.X > 0) movingPoint.X = 0;
                if (movingPoint.Y > 0) movingPoint.Y = 0;
                if (movingPoint.X + gameImage.Width * imageZoom < pbox_game.Width) movingPoint.X = (int)(pbox_game.Width-gameImage.Width*imageZoom);
                if (movingPoint.Y + gameImage.Height * imageZoom < pbox_game.Height) movingPoint.Y = (int)(pbox_game.Height - gameImage.Height * imageZoom);

                pbox_game.Invalidate();
            }
        }
        float imageZoom = 0.9f;
        void pbox_game_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Gray);
            e.Graphics.DrawImage(gameImage, movingPoint.X,movingPoint.Y, (gameImage.Width*imageZoom), (gameImage.Height * imageZoom));
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                float newZoom = imageZoom+(float)e.Delta / 9000;
                if (!(movingPoint.Y + gameImage.Height * newZoom < pbox_game.Height || 
                    movingPoint.X + gameImage.Width * newZoom < pbox_game.Width)) imageZoom = newZoom;
                pbox_game.Invalidate();
                pbox_game.Update();
            }
        }

        private void pbox_game_Click(object sender, EventArgs e)
        {
            if (game.currentPlayer == myId && selectedCard != -1)
            {
                float px = ((MouseEventArgs)e).X;
                float py = ((MouseEventArgs)e).Y;
                int x = (int)((float)(px - movingPoint.X) / ((float)Board.WidthCell * imageZoom));
                int y = (int)((float)(py - movingPoint.Y) / ((float)Board.HeightCell * imageZoom));
                //check if possible
                //TODO: ADD FINISH CHECKS TO BOARD AND CARD COMPATIBILITY ON PLACE
                board.ChangeAt(this.game.cards[myId][selectedCard], x, y);
                gameImage = board.image;
                pbox_game.Invalidate();
                game.Moves.Add(new MoveModel(this.game.cards[myId][selectedCard], $"1;{x};{y}"));
                this.game.currentPlayer = (this.game.currentPlayer + 1) % this.game.Players.Count;
                this.game.cards[myId].RemoveAt(selectedCard);
                this.game.cards[myId].Add(CardHelpers.RandomCardGenerator());
                this.game.remainingCards--;
                UpdateLobby();
            }

        }

        private void cardMouseEnter(object sender, EventArgs e)
        {
            var pbox = ((PictureBox)sender);
            pbox.Size = new Size(90,90);
            pbox.Location = new Point(pbox.Location.X - 5, pbox.Location.Y - 5);

        }

        private void cardMouseLeave(object sender, EventArgs e)
        {
            var pbox = ((PictureBox)sender);
            pbox.Size = new Size(80, 80);
            pbox.Location = new Point(pbox.Location.X + 5, pbox.Location.Y + 5);
        }

        private void lbl_role_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void card_Click(object sender, EventArgs e)
        {
            this.selectedCard = int.Parse(((PictureBox)sender).Tag.ToString());
        }
    }
}
