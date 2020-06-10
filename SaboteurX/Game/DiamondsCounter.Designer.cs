namespace SaboteurX.Game
{
    partial class DiamondsCounter
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
            this.pbox_diamond = new System.Windows.Forms.PictureBox();
            this.lbl_counter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_diamond)).BeginInit();
            this.SuspendLayout();
            // 
            // pbox_diamond
            // 
            this.pbox_diamond.Image = global::SaboteurX.Properties.Resources.Diamond;
            this.pbox_diamond.Location = new System.Drawing.Point(0, 0);
            this.pbox_diamond.Name = "pbox_diamond";
            this.pbox_diamond.Size = new System.Drawing.Size(42, 42);
            this.pbox_diamond.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_diamond.TabIndex = 0;
            this.pbox_diamond.TabStop = false;
            // 
            // lbl_counter
            // 
            this.lbl_counter.Font = new System.Drawing.Font("Consolas", 15.25F);
            this.lbl_counter.Location = new System.Drawing.Point(42, 0);
            this.lbl_counter.Name = "lbl_counter";
            this.lbl_counter.Size = new System.Drawing.Size(70, 42);
            this.lbl_counter.TabIndex = 1;
            this.lbl_counter.Text = "10/10";
            this.lbl_counter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DiamondsCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.Controls.Add(this.lbl_counter);
            this.Controls.Add(this.pbox_diamond);
            this.Name = "DiamondsCounter";
            this.Size = new System.Drawing.Size(112, 42);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_diamond)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbox_diamond;
        private System.Windows.Forms.Label lbl_counter;
    }
}
