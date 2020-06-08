using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaboteurX
{
    public partial class MusicControlButtons : UserControl
    {
        public MusicControlButtons()
        {
            InitializeComponent();
        }

        private void lbl_sound_Click(object sender, EventArgs e)
        {
            if(MusicPlayerHelper.isSoundOn)
            {
                lbl_sound.Text = "🔇";
                MusicPlayerHelper.isSoundOn = false;
            }
            else
            {

                lbl_sound.Text = "🔊";
                MusicPlayerHelper.isSoundOn = true;
            }
        }

        private void lbl_music_Click(object sender, EventArgs e)
        {
            if (MusicPlayerHelper.isMusicOn)
            {
                MusicPlayerHelper.PauseThemeSong();
                lbl_music.Text = @"\";
                MusicPlayerHelper.isMusicOn = false;
            }
            else
            {
                MusicPlayerHelper.PlayThemeSong();
                lbl_music.Text = "♫";
                MusicPlayerHelper.isMusicOn = true;
            }
        }
    }
}
