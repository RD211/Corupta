using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaboteurX
{
    public partial class DialogScreen : Form
    {
        string leftAnswer, rightAnswer, question;
        Label selectedLabel;
        private void lbl_left_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void lbl_right_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void timer_animation_Tick(object sender, EventArgs e)
        {
            var tag = selectedLabel.Tag.ToString().Split(';');
            if (tag[1] == "NO")
            {
                selectedLabel.Text = ("-" + tag[0] + "-").ToAsciiArt();
                selectedLabel.Tag = tag[0] + ";YES";
            }
            else
            {
                selectedLabel.Text = (tag[0]).ToAsciiArt();
                selectedLabel.Tag = tag[0] + ";NO";
            }
        }

        private void lbl_left_MouseEnter(object sender, EventArgs e)
        {
            this.selectedLabel.Text = this.selectedLabel.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.selectedLabel = (Label)sender;
            timer_animation_Tick(null, null);
        }

        private void lbl_right_MouseEnter(object sender, EventArgs e)
        {
            this.selectedLabel.Text = this.selectedLabel.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.selectedLabel = (Label)sender;
            timer_animation_Tick(null, null);
        }

        public DialogScreen(string leftAnswer, string rightAnswer, string question)
        {
            InitializeComponent();
            selectedLabel = lbl_left;
            this.leftAnswer = leftAnswer;
            this.rightAnswer = rightAnswer;
            this.question = question;
            this.lbl_left.Tag = $"{leftAnswer};{this.lbl_left.Tag.ToString().Split(';')[1]}";
            this.lbl_right.Tag = $"{rightAnswer};{this.lbl_right.Tag.ToString().Split(';')[1]}";
            this.lbl_question.Tag = $"{question};{this.lbl_question.Tag.ToString().Split(';')[1]}";
            this.lbl_left.Text = this.lbl_left.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.lbl_right.Text = this.lbl_right.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.lbl_question.Text = this.lbl_question.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
