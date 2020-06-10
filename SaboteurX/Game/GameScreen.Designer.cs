namespace SaboteurX
{
    partial class GameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.card_moveForm = new Bunifu.Framework.UI.BunifuCards();
            this.musicControlButtons1 = new SaboteurX.MusicControlButtons();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_maximize = new System.Windows.Forms.Label();
            this.lbl_minimize = new System.Windows.Forms.Label();
            this.lbl_close = new System.Windows.Forms.Label();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.diamondsCounter1 = new SaboteurX.Game.DiamondsCounter();
            this.lbl_cardsLeft = new System.Windows.Forms.Label();
            this.lbl_discardsLeft = new System.Windows.Forms.Label();
            this.lbl_endRound = new System.Windows.Forms.Label();
            this.lbl_player = new System.Windows.Forms.Label();
            this.lbl_role = new System.Windows.Forms.Label();
            this.pbox_avatar_8 = new System.Windows.Forms.PictureBox();
            this.pbox_avatar_7 = new System.Windows.Forms.PictureBox();
            this.pbox_avatar_6 = new System.Windows.Forms.PictureBox();
            this.pbox_avatar_5 = new System.Windows.Forms.PictureBox();
            this.pbox_avatar_4 = new System.Windows.Forms.PictureBox();
            this.pbox_avatar_3 = new System.Windows.Forms.PictureBox();
            this.pbox_avatar_2 = new System.Windows.Forms.PictureBox();
            this.pbox_avatar_1 = new System.Windows.Forms.PictureBox();
            this.pbox_card_5 = new System.Windows.Forms.PictureBox();
            this.pbox_card_4 = new System.Windows.Forms.PictureBox();
            this.pbox_card_3 = new System.Windows.Forms.PictureBox();
            this.pbox_card_2 = new System.Windows.Forms.PictureBox();
            this.pbox_card_1 = new System.Windows.Forms.PictureBox();
            this.lbl_chat_title = new System.Windows.Forms.Label();
            this.txt_chat_screen = new System.Windows.Forms.RichTextBox();
            this.lbl_send_message = new System.Windows.Forms.Label();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.pbox_game = new System.Windows.Forms.PictureBox();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.timer_animation = new System.Windows.Forms.Timer(this.components);
            this.card_moveForm.SuspendLayout();
            this.bunifuCards2.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_card_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_card_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_card_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_card_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_card_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_game)).BeginInit();
            this.SuspendLayout();
            // 
            // card_moveForm
            // 
            this.card_moveForm.BackColor = System.Drawing.Color.DarkGreen;
            this.card_moveForm.BorderRadius = 5;
            this.card_moveForm.BottomSahddow = true;
            this.card_moveForm.color = System.Drawing.Color.DarkGreen;
            this.card_moveForm.Controls.Add(this.musicControlButtons1);
            this.card_moveForm.LeftSahddow = false;
            this.card_moveForm.Location = new System.Drawing.Point(0, 0);
            this.card_moveForm.Name = "card_moveForm";
            this.card_moveForm.RightSahddow = true;
            this.card_moveForm.ShadowDepth = 20;
            this.card_moveForm.Size = new System.Drawing.Size(512, 63);
            this.card_moveForm.TabIndex = 6;
            this.card_moveForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Card_moveForm_MouseDown);
            // 
            // musicControlButtons1
            // 
            this.musicControlButtons1.BackColor = System.Drawing.Color.Transparent;
            this.musicControlButtons1.Location = new System.Drawing.Point(3, 3);
            this.musicControlButtons1.Name = "musicControlButtons1";
            this.musicControlButtons1.Size = new System.Drawing.Size(80, 40);
            this.musicControlButtons1.TabIndex = 27;
            // 
            // bunifuCards2
            // 
            this.bunifuCards2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards2.BackColor = System.Drawing.Color.DarkGreen;
            this.bunifuCards2.BorderRadius = 5;
            this.bunifuCards2.BottomSahddow = true;
            this.bunifuCards2.color = System.Drawing.Color.DarkGreen;
            this.bunifuCards2.Controls.Add(this.lbl_maximize);
            this.bunifuCards2.Controls.Add(this.lbl_minimize);
            this.bunifuCards2.Controls.Add(this.lbl_close);
            this.bunifuCards2.LeftSahddow = false;
            this.bunifuCards2.Location = new System.Drawing.Point(798, 0);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(191, 63);
            this.bunifuCards2.TabIndex = 7;
            // 
            // lbl_maximize
            // 
            this.lbl_maximize.BackColor = System.Drawing.Color.Transparent;
            this.lbl_maximize.Font = new System.Drawing.Font("Consolas", 31.25F);
            this.lbl_maximize.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_maximize.Location = new System.Drawing.Point(67, 0);
            this.lbl_maximize.Name = "lbl_maximize";
            this.lbl_maximize.Size = new System.Drawing.Size(56, 42);
            this.lbl_maximize.TabIndex = 6;
            this.lbl_maximize.Tag = "off";
            this.lbl_maximize.Text = "□";
            this.lbl_maximize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_maximize.Click += new System.EventHandler(this.Lbl_maximize_Click);
            // 
            // lbl_minimize
            // 
            this.lbl_minimize.BackColor = System.Drawing.Color.Transparent;
            this.lbl_minimize.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.lbl_minimize.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_minimize.Location = new System.Drawing.Point(5, 0);
            this.lbl_minimize.Name = "lbl_minimize";
            this.lbl_minimize.Size = new System.Drawing.Size(56, 42);
            this.lbl_minimize.TabIndex = 5;
            this.lbl_minimize.Tag = "off";
            this.lbl_minimize.Text = "____";
            this.lbl_minimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbl_minimize.Click += new System.EventHandler(this.Lbl_minimize_Click);
            // 
            // lbl_close
            // 
            this.lbl_close.BackColor = System.Drawing.Color.Transparent;
            this.lbl_close.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.lbl_close.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_close.Location = new System.Drawing.Point(129, 0);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(56, 42);
            this.lbl_close.TabIndex = 4;
            this.lbl_close.Tag = "off";
            this.lbl_close.Text = "\\/\r\n/\\";
            this.lbl_close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_close.Click += new System.EventHandler(this.Lbl_close_Click);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards1.BackColor = System.Drawing.Color.DarkGreen;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.DarkGreen;
            this.bunifuCards1.Controls.Add(this.diamondsCounter1);
            this.bunifuCards1.Controls.Add(this.lbl_cardsLeft);
            this.bunifuCards1.Controls.Add(this.lbl_discardsLeft);
            this.bunifuCards1.Controls.Add(this.lbl_endRound);
            this.bunifuCards1.Controls.Add(this.lbl_player);
            this.bunifuCards1.Controls.Add(this.lbl_role);
            this.bunifuCards1.Controls.Add(this.pbox_avatar_8);
            this.bunifuCards1.Controls.Add(this.pbox_avatar_7);
            this.bunifuCards1.Controls.Add(this.pbox_avatar_6);
            this.bunifuCards1.Controls.Add(this.pbox_avatar_5);
            this.bunifuCards1.Controls.Add(this.pbox_avatar_4);
            this.bunifuCards1.Controls.Add(this.pbox_avatar_3);
            this.bunifuCards1.Controls.Add(this.pbox_avatar_2);
            this.bunifuCards1.Controls.Add(this.pbox_avatar_1);
            this.bunifuCards1.Controls.Add(this.pbox_card_5);
            this.bunifuCards1.Controls.Add(this.pbox_card_4);
            this.bunifuCards1.Controls.Add(this.pbox_card_3);
            this.bunifuCards1.Controls.Add(this.pbox_card_2);
            this.bunifuCards1.Controls.Add(this.pbox_card_1);
            this.bunifuCards1.Controls.Add(this.lbl_chat_title);
            this.bunifuCards1.Controls.Add(this.txt_chat_screen);
            this.bunifuCards1.Controls.Add(this.lbl_send_message);
            this.bunifuCards1.Controls.Add(this.txt_message);
            this.bunifuCards1.Controls.Add(this.pbox_game);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 50);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(989, 722);
            this.bunifuCards1.TabIndex = 8;
            // 
            // diamondsCounter1
            // 
            this.diamondsCounter1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.diamondsCounter1.BackColor = System.Drawing.Color.DarkGreen;
            this.diamondsCounter1.Location = new System.Drawing.Point(572, 122);
            this.diamondsCounter1.Name = "diamondsCounter1";
            this.diamondsCounter1.Size = new System.Drawing.Size(112, 42);
            this.diamondsCounter1.TabIndex = 27;
            // 
            // lbl_cardsLeft
            // 
            this.lbl_cardsLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_cardsLeft.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_cardsLeft.ForeColor = System.Drawing.Color.Black;
            this.lbl_cardsLeft.Location = new System.Drawing.Point(3, 595);
            this.lbl_cardsLeft.Name = "lbl_cardsLeft";
            this.lbl_cardsLeft.Size = new System.Drawing.Size(215, 32);
            this.lbl_cardsLeft.TabIndex = 25;
            this.lbl_cardsLeft.Text = "Cards left";
            this.lbl_cardsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_discardsLeft
            // 
            this.lbl_discardsLeft.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_discardsLeft.ForeColor = System.Drawing.Color.Black;
            this.lbl_discardsLeft.Location = new System.Drawing.Point(3, 89);
            this.lbl_discardsLeft.Name = "lbl_discardsLeft";
            this.lbl_discardsLeft.Size = new System.Drawing.Size(215, 33);
            this.lbl_discardsLeft.TabIndex = 26;
            this.lbl_discardsLeft.Text = "Discards left";
            this.lbl_discardsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_endRound
            // 
            this.lbl_endRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_endRound.Font = new System.Drawing.Font("Consolas", 25F, System.Drawing.FontStyle.Bold);
            this.lbl_endRound.ForeColor = System.Drawing.Color.Black;
            this.lbl_endRound.Location = new System.Drawing.Point(448, 633);
            this.lbl_endRound.Name = "lbl_endRound";
            this.lbl_endRound.Size = new System.Drawing.Size(236, 76);
            this.lbl_endRound.TabIndex = 24;
            this.lbl_endRound.Tag = "End round;NO";
            this.lbl_endRound.Text = "End round";
            this.lbl_endRound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_endRound.Click += new System.EventHandler(this.Lbl_endRound_Click);
            this.lbl_endRound.MouseEnter += new System.EventHandler(this.Lbl_endRound_MouseEnter);
            this.lbl_endRound.MouseLeave += new System.EventHandler(this.Lbl_endRound_MouseLeave);
            // 
            // lbl_player
            // 
            this.lbl_player.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_player.BackColor = System.Drawing.Color.Transparent;
            this.lbl_player.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_player.ForeColor = System.Drawing.Color.Black;
            this.lbl_player.Location = new System.Drawing.Point(455, 90);
            this.lbl_player.Name = "lbl_player";
            this.lbl_player.Size = new System.Drawing.Size(229, 32);
            this.lbl_player.TabIndex = 23;
            this.lbl_player.Text = "Div\'s turn";
            this.lbl_player.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_role
            // 
            this.lbl_role.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_role.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_role.ForeColor = System.Drawing.Color.Black;
            this.lbl_role.Location = new System.Drawing.Point(455, 595);
            this.lbl_role.Name = "lbl_role";
            this.lbl_role.Size = new System.Drawing.Size(229, 32);
            this.lbl_role.TabIndex = 22;
            this.lbl_role.Text = "Saboteur";
            this.lbl_role.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbox_avatar_8
            // 
            this.pbox_avatar_8.Location = new System.Drawing.Point(605, 7);
            this.pbox_avatar_8.Name = "pbox_avatar_8";
            this.pbox_avatar_8.Size = new System.Drawing.Size(80, 80);
            this.pbox_avatar_8.TabIndex = 21;
            this.pbox_avatar_8.TabStop = false;
            this.pbox_avatar_8.Tag = "7";
            this.pbox_avatar_8.Click += new System.EventHandler(this.Pbox_avatar_Click);
            this.pbox_avatar_8.MouseEnter += new System.EventHandler(this.Avatar_MouseEnter);
            this.pbox_avatar_8.MouseLeave += new System.EventHandler(this.Avatar_MouseLeave);
            // 
            // pbox_avatar_7
            // 
            this.pbox_avatar_7.Location = new System.Drawing.Point(519, 7);
            this.pbox_avatar_7.Name = "pbox_avatar_7";
            this.pbox_avatar_7.Size = new System.Drawing.Size(80, 80);
            this.pbox_avatar_7.TabIndex = 20;
            this.pbox_avatar_7.TabStop = false;
            this.pbox_avatar_7.Tag = "6";
            this.pbox_avatar_7.Click += new System.EventHandler(this.Pbox_avatar_Click);
            this.pbox_avatar_7.MouseEnter += new System.EventHandler(this.Avatar_MouseEnter);
            this.pbox_avatar_7.MouseLeave += new System.EventHandler(this.Avatar_MouseLeave);
            // 
            // pbox_avatar_6
            // 
            this.pbox_avatar_6.Location = new System.Drawing.Point(433, 7);
            this.pbox_avatar_6.Name = "pbox_avatar_6";
            this.pbox_avatar_6.Size = new System.Drawing.Size(80, 80);
            this.pbox_avatar_6.TabIndex = 19;
            this.pbox_avatar_6.TabStop = false;
            this.pbox_avatar_6.Tag = "5";
            this.pbox_avatar_6.Click += new System.EventHandler(this.Pbox_avatar_Click);
            this.pbox_avatar_6.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.pbox_avatar_6.MouseLeave += new System.EventHandler(this.Avatar_MouseLeave);
            // 
            // pbox_avatar_5
            // 
            this.pbox_avatar_5.Location = new System.Drawing.Point(347, 7);
            this.pbox_avatar_5.Name = "pbox_avatar_5";
            this.pbox_avatar_5.Size = new System.Drawing.Size(80, 80);
            this.pbox_avatar_5.TabIndex = 18;
            this.pbox_avatar_5.TabStop = false;
            this.pbox_avatar_5.Tag = "4";
            this.pbox_avatar_5.Click += new System.EventHandler(this.Pbox_avatar_Click);
            this.pbox_avatar_5.MouseEnter += new System.EventHandler(this.Avatar_MouseEnter);
            this.pbox_avatar_5.MouseLeave += new System.EventHandler(this.Avatar_MouseLeave);
            // 
            // pbox_avatar_4
            // 
            this.pbox_avatar_4.Location = new System.Drawing.Point(261, 7);
            this.pbox_avatar_4.Name = "pbox_avatar_4";
            this.pbox_avatar_4.Size = new System.Drawing.Size(80, 80);
            this.pbox_avatar_4.TabIndex = 17;
            this.pbox_avatar_4.TabStop = false;
            this.pbox_avatar_4.Tag = "3";
            this.pbox_avatar_4.Click += new System.EventHandler(this.Pbox_avatar_Click);
            this.pbox_avatar_4.MouseEnter += new System.EventHandler(this.Avatar_MouseEnter);
            this.pbox_avatar_4.MouseLeave += new System.EventHandler(this.Avatar_MouseLeave);
            // 
            // pbox_avatar_3
            // 
            this.pbox_avatar_3.Location = new System.Drawing.Point(175, 7);
            this.pbox_avatar_3.Name = "pbox_avatar_3";
            this.pbox_avatar_3.Size = new System.Drawing.Size(80, 80);
            this.pbox_avatar_3.TabIndex = 16;
            this.pbox_avatar_3.TabStop = false;
            this.pbox_avatar_3.Tag = "2";
            this.pbox_avatar_3.Click += new System.EventHandler(this.Pbox_avatar_Click);
            this.pbox_avatar_3.MouseEnter += new System.EventHandler(this.Avatar_MouseEnter);
            this.pbox_avatar_3.MouseLeave += new System.EventHandler(this.Avatar_MouseLeave);
            // 
            // pbox_avatar_2
            // 
            this.pbox_avatar_2.Location = new System.Drawing.Point(89, 7);
            this.pbox_avatar_2.Name = "pbox_avatar_2";
            this.pbox_avatar_2.Size = new System.Drawing.Size(80, 80);
            this.pbox_avatar_2.TabIndex = 15;
            this.pbox_avatar_2.TabStop = false;
            this.pbox_avatar_2.Tag = "1";
            this.pbox_avatar_2.Click += new System.EventHandler(this.Pbox_avatar_Click);
            this.pbox_avatar_2.MouseEnter += new System.EventHandler(this.Avatar_MouseEnter);
            this.pbox_avatar_2.MouseLeave += new System.EventHandler(this.Avatar_MouseLeave);
            // 
            // pbox_avatar_1
            // 
            this.pbox_avatar_1.Location = new System.Drawing.Point(3, 7);
            this.pbox_avatar_1.Name = "pbox_avatar_1";
            this.pbox_avatar_1.Size = new System.Drawing.Size(80, 80);
            this.pbox_avatar_1.TabIndex = 14;
            this.pbox_avatar_1.TabStop = false;
            this.pbox_avatar_1.Tag = "0";
            this.pbox_avatar_1.Click += new System.EventHandler(this.Pbox_avatar_Click);
            this.pbox_avatar_1.MouseEnter += new System.EventHandler(this.Avatar_MouseEnter);
            this.pbox_avatar_1.MouseLeave += new System.EventHandler(this.Avatar_MouseLeave);
            // 
            // pbox_card_5
            // 
            this.pbox_card_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbox_card_5.Location = new System.Drawing.Point(362, 633);
            this.pbox_card_5.Name = "pbox_card_5";
            this.pbox_card_5.Size = new System.Drawing.Size(80, 80);
            this.pbox_card_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_card_5.TabIndex = 13;
            this.pbox_card_5.TabStop = false;
            this.pbox_card_5.Tag = "4";
            this.pbox_card_5.Click += new System.EventHandler(this.Card_Click);
            this.pbox_card_5.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.pbox_card_5.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // pbox_card_4
            // 
            this.pbox_card_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbox_card_4.Location = new System.Drawing.Point(276, 633);
            this.pbox_card_4.Name = "pbox_card_4";
            this.pbox_card_4.Size = new System.Drawing.Size(80, 80);
            this.pbox_card_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_card_4.TabIndex = 12;
            this.pbox_card_4.TabStop = false;
            this.pbox_card_4.Tag = "3";
            this.pbox_card_4.Click += new System.EventHandler(this.Card_Click);
            this.pbox_card_4.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.pbox_card_4.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // pbox_card_3
            // 
            this.pbox_card_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbox_card_3.Location = new System.Drawing.Point(190, 633);
            this.pbox_card_3.Name = "pbox_card_3";
            this.pbox_card_3.Size = new System.Drawing.Size(80, 80);
            this.pbox_card_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_card_3.TabIndex = 11;
            this.pbox_card_3.TabStop = false;
            this.pbox_card_3.Tag = "2";
            this.pbox_card_3.Click += new System.EventHandler(this.Card_Click);
            this.pbox_card_3.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.pbox_card_3.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // pbox_card_2
            // 
            this.pbox_card_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbox_card_2.Location = new System.Drawing.Point(104, 633);
            this.pbox_card_2.Name = "pbox_card_2";
            this.pbox_card_2.Size = new System.Drawing.Size(80, 80);
            this.pbox_card_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_card_2.TabIndex = 10;
            this.pbox_card_2.TabStop = false;
            this.pbox_card_2.Tag = "1";
            this.pbox_card_2.Click += new System.EventHandler(this.Card_Click);
            this.pbox_card_2.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.pbox_card_2.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // pbox_card_1
            // 
            this.pbox_card_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbox_card_1.Location = new System.Drawing.Point(18, 633);
            this.pbox_card_1.Name = "pbox_card_1";
            this.pbox_card_1.Size = new System.Drawing.Size(80, 80);
            this.pbox_card_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_card_1.TabIndex = 9;
            this.pbox_card_1.TabStop = false;
            this.pbox_card_1.Tag = "0";
            this.pbox_card_1.Click += new System.EventHandler(this.Card_Click);
            this.pbox_card_1.MouseEnter += new System.EventHandler(this.CardMouseEnter);
            this.pbox_card_1.MouseLeave += new System.EventHandler(this.CardMouseLeave);
            // 
            // lbl_chat_title
            // 
            this.lbl_chat_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_chat_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_chat_title.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_chat_title.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_chat_title.Location = new System.Drawing.Point(690, 4);
            this.lbl_chat_title.Name = "lbl_chat_title";
            this.lbl_chat_title.Size = new System.Drawing.Size(284, 83);
            this.lbl_chat_title.TabIndex = 8;
            this.lbl_chat_title.Tag = "off";
            this.lbl_chat_title.Text = "____";
            this.lbl_chat_title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txt_chat_screen
            // 
            this.txt_chat_screen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_chat_screen.BackColor = System.Drawing.SystemColors.WindowText;
            this.txt_chat_screen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_chat_screen.Font = new System.Drawing.Font("Consolas", 12.25F);
            this.txt_chat_screen.ForeColor = System.Drawing.Color.Lime;
            this.txt_chat_screen.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txt_chat_screen.Location = new System.Drawing.Point(690, 90);
            this.txt_chat_screen.Name = "txt_chat_screen";
            this.txt_chat_screen.ReadOnly = true;
            this.txt_chat_screen.Size = new System.Drawing.Size(293, 584);
            this.txt_chat_screen.TabIndex = 7;
            this.txt_chat_screen.Text = "asdasd";
            this.txt_chat_screen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_message_KeyDown);
            // 
            // lbl_send_message
            // 
            this.lbl_send_message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_send_message.BackColor = System.Drawing.Color.Transparent;
            this.lbl_send_message.Font = new System.Drawing.Font("Consolas", 20.25F);
            this.lbl_send_message.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_send_message.Location = new System.Drawing.Point(946, 677);
            this.lbl_send_message.Name = "lbl_send_message";
            this.lbl_send_message.Size = new System.Drawing.Size(40, 27);
            this.lbl_send_message.TabIndex = 6;
            this.lbl_send_message.Tag = "off";
            this.lbl_send_message.Text = ">";
            this.lbl_send_message.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbl_send_message.Click += new System.EventHandler(this.Lbl_send_message_Click);
            // 
            // txt_message
            // 
            this.txt_message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_message.BackColor = System.Drawing.Color.Black;
            this.txt_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_message.Font = new System.Drawing.Font("Consolas", 12.25F);
            this.txt_message.ForeColor = System.Drawing.Color.Lime;
            this.txt_message.Location = new System.Drawing.Point(690, 682);
            this.txt_message.Name = "txt_message";
            this.txt_message.Size = new System.Drawing.Size(256, 27);
            this.txt_message.TabIndex = 2;
            this.txt_message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_message_KeyDown);
            // 
            // pbox_game
            // 
            this.pbox_game.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox_game.Location = new System.Drawing.Point(3, 90);
            this.pbox_game.Name = "pbox_game";
            this.pbox_game.Size = new System.Drawing.Size(681, 537);
            this.pbox_game.TabIndex = 1;
            this.pbox_game.TabStop = false;
            this.pbox_game.Click += new System.EventHandler(this.Pbox_game_Click);
            this.pbox_game.Paint += new System.Windows.Forms.PaintEventHandler(this.Pbox_game_Paint);
            this.pbox_game.DoubleClick += new System.EventHandler(this.Pbox_game_Click);
            this.pbox_game.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pbox_game_MouseDown);
            this.pbox_game.MouseLeave += new System.EventHandler(this.Pbox_game_MouseLeave);
            this.pbox_game.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pbox_game_MouseMove);
            this.pbox_game.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pbox_game_MouseUp);
            // 
            // timer_update
            // 
            this.timer_update.Enabled = true;
            this.timer_update.Interval = 2000;
            this.timer_update.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer_animation
            // 
            this.timer_animation.Enabled = true;
            this.timer_animation.Interval = 500;
            this.timer_animation.Tick += new System.EventHandler(this.Timer_animation_Tick);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 771);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.bunifuCards2);
            this.Controls.Add(this.card_moveForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameScreen";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.card_moveForm.ResumeLayout(false);
            this.bunifuCards2.ResumeLayout(false);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_card_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_card_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_card_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_card_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_card_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_game)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards card_moveForm;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private System.Windows.Forms.Label lbl_maximize;
        private System.Windows.Forms.Label lbl_minimize;
        private System.Windows.Forms.Label lbl_close;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.PictureBox pbox_game;
        private System.Windows.Forms.Label lbl_chat_title;
        private System.Windows.Forms.RichTextBox txt_chat_screen;
        private System.Windows.Forms.Label lbl_send_message;
        private System.Windows.Forms.TextBox txt_message;
        private System.Windows.Forms.Timer timer_update;
        private System.Windows.Forms.PictureBox pbox_avatar_8;
        private System.Windows.Forms.PictureBox pbox_avatar_7;
        private System.Windows.Forms.PictureBox pbox_avatar_6;
        private System.Windows.Forms.PictureBox pbox_avatar_5;
        private System.Windows.Forms.PictureBox pbox_avatar_4;
        private System.Windows.Forms.PictureBox pbox_avatar_3;
        private System.Windows.Forms.PictureBox pbox_avatar_2;
        private System.Windows.Forms.PictureBox pbox_avatar_1;
        private System.Windows.Forms.PictureBox pbox_card_5;
        private System.Windows.Forms.PictureBox pbox_card_4;
        private System.Windows.Forms.PictureBox pbox_card_3;
        private System.Windows.Forms.PictureBox pbox_card_2;
        private System.Windows.Forms.PictureBox pbox_card_1;
        private System.Windows.Forms.Label lbl_role;
        private System.Windows.Forms.Label lbl_player;
        private System.Windows.Forms.Label lbl_endRound;
        private System.Windows.Forms.Label lbl_cardsLeft;
        private System.Windows.Forms.Timer timer_animation;
        private System.Windows.Forms.Label lbl_discardsLeft;
        private MusicControlButtons musicControlButtons1;
        private Game.DiamondsCounter diamondsCounter1;
    }
}