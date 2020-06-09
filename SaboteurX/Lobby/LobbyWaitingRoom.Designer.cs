namespace SaboteurX
{
    partial class LobbyWaitingRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LobbyWaitingRoom));
            this.card_moveForm = new Bunifu.Framework.UI.BunifuCards();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_minimize = new System.Windows.Forms.Label();
            this.lbl_close = new System.Windows.Forms.Label();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_settings = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_vertical_divider_1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_quit = new System.Windows.Forms.Label();
            this.lbl_start = new System.Windows.Forms.Label();
            this.lbl_name_7 = new System.Windows.Forms.Label();
            this.lbl_name_6 = new System.Windows.Forms.Label();
            this.lbl_name_5 = new System.Windows.Forms.Label();
            this.lbl_name_4 = new System.Windows.Forms.Label();
            this.pbox_player_7 = new System.Windows.Forms.PictureBox();
            this.pbox_player_6 = new System.Windows.Forms.PictureBox();
            this.pbox_player_5 = new System.Windows.Forms.PictureBox();
            this.pbox_player_4 = new System.Windows.Forms.PictureBox();
            this.lbl_name_3 = new System.Windows.Forms.Label();
            this.lbl_name_2 = new System.Windows.Forms.Label();
            this.lbl_name_1 = new System.Windows.Forms.Label();
            this.lbl_name_0 = new System.Windows.Forms.Label();
            this.pbox_player_3 = new System.Windows.Forms.PictureBox();
            this.pbox_player_2 = new System.Windows.Forms.PictureBox();
            this.pbox_player_1 = new System.Windows.Forms.PictureBox();
            this.pbox_player_0 = new System.Windows.Forms.PictureBox();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.timer_animation = new System.Windows.Forms.Timer(this.components);
            this.musicControlButtons1 = new SaboteurX.MusicControlButtons();
            this.card_moveForm.SuspendLayout();
            this.bunifuCards2.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_0)).BeginInit();
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
            this.card_moveForm.Size = new System.Drawing.Size(512, 51);
            this.card_moveForm.TabIndex = 5;
            this.card_moveForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.card_moveForm_MouseDown);
            // 
            // bunifuCards2
            // 
            this.bunifuCards2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards2.BackColor = System.Drawing.Color.DarkGreen;
            this.bunifuCards2.BorderRadius = 5;
            this.bunifuCards2.BottomSahddow = true;
            this.bunifuCards2.color = System.Drawing.Color.DarkGreen;
            this.bunifuCards2.Controls.Add(this.lbl_minimize);
            this.bunifuCards2.Controls.Add(this.lbl_close);
            this.bunifuCards2.LeftSahddow = false;
            this.bunifuCards2.Location = new System.Drawing.Point(865, 0);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(123, 51);
            this.bunifuCards2.TabIndex = 4;
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
            this.lbl_minimize.Click += new System.EventHandler(this.lbl_minimize_Click);
            // 
            // lbl_close
            // 
            this.lbl_close.BackColor = System.Drawing.Color.Transparent;
            this.lbl_close.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.lbl_close.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_close.Location = new System.Drawing.Point(67, -1);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(56, 42);
            this.lbl_close.TabIndex = 4;
            this.lbl_close.Tag = "off";
            this.lbl_close.Text = "\\/\r\n/\\";
            this.lbl_close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
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
            this.bunifuCards1.Controls.Add(this.lbl_settings);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.lbl_vertical_divider_1);
            this.bunifuCards1.Controls.Add(this.label10);
            this.bunifuCards1.Controls.Add(this.lbl_quit);
            this.bunifuCards1.Controls.Add(this.lbl_start);
            this.bunifuCards1.Controls.Add(this.lbl_name_7);
            this.bunifuCards1.Controls.Add(this.lbl_name_6);
            this.bunifuCards1.Controls.Add(this.lbl_name_5);
            this.bunifuCards1.Controls.Add(this.lbl_name_4);
            this.bunifuCards1.Controls.Add(this.pbox_player_7);
            this.bunifuCards1.Controls.Add(this.pbox_player_6);
            this.bunifuCards1.Controls.Add(this.pbox_player_5);
            this.bunifuCards1.Controls.Add(this.pbox_player_4);
            this.bunifuCards1.Controls.Add(this.lbl_name_3);
            this.bunifuCards1.Controls.Add(this.lbl_name_2);
            this.bunifuCards1.Controls.Add(this.lbl_name_1);
            this.bunifuCards1.Controls.Add(this.lbl_name_0);
            this.bunifuCards1.Controls.Add(this.pbox_player_3);
            this.bunifuCards1.Controls.Add(this.pbox_player_2);
            this.bunifuCards1.Controls.Add(this.pbox_player_1);
            this.bunifuCards1.Controls.Add(this.pbox_player_0);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 45);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(988, 610);
            this.bunifuCards1.TabIndex = 6;
            // 
            // lbl_settings
            // 
            this.lbl_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_settings.BackColor = System.Drawing.Color.Transparent;
            this.lbl_settings.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_settings.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_settings.Location = new System.Drawing.Point(313, 499);
            this.lbl_settings.Name = "lbl_settings";
            this.lbl_settings.Size = new System.Drawing.Size(353, 100);
            this.lbl_settings.TabIndex = 28;
            this.lbl_settings.Tag = "Settings;NO";
            this.lbl_settings.Text = "settings";
            this.lbl_settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_settings.Click += new System.EventHandler(this.lbl_settings_Click);
            this.lbl_settings.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.lbl_settings.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(-3, -4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(985, 33);
            this.label1.TabIndex = 27;
            this.label1.Tag = "off";
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------------------------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_vertical_divider_1
            // 
            this.lbl_vertical_divider_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_vertical_divider_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_vertical_divider_1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vertical_divider_1.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_vertical_divider_1.Location = new System.Drawing.Point(487, 9);
            this.lbl_vertical_divider_1.Name = "lbl_vertical_divider_1";
            this.lbl_vertical_divider_1.Size = new System.Drawing.Size(17, 469);
            this.lbl_vertical_divider_1.TabIndex = 27;
            this.lbl_vertical_divider_1.Tag = "off";
            this.lbl_vertical_divider_1.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n" +
    "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|";
            this.lbl_vertical_divider_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Chartreuse;
            this.label10.Location = new System.Drawing.Point(0, 466);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(985, 33);
            this.label10.TabIndex = 26;
            this.label10.Tag = "off";
            this.label10.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------------------------";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_quit
            // 
            this.lbl_quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_quit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_quit.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_quit.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_quit.Location = new System.Drawing.Point(37, 499);
            this.lbl_quit.Name = "lbl_quit";
            this.lbl_quit.Size = new System.Drawing.Size(280, 100);
            this.lbl_quit.TabIndex = 25;
            this.lbl_quit.Tag = "Quit;NO";
            this.lbl_quit.Text = "Quit";
            this.lbl_quit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_quit.Click += new System.EventHandler(this.lbl_quit_Click);
            this.lbl_quit.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.lbl_quit.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // lbl_start
            // 
            this.lbl_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_start.BackColor = System.Drawing.Color.Transparent;
            this.lbl_start.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_start.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_start.Location = new System.Drawing.Point(672, 499);
            this.lbl_start.Name = "lbl_start";
            this.lbl_start.Size = new System.Drawing.Size(281, 100);
            this.lbl_start.TabIndex = 24;
            this.lbl_start.Tag = "Start;NO";
            this.lbl_start.Text = "start";
            this.lbl_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_start.Click += new System.EventHandler(this.lbl_start_Click);
            this.lbl_start.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.lbl_start.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // lbl_name_7
            // 
            this.lbl_name_7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_name_7.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name_7.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_name_7.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_name_7.Location = new System.Drawing.Point(616, 350);
            this.lbl_name_7.Name = "lbl_name_7";
            this.lbl_name_7.Size = new System.Drawing.Size(337, 100);
            this.lbl_name_7.TabIndex = 23;
            this.lbl_name_7.Tag = "Name;NO";
            this.lbl_name_7.Text = resources.GetString("lbl_name_7.Text");
            this.lbl_name_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_name_6
            // 
            this.lbl_name_6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_name_6.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name_6.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_name_6.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_name_6.Location = new System.Drawing.Point(616, 244);
            this.lbl_name_6.Name = "lbl_name_6";
            this.lbl_name_6.Size = new System.Drawing.Size(337, 100);
            this.lbl_name_6.TabIndex = 22;
            this.lbl_name_6.Tag = "Name;NO";
            this.lbl_name_6.Text = resources.GetString("lbl_name_6.Text");
            this.lbl_name_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_name_5
            // 
            this.lbl_name_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_name_5.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name_5.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_name_5.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_name_5.Location = new System.Drawing.Point(616, 138);
            this.lbl_name_5.Name = "lbl_name_5";
            this.lbl_name_5.Size = new System.Drawing.Size(337, 100);
            this.lbl_name_5.TabIndex = 21;
            this.lbl_name_5.Tag = "Name;NO";
            this.lbl_name_5.Text = resources.GetString("lbl_name_5.Text");
            this.lbl_name_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_name_4
            // 
            this.lbl_name_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_name_4.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name_4.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_name_4.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_name_4.Location = new System.Drawing.Point(616, 32);
            this.lbl_name_4.Name = "lbl_name_4";
            this.lbl_name_4.Size = new System.Drawing.Size(337, 100);
            this.lbl_name_4.TabIndex = 20;
            this.lbl_name_4.Tag = "Name;NO";
            this.lbl_name_4.Text = resources.GetString("lbl_name_4.Text");
            this.lbl_name_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbox_player_7
            // 
            this.pbox_player_7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox_player_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_player_7.Location = new System.Drawing.Point(510, 350);
            this.pbox_player_7.Name = "pbox_player_7";
            this.pbox_player_7.Size = new System.Drawing.Size(100, 100);
            this.pbox_player_7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_player_7.TabIndex = 19;
            this.pbox_player_7.TabStop = false;
            // 
            // pbox_player_6
            // 
            this.pbox_player_6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox_player_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_player_6.Location = new System.Drawing.Point(510, 244);
            this.pbox_player_6.Name = "pbox_player_6";
            this.pbox_player_6.Size = new System.Drawing.Size(100, 100);
            this.pbox_player_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_player_6.TabIndex = 18;
            this.pbox_player_6.TabStop = false;
            // 
            // pbox_player_5
            // 
            this.pbox_player_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox_player_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_player_5.Location = new System.Drawing.Point(510, 138);
            this.pbox_player_5.Name = "pbox_player_5";
            this.pbox_player_5.Size = new System.Drawing.Size(100, 100);
            this.pbox_player_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_player_5.TabIndex = 17;
            this.pbox_player_5.TabStop = false;
            // 
            // pbox_player_4
            // 
            this.pbox_player_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox_player_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_player_4.Location = new System.Drawing.Point(510, 32);
            this.pbox_player_4.Name = "pbox_player_4";
            this.pbox_player_4.Size = new System.Drawing.Size(100, 100);
            this.pbox_player_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_player_4.TabIndex = 16;
            this.pbox_player_4.TabStop = false;
            // 
            // lbl_name_3
            // 
            this.lbl_name_3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name_3.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_name_3.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_name_3.Location = new System.Drawing.Point(145, 350);
            this.lbl_name_3.Name = "lbl_name_3";
            this.lbl_name_3.Size = new System.Drawing.Size(337, 100);
            this.lbl_name_3.TabIndex = 15;
            this.lbl_name_3.Tag = "Name;NO";
            this.lbl_name_3.Text = resources.GetString("lbl_name_3.Text");
            this.lbl_name_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_name_2
            // 
            this.lbl_name_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name_2.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_name_2.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_name_2.Location = new System.Drawing.Point(145, 244);
            this.lbl_name_2.Name = "lbl_name_2";
            this.lbl_name_2.Size = new System.Drawing.Size(337, 100);
            this.lbl_name_2.TabIndex = 14;
            this.lbl_name_2.Tag = "Name;NO";
            this.lbl_name_2.Text = resources.GetString("lbl_name_2.Text");
            this.lbl_name_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_name_1
            // 
            this.lbl_name_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name_1.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_name_1.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_name_1.Location = new System.Drawing.Point(145, 138);
            this.lbl_name_1.Name = "lbl_name_1";
            this.lbl_name_1.Size = new System.Drawing.Size(337, 100);
            this.lbl_name_1.TabIndex = 13;
            this.lbl_name_1.Tag = "Name;NO";
            this.lbl_name_1.Text = resources.GetString("lbl_name_1.Text");
            this.lbl_name_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_name_0
            // 
            this.lbl_name_0.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name_0.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_name_0.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_name_0.Location = new System.Drawing.Point(145, 32);
            this.lbl_name_0.Name = "lbl_name_0";
            this.lbl_name_0.Size = new System.Drawing.Size(337, 100);
            this.lbl_name_0.TabIndex = 12;
            this.lbl_name_0.Tag = "Name;NO";
            this.lbl_name_0.Text = resources.GetString("lbl_name_0.Text");
            this.lbl_name_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbox_player_3
            // 
            this.pbox_player_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_player_3.Location = new System.Drawing.Point(39, 350);
            this.pbox_player_3.Name = "pbox_player_3";
            this.pbox_player_3.Size = new System.Drawing.Size(100, 100);
            this.pbox_player_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_player_3.TabIndex = 5;
            this.pbox_player_3.TabStop = false;
            // 
            // pbox_player_2
            // 
            this.pbox_player_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_player_2.Location = new System.Drawing.Point(39, 244);
            this.pbox_player_2.Name = "pbox_player_2";
            this.pbox_player_2.Size = new System.Drawing.Size(100, 100);
            this.pbox_player_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_player_2.TabIndex = 4;
            this.pbox_player_2.TabStop = false;
            // 
            // pbox_player_1
            // 
            this.pbox_player_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_player_1.Location = new System.Drawing.Point(39, 138);
            this.pbox_player_1.Name = "pbox_player_1";
            this.pbox_player_1.Size = new System.Drawing.Size(100, 100);
            this.pbox_player_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_player_1.TabIndex = 3;
            this.pbox_player_1.TabStop = false;
            // 
            // pbox_player_0
            // 
            this.pbox_player_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_player_0.Location = new System.Drawing.Point(39, 32);
            this.pbox_player_0.Name = "pbox_player_0";
            this.pbox_player_0.Size = new System.Drawing.Size(100, 100);
            this.pbox_player_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_player_0.TabIndex = 2;
            this.pbox_player_0.TabStop = false;
            // 
            // timer_update
            // 
            this.timer_update.Enabled = true;
            this.timer_update.Interval = 2000;
            this.timer_update.Tick += new System.EventHandler(this.timer_update_Tick);
            // 
            // timer_animation
            // 
            this.timer_animation.Enabled = true;
            this.timer_animation.Interval = 500;
            this.timer_animation.Tick += new System.EventHandler(this.timer_animation_Tick);
            // 
            // musicControlButtons1
            // 
            this.musicControlButtons1.BackColor = System.Drawing.Color.Transparent;
            this.musicControlButtons1.Location = new System.Drawing.Point(3, 3);
            this.musicControlButtons1.Name = "musicControlButtons1";
            this.musicControlButtons1.Size = new System.Drawing.Size(80, 40);
            this.musicControlButtons1.TabIndex = 1;
            // 
            // LobbyWaitingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 653);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.card_moveForm);
            this.Controls.Add(this.bunifuCards2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LobbyWaitingRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LobbyWaitingRoom";
            this.Load += new System.EventHandler(this.LobbyWaitingRoom_Load);
            this.card_moveForm.ResumeLayout(false);
            this.bunifuCards2.ResumeLayout(false);
            this.bunifuCards1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_player_0)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards card_moveForm;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private System.Windows.Forms.Label lbl_minimize;
        private System.Windows.Forms.Label lbl_close;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.PictureBox pbox_player_3;
        private System.Windows.Forms.PictureBox pbox_player_2;
        private System.Windows.Forms.PictureBox pbox_player_1;
        private System.Windows.Forms.PictureBox pbox_player_0;
        private System.Windows.Forms.Label lbl_quit;
        private System.Windows.Forms.Label lbl_start;
        private System.Windows.Forms.Label lbl_name_7;
        private System.Windows.Forms.Label lbl_name_6;
        private System.Windows.Forms.Label lbl_name_5;
        private System.Windows.Forms.Label lbl_name_4;
        private System.Windows.Forms.PictureBox pbox_player_7;
        private System.Windows.Forms.PictureBox pbox_player_6;
        private System.Windows.Forms.PictureBox pbox_player_5;
        private System.Windows.Forms.PictureBox pbox_player_4;
        private System.Windows.Forms.Label lbl_name_3;
        private System.Windows.Forms.Label lbl_name_2;
        private System.Windows.Forms.Label lbl_name_1;
        private System.Windows.Forms.Label lbl_name_0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_vertical_divider_1;
        private System.Windows.Forms.Timer timer_update;
        private System.Windows.Forms.Timer timer_animation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_settings;
        private MusicControlButtons musicControlButtons1;
    }
}