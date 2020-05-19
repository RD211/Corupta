namespace SaboteurX
{
    partial class DialogScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogScreen));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.lbl_question = new System.Windows.Forms.Label();
            this.lbl_right = new System.Windows.Forms.Label();
            this.lbl_left = new System.Windows.Forms.Label();
            this.timer_animation = new System.Windows.Forms.Timer(this.components);
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.DarkGreen;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.DarkGreen;
            this.bunifuCards1.Controls.Add(this.lbl_left);
            this.bunifuCards1.Controls.Add(this.lbl_right);
            this.bunifuCards1.Controls.Add(this.lbl_question);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(655, 333);
            this.bunifuCards1.TabIndex = 8;
            // 
            // lbl_question
            // 
            this.lbl_question.BackColor = System.Drawing.Color.Transparent;
            this.lbl_question.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_question.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_question.Location = new System.Drawing.Point(0, 58);
            this.lbl_question.Name = "lbl_question";
            this.lbl_question.Size = new System.Drawing.Size(652, 111);
            this.lbl_question.TabIndex = 7;
            this.lbl_question.Tag = "Question;NO";
            this.lbl_question.Text = resources.GetString("lbl_question.Text");
            this.lbl_question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_right
            // 
            this.lbl_right.BackColor = System.Drawing.Color.Transparent;
            this.lbl_right.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_right.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_right.Location = new System.Drawing.Point(316, 212);
            this.lbl_right.Name = "lbl_right";
            this.lbl_right.Size = new System.Drawing.Size(336, 111);
            this.lbl_right.TabIndex = 8;
            this.lbl_right.Tag = "No;NO";
            this.lbl_right.Text = resources.GetString("lbl_right.Text");
            this.lbl_right.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_right.Click += new System.EventHandler(this.lbl_right_Click);
            this.lbl_right.MouseEnter += new System.EventHandler(this.lbl_right_MouseEnter);
            // 
            // lbl_left
            // 
            this.lbl_left.BackColor = System.Drawing.Color.Transparent;
            this.lbl_left.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_left.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_left.Location = new System.Drawing.Point(0, 212);
            this.lbl_left.Name = "lbl_left";
            this.lbl_left.Size = new System.Drawing.Size(310, 111);
            this.lbl_left.TabIndex = 9;
            this.lbl_left.Tag = "Yes;NO";
            this.lbl_left.Text = resources.GetString("lbl_left.Text");
            this.lbl_left.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_left.Click += new System.EventHandler(this.lbl_left_Click);
            this.lbl_left.MouseEnter += new System.EventHandler(this.lbl_left_MouseEnter);
            // 
            // timer_animation
            // 
            this.timer_animation.Enabled = true;
            this.timer_animation.Interval = 500;
            this.timer_animation.Tick += new System.EventHandler(this.timer_animation_Tick);
            // 
            // DialogScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 332);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogScreen";
            this.bunifuCards1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label lbl_question;
        private System.Windows.Forms.Label lbl_left;
        private System.Windows.Forms.Label lbl_right;
        private System.Windows.Forms.Timer timer_animation;
    }
}