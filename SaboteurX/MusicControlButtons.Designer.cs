namespace SaboteurX
{
    partial class MusicControlButtons
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_music = new System.Windows.Forms.Label();
            this.lbl_sound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_music
            // 
            this.lbl_music.Font = new System.Drawing.Font("Consolas", 20F);
            this.lbl_music.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_music.Location = new System.Drawing.Point(0, 0);
            this.lbl_music.Name = "lbl_music";
            this.lbl_music.Size = new System.Drawing.Size(40, 40);
            this.lbl_music.TabIndex = 0;
            this.lbl_music.Text = "♫";
            this.lbl_music.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_music.Click += new System.EventHandler(this.lbl_music_Click);
            // 
            // lbl_sound
            // 
            this.lbl_sound.Font = new System.Drawing.Font("Consolas", 20F);
            this.lbl_sound.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_sound.Location = new System.Drawing.Point(40, 0);
            this.lbl_sound.Name = "lbl_sound";
            this.lbl_sound.Size = new System.Drawing.Size(40, 40);
            this.lbl_sound.TabIndex = 1;
            this.lbl_sound.Tag = "🔇;🔊";
            this.lbl_sound.Text = "🔊";
            this.lbl_sound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_sound.Click += new System.EventHandler(this.lbl_sound_Click);
            // 
            // MusicControlButtons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbl_sound);
            this.Controls.Add(this.lbl_music);
            this.Name = "MusicControlButtons";
            this.Size = new System.Drawing.Size(80, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_music;
        private System.Windows.Forms.Label lbl_sound;
    }
}
