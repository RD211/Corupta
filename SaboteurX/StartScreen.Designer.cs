namespace SaboteurX
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.card_mainScreen = new Bunifu.Framework.UI.BunifuCards();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_settings = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_play = new System.Windows.Forms.Label();
            this.lbl_title_main_screen = new System.Windows.Forms.Label();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_maximize = new System.Windows.Forms.Label();
            this.lbl_minimize = new System.Windows.Forms.Label();
            this.lbl_close = new System.Windows.Forms.Label();
            this.card_moveForm = new Bunifu.Framework.UI.BunifuCards();
            this.timer_animation = new System.Windows.Forms.Timer(this.components);
            this.card_mainScreen.SuspendLayout();
            this.bunifuCards2.SuspendLayout();
            this.SuspendLayout();
            // 
            // card_mainScreen
            // 
            this.card_mainScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.card_mainScreen.BackColor = System.Drawing.Color.DarkGreen;
            this.card_mainScreen.BorderRadius = 5;
            this.card_mainScreen.BottomSahddow = true;
            this.card_mainScreen.color = System.Drawing.Color.DarkGreen;
            this.card_mainScreen.Controls.Add(this.label1);
            this.card_mainScreen.Controls.Add(this.lbl_settings);
            this.card_mainScreen.Controls.Add(this.label2);
            this.card_mainScreen.Controls.Add(this.lbl_play);
            this.card_mainScreen.Controls.Add(this.lbl_title_main_screen);
            this.card_mainScreen.LeftSahddow = false;
            this.card_mainScreen.Location = new System.Drawing.Point(0, 45);
            this.card_mainScreen.Name = "card_mainScreen";
            this.card_mainScreen.RightSahddow = true;
            this.card_mainScreen.ShadowDepth = 20;
            this.card_mainScreen.Size = new System.Drawing.Size(885, 521);
            this.card_mainScreen.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(879, 33);
            this.label1.TabIndex = 7;
            this.label1.Tag = "off";
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------------------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_settings
            // 
            this.lbl_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_settings.BackColor = System.Drawing.Color.Transparent;
            this.lbl_settings.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_settings.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_settings.Location = new System.Drawing.Point(0, 382);
            this.lbl_settings.Name = "lbl_settings";
            this.lbl_settings.Size = new System.Drawing.Size(882, 111);
            this.lbl_settings.TabIndex = 6;
            this.lbl_settings.Tag = "Settings;NO";
            this.lbl_settings.Text = resources.GetString("lbl_settings.Text");
            this.lbl_settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_settings.Click += new System.EventHandler(this.Lbl_settings_Click);
            this.lbl_settings.MouseEnter += new System.EventHandler(this.SelectLabelEvent);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(3, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(879, 33);
            this.label2.TabIndex = 5;
            this.label2.Tag = "off";
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------------------";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_play
            // 
            this.lbl_play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_play.BackColor = System.Drawing.Color.Transparent;
            this.lbl_play.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_play.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_play.Location = new System.Drawing.Point(0, 258);
            this.lbl_play.Name = "lbl_play";
            this.lbl_play.Size = new System.Drawing.Size(885, 111);
            this.lbl_play.TabIndex = 4;
            this.lbl_play.Tag = "Play;NO";
            this.lbl_play.Text = resources.GetString("lbl_play.Text");
            this.lbl_play.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_play.Click += new System.EventHandler(this.Lbl_play_Click_1);
            this.lbl_play.MouseEnter += new System.EventHandler(this.SelectLabelEvent);
            // 
            // lbl_title_main_screen
            // 
            this.lbl_title_main_screen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title_main_screen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title_main_screen.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title_main_screen.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_title_main_screen.Location = new System.Drawing.Point(3, 65);
            this.lbl_title_main_screen.Name = "lbl_title_main_screen";
            this.lbl_title_main_screen.Size = new System.Drawing.Size(879, 160);
            this.lbl_title_main_screen.TabIndex = 3;
            this.lbl_title_main_screen.Tag = "";
            this.lbl_title_main_screen.Text = resources.GetString("lbl_title_main_screen.Text");
            this.lbl_title_main_screen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.bunifuCards2.Location = new System.Drawing.Point(697, 0);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(188, 51);
            this.bunifuCards2.TabIndex = 2;
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
            this.lbl_maximize.MouseEnter += new System.EventHandler(this.LabelZoomIn);
            this.lbl_maximize.MouseLeave += new System.EventHandler(this.LabelZoomOut);
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
            this.lbl_minimize.MouseEnter += new System.EventHandler(this.LabelZoomIn);
            this.lbl_minimize.MouseLeave += new System.EventHandler(this.LabelZoomOut);
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
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            this.lbl_close.MouseEnter += new System.EventHandler(this.LabelZoomIn);
            this.lbl_close.MouseLeave += new System.EventHandler(this.LabelZoomOut);
            // 
            // card_moveForm
            // 
            this.card_moveForm.BackColor = System.Drawing.Color.DarkGreen;
            this.card_moveForm.BorderRadius = 5;
            this.card_moveForm.BottomSahddow = true;
            this.card_moveForm.color = System.Drawing.Color.DarkGreen;
            this.card_moveForm.LeftSahddow = false;
            this.card_moveForm.Location = new System.Drawing.Point(0, 0);
            this.card_moveForm.Name = "card_moveForm";
            this.card_moveForm.RightSahddow = true;
            this.card_moveForm.ShadowDepth = 20;
            this.card_moveForm.Size = new System.Drawing.Size(512, 51);
            this.card_moveForm.TabIndex = 3;
            this.card_moveForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Card_moveForm_MouseDown);
            // 
            // timer_animation
            // 
            this.timer_animation.Enabled = true;
            this.timer_animation.Interval = 500;
            this.timer_animation.Tick += new System.EventHandler(this.Timer_animation_Tick);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 563);
            this.Controls.Add(this.card_mainScreen);
            this.Controls.Add(this.card_moveForm);
            this.Controls.Add(this.bunifuCards2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corupta";
            this.Load += new System.EventHandler(this.StartScreen_Load);
            this.card_mainScreen.ResumeLayout(false);
            this.bunifuCards2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCards card_mainScreen;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private Bunifu.Framework.UI.BunifuCards card_moveForm;
        private System.Windows.Forms.Label lbl_title_main_screen;
        private System.Windows.Forms.Timer timer_animation;
        private System.Windows.Forms.Label lbl_close;
        private System.Windows.Forms.Label lbl_minimize;
        private System.Windows.Forms.Label lbl_maximize;
        private System.Windows.Forms.Label lbl_settings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_play;
        private System.Windows.Forms.Label label1;
    }
}

