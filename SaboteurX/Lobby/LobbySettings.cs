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

            this.num_archeolog.Value = settings.archeolog;
            this.num_miner.Value = settings.miner;
            this.num_saboteur.Value = settings.saboteur;

            this.num_height.Value = settings.height;
            this.num_width.Value = settings.width;

            this.num_start_x.Value = settings.startingPoint.X;
            this.num_start_y.Value = settings.startingPoint.Y;
            this.num_total.Value = settings.remainingCards;
            this.num_diamonds.Value = settings.diamondsNeeded;
        }

        private void lbl_save_Click(object sender, EventArgs e)
        {
            this.settings.width = (int)num_width.Value;
            this.settings.height = (int)num_height.Value;

            this.settings.startingPoint = new Point((int)num_start_x.Value, (int)num_start_y.Value);
            this.settings.remainingCards = (int)num_total.Value;
            this.settings.diamondsNeeded = (int)num_diamonds.Value;

            this.settings.miner = (int)num_miner.Value;
            this.settings.saboteur = (int)num_saboteur.Value;
            this.settings.archeolog = (int)num_archeolog.Value;
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
    }
}
