﻿namespace SaboteurX
{
    partial class GameSelectorScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSelectorScreen));
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_maximize = new System.Windows.Forms.Label();
            this.lbl_minimize = new System.Windows.Forms.Label();
            this.lbl_close = new System.Windows.Forms.Label();
            this.card_moveForm = new Bunifu.Framework.UI.BunifuCards();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_join = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_create_lobby = new System.Windows.Forms.Label();
            this.lbl_lobby_title = new System.Windows.Forms.Label();
            this.bunifuCards2.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
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
            this.bunifuCards2.Location = new System.Drawing.Point(895, 0);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(188, 51);
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
            this.card_moveForm.TabIndex = 8;
            this.card_moveForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.card_moveForm_MouseDown);
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
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.lbl_join);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.lbl_create_lobby);
            this.bunifuCards1.Controls.Add(this.lbl_lobby_title);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 45);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(1083, 670);
            this.bunifuCards1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.label3.ForeColor = System.Drawing.Color.Chartreuse;
            this.label3.Location = new System.Drawing.Point(3, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 367);
            this.label3.TabIndex = 13;
            this.label3.Tag = "Join;NO";
            this.label3.Text = "    __\r\n   / /\r\n  / / \r\n < <  \r\n  \\ \\ \r\n   \\_\\\r\n      \r\n      ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(0, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1080, 33);
            this.label2.TabIndex = 12;
            this.label2.Tag = "off";
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------------------------------";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_join
            // 
            this.lbl_join.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.lbl_join.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_join.Location = new System.Drawing.Point(895, 141);
            this.lbl_join.Name = "lbl_join";
            this.lbl_join.Size = new System.Drawing.Size(185, 367);
            this.lbl_join.TabIndex = 10;
            this.lbl_join.Tag = "Join;NO";
            this.lbl_join.Text = " __   \r\n \\ \\  \r\n  \\ \\ \r\n   > >\r\n  / / \r\n /_/  \r\n      \r\n      ";
            this.lbl_join.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_join.Click += new System.EventHandler(this.lbl_join_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(0, 497);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1083, 33);
            this.label1.TabIndex = 11;
            this.label1.Tag = "off";
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "------------------------------------------------------------------------------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_create_lobby
            // 
            this.lbl_create_lobby.BackColor = System.Drawing.Color.Transparent;
            this.lbl_create_lobby.Font = new System.Drawing.Font("Consolas", 9.25F);
            this.lbl_create_lobby.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_create_lobby.Location = new System.Drawing.Point(0, 530);
            this.lbl_create_lobby.Name = "lbl_create_lobby";
            this.lbl_create_lobby.Size = new System.Drawing.Size(1080, 140);
            this.lbl_create_lobby.TabIndex = 10;
            this.lbl_create_lobby.Tag = "Create Lobby;NO";
            this.lbl_create_lobby.Text = resources.GetString("lbl_create_lobby.Text");
            this.lbl_create_lobby.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_create_lobby.Click += new System.EventHandler(this.lbl_create_lobby_Click);
            // 
            // lbl_lobby_title
            // 
            this.lbl_lobby_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_lobby_title.Font = new System.Drawing.Font("Consolas", 10.25F);
            this.lbl_lobby_title.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_lobby_title.Location = new System.Drawing.Point(0, 9);
            this.lbl_lobby_title.Name = "lbl_lobby_title";
            this.lbl_lobby_title.Size = new System.Drawing.Size(1080, 111);
            this.lbl_lobby_title.TabIndex = 7;
            this.lbl_lobby_title.Tag = "Lobbies;NO";
            this.lbl_lobby_title.Text = resources.GetString("lbl_lobby_title.Text");
            this.lbl_lobby_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameSelectorScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 714);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.bunifuCards2);
            this.Controls.Add(this.card_moveForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameSelectorScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameSelectorScreen";
            this.Load += new System.EventHandler(this.GameSelectorScreen_Load);
            this.bunifuCards2.ResumeLayout(false);
            this.bunifuCards1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private System.Windows.Forms.Label lbl_maximize;
        private System.Windows.Forms.Label lbl_minimize;
        private System.Windows.Forms.Label lbl_close;
        private Bunifu.Framework.UI.BunifuCards card_moveForm;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label lbl_lobby_title;
        private System.Windows.Forms.Label lbl_create_lobby;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_join;
    }
}