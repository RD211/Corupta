using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaboteurX
{
    public partial class LobbySettings : Form
    {
        public LobbySettingsModel settings;
        Label selectedLabel = null;
        public LobbySettings()
        {
            InitializeComponent();
        }
        public LobbySettings(ref LobbySettingsModel settings)
        {
            this.settings = settings;
            InitializeComponent();
        }

        private void LobbySettings_Load(object sender, EventArgs e)
        {
            lbl_settings.Text = "Settings".ToAsciiArt();
            lbl_save.Text = "Save".ToAsciiArt();

            this.num_archeolog.Value = settings.Archeolog;
            this.num_miner.Value = settings.Miner;
            this.num_saboteur.Value = settings.Saboteur;

            this.num_height.Value = settings.Height;
            this.num_width.Value = settings.Width;

            this.num_start_x.Value = settings.StartingPoint.X;
            this.num_start_y.Value = settings.StartingPoint.Y;
            this.num_total.Value = settings.RemainingCards;
            this.num_diamonds.Value = settings.DiamondsNeeded;
        }

        private void lbl_save_Click(object sender, EventArgs e)
        {
            this.settings.Width = (int)num_width.Value;
            this.settings.Height = (int)num_height.Value;

            this.settings.StartingPoint = new Point((int)num_start_x.Value, (int)num_start_y.Value);
            this.settings.RemainingCards = (int)num_total.Value;
            this.settings.DiamondsNeeded = (int)num_diamonds.Value;

            this.settings.Miner = (int)num_miner.Value;
            this.settings.Saboteur = (int)num_saboteur.Value;
            this.settings.Archeolog = (int)num_archeolog.Value;
            this.Close();
        }

        private void num_width_ValueChanged(object sender, EventArgs e)
        {
            num_start_x.Maximum = num_width.Value;
        }

        private void num_height_ValueChanged(object sender, EventArgs e)
        {
            num_start_y.Maximum = num_height.Value;
        }

        private void timer_animation_Tick(object sender, EventArgs e)
        {
            if (selectedLabel != null)
            {
                if (selectedLabel.Tag.ToString().Split(';')[1] == "NO")
                {
                    selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";YES";
                    selectedLabel.Text = ("-" + selectedLabel.Tag.ToString().Split(';')[0] + "-").ToAsciiArt();
                }
                else
                {
                    selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";NO";
                    selectedLabel.Text = (selectedLabel.Tag.ToString().Split(';')[0]).ToAsciiArt();
                }
            }
        }

        private void lbl_save_MouseEnter(object sender, EventArgs e)
        {
            selectedLabel = (Label)sender;
            selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";YES";
            selectedLabel.Text = ("-" + selectedLabel.Tag.ToString().Split(';')[0] + "-").ToAsciiArt();
        }

        private void lbl_save_MouseLeave(object sender, EventArgs e)
        {
            selectedLabel.Tag = selectedLabel.Tag.ToString().Split(';')[0] + ";NO";
            selectedLabel.Text = (selectedLabel.Tag.ToString().Split(';')[0]).ToAsciiArt();
            selectedLabel = null;
        }
    }
}
