using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using QuickType;
using SaboteurX.Game;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
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
        LobbyModel game;
        string id;
        PlayerInformation me;
        Image gameImage;
        Board board;
        int myId;
        int selectedCard = -1;
        int[] rotations = new int[5] { 0, 0, 0, 0, 0 };
        bool loading = false;
        #endregion

        #region Constructor and on load
        public GameScreen(string id,LobbyModel game, PlayerInformation me)
        {
            InitializeComponent();
            Board.ends = new List<Point>() { new Point(game.width - 5, game.height / 2), new Point(game.width - 5, game.height / 2 - game.height / 4), new Point(game.width - 5, game.height / 2 + game.height / 4) };
            Board.Width = game.width;
            Board.Height = game.height;
            Board.startX = game.startingPoint.X;
            Board.startY = game.startingPoint.Y;
            board = new Board();

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
            gameImage = board.image;

        }
        #endregion

        #region Loading lobby and processing
        void LoadLobby()
        {
            if (!game.Active)
            {
                return;
            }
            ProcessMoves();
            board.CheckIfDone();
            ProcessMessages();
            ProcessAvatars();
            ProcessCards();
            ProcessRoles();
            ProcessInformation();
            board.SetEndPoint(game.indexOfTarget);
            gameImage = board.image;
            pbox_game.Invalidate();

            bool finished = false;
            var endAction = new Action(() =>
            {
                game.Active = false;
                UpdateLobby();
                switch(game.roles[myId])
                {
                    case 0:
                        DialogScreen dialogMiner;
                        if (game.remainingCards <= 0)
                        {
                            dialogMiner = new DialogScreen("fuck", "fuck", "You like lost");
                        }
                        else
                        {
                            dialogMiner = new DialogScreen("Yay", "Yay", "You like won");
                        }
                        dialogMiner.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case 1:
                        DialogScreen dialogSaboteur;
                        if (game.remainingCards > 0)
                        {
                            dialogSaboteur = new DialogScreen("fuck", "fuck", "You like lost");
                        }
                        else
                        {
                            dialogSaboteur = new DialogScreen("Yay", "Yay", "You like won");
                        }
                        dialogSaboteur.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case 2:
                        DialogScreen dialogArheolog;
                        if (board.diamonds >= game.diamondsNeeded)
                        {
                            dialogArheolog = new DialogScreen("Yay", "Yay", $"You like Won");
                        }
                        else
                        {
                            dialogArheolog = new DialogScreen("fuck", "fuck", "You like lost");
                        }
                        dialogArheolog.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                }
                if (game.roles[myId] == 0)
                {


                }
                else if (game.roles[myId] == 1)
                {
                    if (game.remainingCards > 0)
                    {
                        DialogScreen dialog = new DialogScreen("fuck", "fuck", "You like lost");
                        dialog.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        DialogScreen dialog = new DialogScreen("Yay", "Yay", "You like won");
                        dialog.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                
            });
            var thread = new Thread(
              () =>
              {
                  finished = board.CheckIfDone();
                  if(finished||game.remainingCards<=0)
                    endAction();
              });
            thread.Start();

        }

        private void ProcessInformation()
        {

            lbl_player.Text = (game.Players[game.currentPlayer].Split(';')[0] + "'s turn");
            if(game.currentPlayer == myId)
            {
                lbl_player.ForeColor = Color.LightGreen;
            }
            else
            {
                lbl_player.ForeColor = Color.Chartreuse;
            }
            lbl_cardsLeft.Text = $"Cards left: {game.remainingCards}";
            lbl_discardsLeft.Text = $"Discards left: {game.discardsLeft}";
        }
        private void ProcessMoves()
        {
            game.Moves.ForEach((move) =>
            {
                if (move.destination.Split(';')[0] == "1")
                {
                    this.board.ChangeAt(move.card, int.Parse(move.destination.Split(';')[1]), int.Parse(move.destination.Split(';')[2]));
                }
                else if (move.destination.Split(';')[0] == "2")
                {
                    this.game.effects[move.destination.Split(';')[1]] = move.card.power;
                }
            }); 
            board.SetEndPoint(game.indexOfTarget);
        }
        private void ProcessRoles()
        {
            List<string> rolesToStrings = new List<string>() { "Miner", "Saboteur", "Arheologist" };
            List<Color> rolesToColor = new List<Color>() { Color.Chartreuse, Color.IndianRed, Color.Blue };
            this.lbl_role.ForeColor = rolesToColor[game.roles[myId]];
            this.lbl_role.Text = rolesToStrings[game.roles[myId]];
        }
        private void ProcessMessages()
        {
            txt_chat_screen.Text = "";
            game.Messages.ForEach((message) => this.txt_chat_screen.Text += $"{message}\n");
            txt_chat_screen.SelectionStart = txt_chat_screen.Text.Length;
            txt_chat_screen.ScrollToCaret();
        }
        private void ProcessCards()
        {
            var pictureCards = new PictureBox[] { pbox_card_1, pbox_card_2, pbox_card_3, pbox_card_4, pbox_card_5 };

            for (int i = 0; i < 5; i++)
            {
                Bitmap temp = game.cards[myId][i].image;
                switch (rotations[i])
                {
                    case 1:
                        temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 2:
                        temp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 3:
                        temp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
                pictureCards[i].Image = temp;
            }
            if(game.currentPlayer==myId)
            {
                lbl_endRound.Show();
            }
            else
            {
                lbl_endRound.Hide();
            }
        }
        private void ProcessAvatars()
        {
            var pictureBoxes = new PictureBox[] { pbox_avatar_1, pbox_avatar_2, pbox_avatar_3, pbox_avatar_4, pbox_avatar_5, pbox_avatar_6, pbox_avatar_7, pbox_avatar_8 }; ;
            for (int i = 0; i < game.Players.Count; i++)
            {
                var playerBmp = new PlayerInformation(game.Players[i]).GetPictureBitmap(pictureBoxes[i].Width, pictureBoxes[i].Height);
                if (game.effects[game.Players[i].Split(';')[0]] == CardHelpers.PowerUp.NoBuild)
                {
                    Graphics g = Graphics.FromImage(playerBmp);
                    g.DrawLine(new Pen(Color.Red, 10), 0, 0, playerBmp.Width, playerBmp.Height);
                }
                pictureBoxes[i].Image = playerBmp;
            }
        }
        #endregion

        #region Close max and min buttons
        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lbl_maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            imageZoom = 5;
            pbox_game.Invalidate();
        }

        private void lbl_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Check if we are out of date and timer
        private async void UpdateData()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://corupta-ddd6d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            var ngame = JsonConvert.DeserializeObject<LobbyModel>((await client.GetAsync($"lobbies/{id}")).Body);
            if((game.Messages.Count!=ngame.Messages.Count|| game.Moves.Count!=ngame.Moves.Count||game.currentPlayer!=ngame.currentPlayer) && !loading)
            {
                game = ngame;
                LoadLobby();
                gameImage = board.image;
                pbox_game.Update();
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }
        #endregion


        private void Lbl_send_message_Click(object sender, EventArgs e)
        {
            game.Messages.Add($"{me.name}: {txt_message.Text}");
            txt_message.Text = "";
            UpdateLobby();
            ProcessMessages();
        }

        private async void UpdateLobby()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://corupta-ddd6d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            loading = true;
            await client.UpdateAsync($"lobbies/{id}", game);
            loading = false;
            LoadLobby();
        }
        private void Txt_message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Lbl_send_message_Click(null, null);
            }
            else if(e.KeyData == Keys.Delete)
            {
                this.GameScreen_KeyUp(null, e);
            }
        }

        #region Main picturebox moving logic
        private Point startingPoint = Point.Empty;
        private Point movingPoint = Point.Empty;
        private bool panning = false;

        void Pbox_game_MouseDown(object sender, MouseEventArgs e)
        {
            panning = true;
            startingPoint = new Point(e.Location.X - movingPoint.X,
                                      e.Location.Y - movingPoint.Y);
        }

        void Pbox_game_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
        }

        void Pbox_game_MouseMove(object sender, MouseEventArgs e)
        {
            HandleOnMouseOverCoordinateLabel();
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
        float imageZoom = 2f;
        void Pbox_game_Paint(object sender, PaintEventArgs e)
        {
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
        #endregion


        private void pbox_game_Click(object sender, EventArgs e)
        {
            float px = ((MouseEventArgs)e).X;
            float py = ((MouseEventArgs)e).Y;
            int x = (int)((float)(px - movingPoint.X) / ((float)Board.WidthCell * imageZoom));
            int y = (int)((float)(py - movingPoint.Y) / ((float)Board.HeightCell * imageZoom));
            if (game.currentPlayer == myId 
                && game.discardsLeft==3
                && selectedCard != -1)
            {
                if (this.game.cards[myId][selectedCard].type == CardHelpers.CardType.Path)
                {
                    for (int i = 0; i < rotations[selectedCard]; i++)
                        game.cards[myId][selectedCard].Rotate();

                    if (game.effects[me.name] == CardHelpers.PowerUp.Build
                    && board.IsCompatible(this.game.cards[myId][selectedCard], x, y))
                    {
                        board.ChangeAt(this.game.cards[myId][selectedCard], x, y);
                        gameImage = board.image;
                        pbox_game.Invalidate();
                        game.Moves.Add(new MoveModel(this.game.cards[myId][selectedCard], $"1;{x};{y}"));
                        game.Messages.Add($"{me.name} Added path at x:{x}, y:{y}.");
                        UpdateCardsAfterUse();
                        UpdateLobby();
                    }
                }
                else if (this.game.cards[myId][selectedCard].type == CardHelpers.CardType.PathX)
                {
                    if (board.isObjective(x, y) == false)
                    {
                        board.ChangeAt(new Card(), x, y);
                        gameImage = board.image;
                        pbox_game.Invalidate();
                        game.Moves.Add(new MoveModel(new Card(), $"1;{x};{y}"));
                        game.Messages.Add($"{me.name} Removed path at x:{x}, y:{y}.");
                        UpdateCardsAfterUse();
                        UpdateLobby();
                    }
                }

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

        private void card_Click(object sender, EventArgs e)
        {
            var pictureCards = new PictureBox[] { pbox_card_1, pbox_card_2, pbox_card_3, pbox_card_4, pbox_card_5 };
            var pbox = ((PictureBox)sender);
            if (selectedCard!=-1)
            {
                pictureCards[selectedCard].BorderStyle = BorderStyle.None;
            }
            selectedCard = int.Parse(pbox.Tag.ToString());
            pictureCards[selectedCard].BorderStyle = BorderStyle.Fixed3D;

            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                rotations[selectedCard]= (rotations[selectedCard]+1)% 4;
                Bitmap temp = game.cards[myId][selectedCard].image;
                switch (rotations[selectedCard])
                {
                    case 1:
                        temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 2:
                        temp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 3:
                        temp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
                pbox.Image = temp;
                pbox.Invalidate();
                pbox.Update();
            }
            Card card = (Card)game.cards[myId][selectedCard].Clone();
            for (int i = 0; i < rotations[selectedCard]; i++) card.Rotate();

            board.selectedCard = card;
            gameImage = board.image;
            pbox_game.Invalidate();
        }

        private void pbox_avatar_Click(object sender, EventArgs e)
        {
            if(game.currentPlayer == myId && game.discardsLeft==3&& selectedCard != -1 && this.game.cards[myId][selectedCard].type == CardHelpers.CardType.Power)
            {
                int idPlayer = int.Parse(((PictureBox)sender).Tag.ToString());
                string playerName = game.Players[idPlayer].Split(';')[0];
                if (this.game.cards[myId][selectedCard].power == CardHelpers.PowerUp.Switch)
                {
                    Random rnd = new Random();
                    game.roles[idPlayer] = rnd.Next(0, 3);
                    game.Messages.Add($"{me.name} switched {playerName}'s role.");
                }
                else
                {
                    game.effects[playerName] = this.game.cards[myId][selectedCard].power;
                    game.Moves.Add(new MoveModel(this.game.cards[myId][selectedCard], "2;" + playerName));
                    game.Messages.Add($"{me.name} used a power card on {playerName}.");
                }
                game.currentPlayer = (this.game.currentPlayer + 1) % this.game.Players.Count;
                UpdateCardsAfterUse();
                ProcessAvatars();
                UpdateLobby();
            }
        }
        private void UpdateCardsAfterUse(bool changeRound = true)
        {
            board.selectedCard = null;
            gameImage = board.image;
            if (changeRound)
            {
                game.discardsLeft = 3;
                game.currentPlayer = (game.currentPlayer + 1) % this.game.Players.Count;
            }
            RemoveSelectedCard();

            if (selectedCard != -1)
            {
                var pictureCards = new PictureBox[] { pbox_card_1, pbox_card_2, pbox_card_3, pbox_card_4, pbox_card_5 };
                pictureCards[selectedCard].BorderStyle = BorderStyle.None;
                selectedCard = -1;
            }
        }
        private void RemoveSelectedCard()
        {
            game.cards[myId].RemoveAt(selectedCard);
            game.cards[myId].Insert(selectedCard, CardHelpers.RandomCardGenerator());
            rotations[selectedCard] = 0;
            game.remainingCards--;
            ProcessCards();
        }

        #region Coordinate label preview
        Label coordinateLabel;
        private void HandleOnMouseOverCoordinateLabel()
        {
            var pInitial = new Point(MousePosition.X, MousePosition.Y);
            var p = pbox_game.PointToClient(pInitial);
            int x = (int)((float)(p.X - movingPoint.X) / ((float)Board.WidthCell * imageZoom));
            int y = (int)((float)(p.Y - movingPoint.Y) / ((float)Board.HeightCell * imageZoom));
            if (coordinateLabel == null)
            {
                coordinateLabel = new Label
                {
                    ForeColor = Color.White,
                    Font = new Font("Consolas", 14f, FontStyle.Bold),
                };
                this.bunifuCards1.Controls.Add(coordinateLabel);
            }
            coordinateLabel.Text = $"x:{x},y:{y}";
            coordinateLabel.Location = this.PointToClient(pInitial);
            
            coordinateLabel.BringToFront();
        }

        private void pbox_game_MouseLeave(object sender, EventArgs e)
        {
            this.bunifuCards1.Controls.Remove(coordinateLabel);
            coordinateLabel = null;
        }
        #endregion


        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (game.currentPlayer == myId && e.KeyData == Keys.Delete && selectedCard != -1)
            {
                game.discardsLeft--;
                game.Messages.Add($"{me.name} discarded one of their cards.");
                if (game.discardsLeft > 0)
                {
                    UpdateCardsAfterUse(false);
                }
                else
                {
                    UpdateCardsAfterUse();
                }
                ProcessInformation();
                UpdateLobby();
            }
        }

        private void lbl_endRound_Click(object sender, EventArgs e)
        {
            if (game.currentPlayer == myId)
            {
                game.currentPlayer = (game.currentPlayer + 1) % this.game.Players.Count;
                game.discardsLeft = 3;
                UpdateLobby();
            }
        }
        Label nameHelperLabel = null;
        private void avatar_MouseEnter(object sender, EventArgs e)
        {
            int playerId = int.Parse(((PictureBox)sender).Tag.ToString());
            if (playerId >= game.Players.Count)
                return;
            if (nameHelperLabel == null)
            {
                nameHelperLabel = new Label()
                {
                    ForeColor = Color.White,
                    Font = new Font("Consolas", 15f, FontStyle.Regular),
                };
                this.bunifuCards1.Controls.Add(nameHelperLabel);
            }
            nameHelperLabel.Text = game.Players[playerId].Split(';')[0];
            nameHelperLabel.Location = ((PictureBox)sender).Location;
            nameHelperLabel.BringToFront();
        }

        private void avatar_MouseLeave(object sender, EventArgs e)
        {
            this.bunifuCards1.Controls.Remove(nameHelperLabel);
            nameHelperLabel = null;
        }
        Label selectedLabel = null;
        private void lbl_endRound_MouseEnter(object sender, EventArgs e)
        {
            this.selectedLabel = lbl_endRound;
            this.lbl_endRound.Text = "-End round-";
            //lbl_endRound.Font = new Font("Consolas", 19);

        }

        private void lbl_endRound_MouseLeave(object sender, EventArgs e)
        {
            this.selectedLabel = null;
            this.lbl_endRound.Text = "End round";
            //lbl_endRound.Font = new Font("Consolas",18);
        }

        private void timer_animation_Tick(object sender, EventArgs e)
        {
            if (selectedLabel != null)
            {
                if (selectedLabel.Tag.ToString().Split(';')[1] == "NO")
                {
                    selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";YES";
                    selectedLabel.Text = ("-" + selectedLabel.Tag.ToString().Split(';')[0] + "-");
                }
                else
                {
                    selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";NO";
                    selectedLabel.Text = (selectedLabel.Tag.ToString().Split(';')[0]);
                }
            }
        }
    }
}
