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
            this.card_moveForm = new Bunifu.Framework.UI.BunifuCards();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_maximize = new System.Windows.Forms.Label();
            this.lbl_minimize = new System.Windows.Forms.Label();
            this.lbl_close = new System.Windows.Forms.Label();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_chat_title = new System.Windows.Forms.Label();
            this.txt_chat_screen = new System.Windows.Forms.RichTextBox();
            this.lbl_send_message = new System.Windows.Forms.Label();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.pbox_game = new System.Windows.Forms.PictureBox();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.bunifuCards2.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_game)).BeginInit();
            this.SuspendLayout();
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
            this.card_moveForm.TabIndex = 6;
            this.card_moveForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.card_moveForm_MouseDown);
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
            this.bunifuCards2.Location = new System.Drawing.Point(1072, 0);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(191, 51);
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
            this.lbl_maximize.Click += new System.EventHandler(this.lbl_maximize_Click);
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
            this.lbl_close.Location = new System.Drawing.Point(129, 0);
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
            this.bunifuCards1.Size = new System.Drawing.Size(1263, 646);
            this.bunifuCards1.TabIndex = 8;
            // 
            // lbl_chat_title
            // 
            this.lbl_chat_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_chat_title.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_chat_title.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_chat_title.Location = new System.Drawing.Point(964, 4);
            this.lbl_chat_title.Name = "lbl_chat_title";
            this.lbl_chat_title.Size = new System.Drawing.Size(284, 83);
            this.lbl_chat_title.TabIndex = 8;
            this.lbl_chat_title.Tag = "off";
            this.lbl_chat_title.Text = "____";
            this.lbl_chat_title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txt_chat_screen
            // 
            this.txt_chat_screen.BackColor = System.Drawing.SystemColors.WindowText;
            this.txt_chat_screen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_chat_screen.Font = new System.Drawing.Font("Consolas", 10.25F);
            this.txt_chat_screen.ForeColor = System.Drawing.Color.Lime;
            this.txt_chat_screen.Location = new System.Drawing.Point(964, 90);
            this.txt_chat_screen.Name = "txt_chat_screen";
            this.txt_chat_screen.Size = new System.Drawing.Size(293, 508);
            this.txt_chat_screen.TabIndex = 7;
            this.txt_chat_screen.Text = "asdasd";
            // 
            // lbl_send_message
            // 
            this.lbl_send_message.BackColor = System.Drawing.Color.Transparent;
            this.lbl_send_message.Font = new System.Drawing.Font("Consolas", 20.25F);
            this.lbl_send_message.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_send_message.Location = new System.Drawing.Point(1220, 601);
            this.lbl_send_message.Name = "lbl_send_message";
            this.lbl_send_message.Size = new System.Drawing.Size(40, 27);
            this.lbl_send_message.TabIndex = 6;
            this.lbl_send_message.Tag = "off";
            this.lbl_send_message.Text = ">";
            this.lbl_send_message.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbl_send_message.Click += new System.EventHandler(this.lbl_send_message_Click);
            // 
            // txt_message
            // 
            this.txt_message.BackColor = System.Drawing.Color.Black;
            this.txt_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_message.Font = new System.Drawing.Font("Consolas", 12.25F);
            this.txt_message.ForeColor = System.Drawing.Color.Lime;
            this.txt_message.Location = new System.Drawing.Point(964, 606);
            this.txt_message.Name = "txt_message";
            this.txt_message.Size = new System.Drawing.Size(256, 27);
            this.txt_message.TabIndex = 2;
            this.txt_message.Text = "asdasd";
            this.txt_message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_message_KeyDown);
            // 
            // pbox_game
            // 
            this.pbox_game.Location = new System.Drawing.Point(0, 0);
            this.pbox_game.Name = "pbox_game";
            this.pbox_game.Size = new System.Drawing.Size(958, 537);
            this.pbox_game.TabIndex = 1;
            this.pbox_game.TabStop = false;
            // 
            // timer_update
            // 
            this.timer_update.Enabled = true;
            this.timer_update.Interval = 2000;
            this.timer_update.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 695);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.bunifuCards2);
            this.Controls.Add(this.card_moveForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameScreen";
            this.Text = "GameScreen";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.bunifuCards2.ResumeLayout(false);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
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
    }
}