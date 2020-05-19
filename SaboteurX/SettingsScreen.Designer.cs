namespace SaboteurX
{
    partial class SettingsScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsScreen));
            this.card_settings = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_save = new System.Windows.Forms.Label();
            this.lbl_avatar_title = new System.Windows.Forms.Label();
            this.lbl_vertical_divider_1 = new System.Windows.Forms.Label();
            this.lbl_horizontal_divider_1 = new System.Windows.Forms.Label();
            this.lbl_name_here = new System.Windows.Forms.Label();
            this.lbl_horizontal_divider_2 = new System.Windows.Forms.Label();
            this.lbl_name_title = new System.Windows.Forms.Label();
            this.lbl_settings = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_maximize = new System.Windows.Forms.Label();
            this.lbl_minimize = new System.Windows.Forms.Label();
            this.lbl_close = new System.Windows.Forms.Label();
            this.card_moveForm = new Bunifu.Framework.UI.BunifuCards();
            this.timer_animation = new System.Windows.Forms.Timer(this.components);
            this.pbox_avatar = new System.Windows.Forms.PictureBox();
            this.card_settings.SuspendLayout();
            this.bunifuCards2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // card_settings
            // 
            this.card_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.card_settings.BackColor = System.Drawing.Color.DarkGreen;
            this.card_settings.BorderRadius = 5;
            this.card_settings.BottomSahddow = true;
            this.card_settings.color = System.Drawing.Color.DarkGreen;
            this.card_settings.Controls.Add(this.lbl_save);
            this.card_settings.Controls.Add(this.lbl_avatar_title);
            this.card_settings.Controls.Add(this.lbl_vertical_divider_1);
            this.card_settings.Controls.Add(this.lbl_horizontal_divider_1);
            this.card_settings.Controls.Add(this.lbl_name_here);
            this.card_settings.Controls.Add(this.pbox_avatar);
            this.card_settings.Controls.Add(this.lbl_horizontal_divider_2);
            this.card_settings.Controls.Add(this.lbl_name_title);
            this.card_settings.Controls.Add(this.lbl_settings);
            this.card_settings.Controls.Add(this.txt_name);
            this.card_settings.Controls.Add(this.label2);
            this.card_settings.LeftSahddow = false;
            this.card_settings.Location = new System.Drawing.Point(0, 43);
            this.card_settings.Name = "card_settings";
            this.card_settings.RightSahddow = true;
            this.card_settings.ShadowDepth = 20;
            this.card_settings.Size = new System.Drawing.Size(951, 691);
            this.card_settings.TabIndex = 4;
            // 
            // lbl_save
            // 
            this.lbl_save.BackColor = System.Drawing.Color.Transparent;
            this.lbl_save.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_save.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_save.Location = new System.Drawing.Point(39, 596);
            this.lbl_save.Name = "lbl_save";
            this.lbl_save.Size = new System.Drawing.Size(847, 85);
            this.lbl_save.TabIndex = 15;
            this.lbl_save.Tag = "Save;NO";
            this.lbl_save.Text = resources.GetString("lbl_save.Text");
            this.lbl_save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_save.Click += new System.EventHandler(this.lbl_save_Click);
            this.lbl_save.MouseEnter += new System.EventHandler(this.SelectLabelEvent);
            this.lbl_save.MouseLeave += new System.EventHandler(this.lbl_save_MouseLeave);
            // 
            // lbl_avatar_title
            // 
            this.lbl_avatar_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_avatar_title.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_avatar_title.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_avatar_title.Location = new System.Drawing.Point(516, 153);
            this.lbl_avatar_title.Name = "lbl_avatar_title";
            this.lbl_avatar_title.Size = new System.Drawing.Size(370, 86);
            this.lbl_avatar_title.TabIndex = 14;
            this.lbl_avatar_title.Tag = "Avatar;NO";
            this.lbl_avatar_title.Text = resources.GetString("lbl_avatar_title.Text");
            this.lbl_avatar_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_vertical_divider_1
            // 
            this.lbl_vertical_divider_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_vertical_divider_1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vertical_divider_1.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_vertical_divider_1.Location = new System.Drawing.Point(457, 139);
            this.lbl_vertical_divider_1.Name = "lbl_vertical_divider_1";
            this.lbl_vertical_divider_1.Size = new System.Drawing.Size(17, 469);
            this.lbl_vertical_divider_1.TabIndex = 10;
            this.lbl_vertical_divider_1.Tag = "off";
            this.lbl_vertical_divider_1.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n" +
    "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|";
            this.lbl_vertical_divider_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_horizontal_divider_1
            // 
            this.lbl_horizontal_divider_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_horizontal_divider_1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_horizontal_divider_1.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_horizontal_divider_1.Location = new System.Drawing.Point(3, 225);
            this.lbl_horizontal_divider_1.Name = "lbl_horizontal_divider_1";
            this.lbl_horizontal_divider_1.Size = new System.Drawing.Size(945, 33);
            this.lbl_horizontal_divider_1.TabIndex = 12;
            this.lbl_horizontal_divider_1.Tag = "off";
            this.lbl_horizontal_divider_1.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------------------";
            this.lbl_horizontal_divider_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_name_here
            // 
            this.lbl_name_here.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name_here.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_name_here.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_name_here.Location = new System.Drawing.Point(69, 363);
            this.lbl_name_here.Name = "lbl_name_here";
            this.lbl_name_here.Size = new System.Drawing.Size(370, 117);
            this.lbl_name_here.TabIndex = 11;
            this.lbl_name_here.Tag = "Name;NO";
            this.lbl_name_here.Text = resources.GetString("lbl_name_here.Text");
            this.lbl_name_here.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_horizontal_divider_2
            // 
            this.lbl_horizontal_divider_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_horizontal_divider_2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_horizontal_divider_2.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_horizontal_divider_2.Location = new System.Drawing.Point(3, 120);
            this.lbl_horizontal_divider_2.Name = "lbl_horizontal_divider_2";
            this.lbl_horizontal_divider_2.Size = new System.Drawing.Size(945, 33);
            this.lbl_horizontal_divider_2.TabIndex = 8;
            this.lbl_horizontal_divider_2.Tag = "off";
            this.lbl_horizontal_divider_2.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------------------";
            this.lbl_horizontal_divider_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_name_title
            // 
            this.lbl_name_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name_title.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.lbl_name_title.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_name_title.Location = new System.Drawing.Point(69, 153);
            this.lbl_name_title.Name = "lbl_name_title";
            this.lbl_name_title.Size = new System.Drawing.Size(370, 86);
            this.lbl_name_title.TabIndex = 7;
            this.lbl_name_title.Tag = "Name;NO";
            this.lbl_name_title.Text = resources.GetString("lbl_name_title.Text");
            this.lbl_name_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_settings
            // 
            this.lbl_settings.BackColor = System.Drawing.Color.Transparent;
            this.lbl_settings.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_settings.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_settings.Location = new System.Drawing.Point(3, 9);
            this.lbl_settings.Name = "lbl_settings";
            this.lbl_settings.Size = new System.Drawing.Size(945, 111);
            this.lbl_settings.TabIndex = 6;
            this.lbl_settings.Tag = "Settings;NO";
            this.lbl_settings.Text = resources.GetString("lbl_settings.Text");
            this.lbl_settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.txt_name.Location = new System.Drawing.Point(71, 363);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(368, 117);
            this.txt_name.TabIndex = 13;
            this.txt_name.Text = "";
            this.txt_name.TextChanged += new System.EventHandler(this.txt_name_TextChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(3, 575);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(945, 33);
            this.label2.TabIndex = 16;
            this.label2.Tag = "off";
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------------------";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.bunifuCards2.Location = new System.Drawing.Point(763, -2);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(188, 51);
            this.bunifuCards2.TabIndex = 5;
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
            this.lbl_minimize.Click += new System.EventHandler(this.lbl_minimize_Click);
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
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click_1);
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
            this.card_moveForm.Location = new System.Drawing.Point(0, -2);
            this.card_moveForm.Name = "card_moveForm";
            this.card_moveForm.RightSahddow = true;
            this.card_moveForm.ShadowDepth = 20;
            this.card_moveForm.Size = new System.Drawing.Size(512, 51);
            this.card_moveForm.TabIndex = 6;
            this.card_moveForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.card_moveForm_MouseDown);
            // 
            // timer_animation
            // 
            this.timer_animation.Enabled = true;
            this.timer_animation.Interval = 500;
            this.timer_animation.Tick += new System.EventHandler(this.timer_animation_Tick);
            // 
            // pbox_avatar
            // 
            this.pbox_avatar.Location = new System.Drawing.Point(550, 272);
            this.pbox_avatar.Name = "pbox_avatar";
            this.pbox_avatar.Size = new System.Drawing.Size(300, 300);
            this.pbox_avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_avatar.TabIndex = 9;
            this.pbox_avatar.TabStop = false;
            this.pbox_avatar.Click += new System.EventHandler(this.pbox_avatar_Click);
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 733);
            this.Controls.Add(this.card_settings);
            this.Controls.Add(this.bunifuCards2);
            this.Controls.Add(this.card_moveForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsScreen";
            this.Load += new System.EventHandler(this.SettingsScreen_Load);
            this.card_settings.ResumeLayout(false);
            this.bunifuCards2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_avatar)).EndInit();
            this.ResumeLayout(false);

        }

        private void Lbl_close_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards card_settings;
        private System.Windows.Forms.Label lbl_settings;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private System.Windows.Forms.Label lbl_maximize;
        private System.Windows.Forms.Label lbl_minimize;
        private System.Windows.Forms.Label lbl_close;
        private Bunifu.Framework.UI.BunifuCards card_moveForm;
        private System.Windows.Forms.Timer timer_animation;
        private System.Windows.Forms.Label lbl_name_title;
        private System.Windows.Forms.Label lbl_horizontal_divider_1;
        private System.Windows.Forms.Label lbl_name_here;
        private System.Windows.Forms.Label lbl_vertical_divider_1;
        private System.Windows.Forms.PictureBox pbox_avatar;
        private System.Windows.Forms.Label lbl_horizontal_divider_2;
        private System.Windows.Forms.RichTextBox txt_name;
        private System.Windows.Forms.Label lbl_avatar_title;
        private System.Windows.Forms.Label lbl_save;
        private System.Windows.Forms.Label label2;
    }
}