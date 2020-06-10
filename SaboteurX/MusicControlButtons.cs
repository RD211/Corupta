using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaboteurX
{
    public partial class MusicControlButtons : UserControl
    {
        public MusicControlButtons()
        {
            InitializeComponent();
            UpdateState();
            MusicPlayerHelper.StateChanged += UpdateState;
        }

        private void UpdateState(object sender=null, EventArgs e=null)
        {
            if (!MusicPlayerHelper.GetAudioState())
            {
                lbl_sound.Text = "🔇";
            }
            else
            {
                lbl_sound.Text = "🔊";
            }
            if (!MusicPlayerHelper.GetMusicState())
            {
                lbl_music.Text = @"\";
            }
            else
            {
                lbl_music.Text = "♫";
            }
        }
        private void Lbl_sound_Click(object sender, EventArgs e)
        {
            if(MusicPlayerHelper.GetAudioState())
            {
                lbl_sound.Text = "🔇";
                MusicPlayerHelper.TurnAudioOff();
            }
            else
            {

                lbl_sound.Text = "🔊";
                MusicPlayerHelper.TurnAudioOn();
            }
        }

        private void Lbl_music_Click(object sender, EventArgs e)
        {
            if (MusicPlayerHelper.GetMusicState())
            {
                MusicPlayerHelper.TurnMusicOff();
                MusicPlayerHelper.PauseThemeSong();
                lbl_music.Text = @"\";
            }
            else
            {
                MusicPlayerHelper.TurnMusicOn();
                MusicPlayerHelper.PlayThemeSong();
                lbl_music.Text = "♫";
            }
        }

    }
}
