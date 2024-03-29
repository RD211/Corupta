﻿using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using QuickType;
using SaboteurX.Game;
using SaboteurX.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormAnimation;

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
        readonly string id;
        readonly PlayerInformation me;
        Image gameImage;
        readonly Board board;
        readonly int myId;
        int selectedCard = -1;
        readonly int[] rotations = new int[5] { 0, 0, 0, 0, 0 };
        bool updating = false;
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
            this.ChangeFormColor();
            this.Opacity = 0;

            new Animator(new Path(0, 1, 250, 100)).Play(this, Animator.KnownProperties.Opacity);
            lbl_chat_title.Text = "Chat".ToAsciiArt();
            TransparencyKey = Color.LimeGreen;
            BackColor = Color.LimeGreen;
            LoadLobby();
            gameImage = board.Image;
        }
        #endregion

        #region Loading lobby and processing
        void LoadLobby()
        {
            if (loading) return;

            loading = true;
            ProcessMoves();
            board.CheckIfDone();
            ProcessMessages();
            ProcessAvatars();
            ProcessCards();
            ProcessRoles();
            ProcessDiamonds();
            ProcessInformation();
            board.SetEndPoint(game.indexOfTarget);
            gameImage = board.Image;
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
                        if (dialogMiner.ShowDialog()!=DialogResult.Cancel)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
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
                        if (dialogSaboteur.ShowDialog() != DialogResult.Cancel)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        break;
                    case 2:
                        DialogScreen dialogArheolog;
                        if (board.Diamonds >= game.diamondsNeeded)
                        {
                            dialogArheolog = new DialogScreen("Yay", "Yay", $"You like Won");
                        }
                        else
                        {
                            dialogArheolog = new DialogScreen("fuck", "fuck", "You like lost");
                        }
                        if (dialogArheolog.ShowDialog() != DialogResult.Cancel)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        break;
                }
                
            });
            var thread = new Thread(
              () =>
              {
                  finished = board.CheckIfDone();
                  if(finished||game.remainingCards<=0)
                    endAction();
                  loading = false;

              });
            thread.Start();
        }

        private void ProcessInformation()
        {
            lbl_player.Text = (game.Players[game.currentPlayer].Split(';')[0] + "'s turn");
            if(game.currentPlayer == myId)
            {
                var LighterColor = Color.FromArgb(
                    Math.Min(253,GlobalSettings.secondaryColor.R+10), 
                    Math.Min(253,GlobalSettings.secondaryColor.G+10),
                    Math.Min(254, GlobalSettings.secondaryColor.B + 10));
                lbl_player.ForeColor = LighterColor;
            }
            else
            {
                lbl_player.ForeColor = GlobalSettings.secondaryColor;
            }
            lbl_cardsLeft.Text = $"Cards left: {game.remainingCards}";
            lbl_discardsLeft.Text = $"Discards left: {game.discardsLeft}";
        }
        private void ProcessMoves()
        {
            board.ResetBoard();
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
                else if(move.destination.Split(';')[0]=="3")
                {
                    if(int.Parse(move.destination.Split(';')[3])==myId)
                    {
                        board.SetVisible(int.Parse(move.destination.Split(';')[1]), int.Parse(move.destination.Split(';')[2]));
                    }
                }
            }); 
            board.SetEndPoint(game.indexOfTarget);
        }
        private void ProcessRoles()
        {
            List<string> rolesToStrings = new List<string>() { "Miner", "Saboteur", "Archaeologist" };
            List<Color> rolesToColor = new List<Color>() { Color.Chartreuse, Color.IndianRed, Color.Blue };
            this.lbl_role.ForeColor = rolesToColor[game.roles[myId]];
            this.lbl_role.Text = rolesToStrings[game.roles[myId]];
        }
        private void ProcessMessages()
        {
            StringBuilder builder = new StringBuilder();
            game.Messages.ForEach((message) => builder.Append($"{message}\n"));
            txt_chat_screen.Text = builder.ToString();
            txt_chat_screen.SelectionStart = txt_chat_screen.Text.Length;
            txt_chat_screen.ScrollToCaret();
        }
        private void ProcessCards()
        {
            var pictureCards = new PictureBox[] { pbox_card_1, pbox_card_2, pbox_card_3, pbox_card_4, pbox_card_5 };

            for (int i = 0; i < 5; i++)
            {
                game.cards[myId][i].UnvalidateCache();
                Bitmap temp = game.cards[myId][i].Image;

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
            var pictureBoxes = new PictureBox[] { pbox_avatar_1, pbox_avatar_2, pbox_avatar_3, pbox_avatar_4, pbox_avatar_5, pbox_avatar_6, pbox_avatar_7, pbox_avatar_8 };
            pictureBoxes.ToList().ForEach((pbox) => pbox.Hide());
            for (int i = 0; i < game.Players.Count; i++)
            {
                pictureBoxes[i].Show();
                if(i==game.currentPlayer)
                {
                    pictureBoxes[i].BorderStyle = BorderStyle.Fixed3D;
                }
                else
                {
                    pictureBoxes[i].BorderStyle = BorderStyle.None;

                }
                var playerBmp = new PlayerInformation(game.Players[i]).GetPictureBitmap(pictureBoxes[i].Width, pictureBoxes[i].Height);
                if (game.effects[game.Players[i].Split(';')[0]] == CardHelpers.PowerUp.NoBuild)
                {
                    Graphics g = Graphics.FromImage(playerBmp);
                    g.DrawLine(new Pen(Color.Red, 10), 0, 0, playerBmp.Width, playerBmp.Height);
                }
                pictureBoxes[i].Image = playerBmp;
            }

        }
        private void ProcessDiamonds()
        {
            var diamonds = board.Diamonds;
            diamondsCounter1.SetCurrent(diamonds);
            diamondsCounter1.SetNeeded(game.diamondsNeeded);
        }
        #endregion

        #region Close max and min buttons
        private void Lbl_close_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Lbl_maximize_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            this.WindowState = FormWindowState.Maximized;
            imageZoom = 5;
            pbox_game.Invalidate();
        }

        private void Lbl_minimize_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
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
            if((game.Messages.Count!=ngame.Messages.Count|| game.Moves.Count!=ngame.Moves.Count||game.currentPlayer!=ngame.currentPlayer) && !updating)
            {
                if(game.currentPlayer!= ngame.currentPlayer && ngame.currentPlayer == myId)
                {
                    MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.yourTurnMusicPlayer);
                }
                if(game.Moves.Count!=ngame.Moves.Count)
                {
                    var move = ngame.Moves.Last().card;
                    switch(move.type)
                    {
                        case CardHelpers.CardType.Path:
                            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.buildMusicPlayer);
                            break;
                        case CardHelpers.CardType.PathX:
                            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.destroyRoadMusicPlayer);
                            break;
                        case CardHelpers.CardType.Power:
                            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.powerupMusicPlayer);
                            break;
                    }
                }
                game = ngame;
                LoadLobby();
                gameImage = board.Image;
                pbox_game.Update();
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateData();
            txt_message.Focus();
        }
        #endregion

        private void Lbl_send_message_Click(object sender, EventArgs e)
        {
            if (!loading && !updating)
            {
                MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
                game.Messages.Add($"{me.name}: {txt_message.Text}");
                txt_message.Text = "";
                UpdateLobby();
            }
        }

        private async void UpdateLobby()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://corupta-ddd6d.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            updating = true;
            retrySending:
            try
            {
                await client.UpdateAsync($"lobbies/{id}", game);
            }
            catch { System.Threading.Thread.Sleep(10); goto retrySending; }
            updating = false;
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


        private void Pbox_game_Click(object sender, EventArgs e)
        {
            this.pbox_game.Enabled = false;
            float px = ((MouseEventArgs)e).X;
            float py = ((MouseEventArgs)e).Y;
            int x = (int)((float)(px - movingPoint.X) / ((float)Board.WidthCell * imageZoom));
            int y = (int)((float)(py - movingPoint.Y) / ((float)Board.HeightCell * imageZoom));
            if (game.currentPlayer == myId 
                && game.discardsLeft==3
                && selectedCard != -1)
            {
                if (game.cards[myId][selectedCard].type == CardHelpers.CardType.Path)
                {
                    Card savedCard = (Card)game.cards[myId][selectedCard].Clone();
                    for (int i = 0; i < rotations[selectedCard]; i++)
                        game.cards[myId][selectedCard].Rotate();

                    if (game.effects[me.name] == CardHelpers.PowerUp.Build
                    && board.IsCompatible(this.game.cards[myId][selectedCard], x, y))
                    {
                        MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.buildMusicPlayer);
                        board.ChangeAt(this.game.cards[myId][selectedCard], x, y);
                        gameImage = board.Image;
                        pbox_game.Invalidate();
                        game.Moves.Add(new MoveModel(this.game.cards[myId][selectedCard], $"1;{x};{y}"));
                        game.Messages.Add($"{me.name} Added path at x:{x}, y:{y}.");
                        UpdateCardsAfterUse();
                        UpdateLobby();
                    }
                    else
                    {
                        game.cards[myId][selectedCard] = savedCard;
                        MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationNoMusicPlayer);
                    }
                }
                else if (this.game.cards[myId][selectedCard].type == CardHelpers.CardType.PathX
                    && board.IsObjective(x, y) == false)
                {

                    MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.destroyRoadMusicPlayer);
                    PictureBox pbox = new PictureBox
                    {
                        Size = new Size(64, 64)
                    };
                    pbox.BackColor = Color.Black;
                    Bitmap bmp = new Bitmap(Resources.Explosion);
                    pbox.Image = bmp;
                    this.bunifuCards1.Controls.Add(pbox);
                    pbox.BringToFront();
                    var location = new Point(bunifuCards1.PointToClient(MousePosition).X-32, bunifuCards1.PointToClient(MousePosition).Y - 32);
                    pbox.Location = location;
                    pbox.Location.Offset(-32, -32);

                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
                    {
                        Enabled = true,
                        Interval = 500
                    };
                    timer.Start();
                    timer.Tick += (_, __) => {
                        this.bunifuCards1.Controls.Remove(pbox);
                        pbox.Dispose();
                        bmp.Dispose();
                        timer.Enabled = false;
                        timer.Stop();
                    };
                    board.ChangeAt(new Card(), x, y);
                    gameImage = board.Image;
                    pbox_game.Invalidate();
                    game.Moves.Add(new MoveModel(new Card(), $"1;{x};{y}"));
                    game.Messages.Add($"{me.name} Removed path at x:{x}, y:{y}.");
                    UpdateCardsAfterUse();
                    UpdateLobby();

                }
                else if (game.cards[myId][selectedCard].type == CardHelpers.CardType.Power
                    && game.cards[myId][selectedCard].power == CardHelpers.PowerUp.Map
                    && board.IsObjective(x, y)
                    && (new Point(x, y) != game.startingPoint))
                {

                    MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.powerupMusicPlayer);
                    game.Moves.Add(new MoveModel(game.cards[myId][selectedCard], $"3;{x};{y};{myId}"));
                    board.SetVisible(x, y);
                    game.Messages.Add($"{me.name} Peeked at x:{x}, y:{y}");
                    gameImage = board.Image;
                    pbox_game.Invalidate();
                    UpdateCardsAfterUse();
                    UpdateLobby();
                }
            }
            else if(selectedCard!=-1)
            {
                MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationNoMusicPlayer);
            }
            this.pbox_game.Enabled = true;
        }

        private void CardMouseEnter(object sender, EventArgs e)
        {
            var pbox = ((PictureBox)sender);
            pbox.Size = new Size(90,90);
            pbox.Location = new Point(pbox.Location.X - 5, pbox.Location.Y - 5);
        }

        private void CardMouseLeave(object sender, EventArgs e)
        {
            var pbox = ((PictureBox)sender);
            pbox.Size = new Size(80, 80);
            pbox.Location = new Point(pbox.Location.X + 5, pbox.Location.Y + 5);
        }

        private void Card_Click(object sender, EventArgs e)
        {
            MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
            var pictureCards = new PictureBox[] { pbox_card_1, pbox_card_2, pbox_card_3, pbox_card_4, pbox_card_5 };
            var pbox = ((PictureBox)sender);
            if (selectedCard != -1)
            {
                pictureCards[selectedCard].BorderStyle = BorderStyle.None;
            }
            selectedCard = int.Parse(pbox.Tag.ToString());
            pictureCards[selectedCard].BorderStyle = BorderStyle.Fixed3D;

            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                rotations[selectedCard] = (rotations[selectedCard] + 1) % 4;
                game.cards[myId][selectedCard].UnvalidateCache();
                Bitmap temp = game.cards[myId][selectedCard].Image;
                
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
            board.SelectedCard = card;
            gameImage = board.Image;
            pbox_game.Invalidate();
        }

        private void Pbox_avatar_Click(object sender, EventArgs e)
        {
            if(game.currentPlayer == myId 
                && game.discardsLeft==3
                && selectedCard != -1 
                && game.cards[myId][selectedCard].type == CardHelpers.CardType.Power)
            {
                MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.powerupMusicPlayer);
                int idPlayer = int.Parse(((PictureBox)sender).Tag.ToString());
                string playerName = game.Players[idPlayer].Split(';')[0];
                if (game.cards[myId][selectedCard].power == CardHelpers.PowerUp.Switch)
                {
                    Random rnd = new Random();
                    game.roles[idPlayer] = rnd.Next(0, 3);
                    game.Messages.Add($"{me.name} switched {playerName}'s role.");
                }
                else
                {
                    game.effects[playerName] = game.cards[myId][selectedCard].power;
                    game.Moves.Add(new MoveModel(game.cards[myId][selectedCard], "2;" + playerName));
                    game.Messages.Add($"{me.name} used a power card on {playerName}.");
                }
                UpdateCardsAfterUse();
                ProcessAvatars();
                UpdateLobby();
            }
            else if(selectedCard!=-1)
            {
                MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationNoMusicPlayer);
            }
        }
        private void UpdateCardsAfterUse(bool changeRound = true)
        {
            board.SelectedCard = null;
            gameImage = board.Image;
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

        private void Pbox_game_MouseLeave(object sender, EventArgs e)
        {
            this.bunifuCards1.Controls.Remove(coordinateLabel);
            coordinateLabel = null;
        }
        #endregion


        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (game.currentPlayer == myId
                && e.KeyData == Keys.Delete
                && selectedCard != -1
                && !loading
                && !updating)
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
            else if(selectedCard!=-1)
            {
                MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationNoMusicPlayer);
            }
        }

        private void Lbl_endRound_Click(object sender, EventArgs e)
        {
            if (game.currentPlayer == myId && !updating && !loading)
            {
                MusicPlayerHelper.PlayYourAudio(ref MusicPlayerHelper.navigationMusicPlayer);
                game.currentPlayer = (game.currentPlayer + 1) % this.game.Players.Count;
                game.discardsLeft = 3;
                UpdateLobby();
            }
        }
        Label nameHelperLabel = null;
        private void Avatar_MouseEnter(object sender, EventArgs e)
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

        private void Avatar_MouseLeave(object sender, EventArgs e)
        {
            this.bunifuCards1.Controls.Remove(nameHelperLabel);
            nameHelperLabel = null;
        }
        Label selectedLabel = null;
        private void Lbl_endRound_MouseEnter(object sender, EventArgs e)
        {
            this.selectedLabel = lbl_endRound;
            this.lbl_endRound.Text = "-End round-";
        }

        private void Lbl_endRound_MouseLeave(object sender, EventArgs e)
        {
            this.selectedLabel = null;
            this.lbl_endRound.Text = "End round";
        }

        private void Timer_animation_Tick(object sender, EventArgs e)
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
