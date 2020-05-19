using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SaboteurX
{
    public partial class StartScreen : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        Label selectedLabel;
        public StartScreen()
        {
            InitializeComponent();
            selectedLabel = lbl_play;
            TextToAsciiArtConverter.InitializeLetters();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;

        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            lbl_play.Text = lbl_play.Tag.ToString().Split(';')[0].ToAsciiArt();
            lbl_settings.Text = lbl_settings.Tag.ToString().Split(';')[0].ToAsciiArt();
        }

        private void card_moveForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void timer_animation_Tick(object sender, EventArgs e)
        {
                var tag = selectedLabel.Tag.ToString().Split(';');
                    if(tag[1]=="NO")
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

        private void lbl_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LabelZoomOut(object sender, EventArgs e)
        {
            ((Label)sender).Font = new Font(((Label)sender).Font.Name, ((Label)sender).Font.Size - 1);
        }
        private void LabelZoomIn(object sender, EventArgs e)
        {
            ((Label)sender).Font = new Font(((Label)sender).Font.Name, ((Label)sender).Font.Size + 1);
        }

        private void lbl_maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void lbl_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SelectLabelEvent(object sender, EventArgs e)
        {
            this.selectedLabel.Text = this.selectedLabel.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.selectedLabel = (Label)sender;
            timer_animation_Tick(null, null);
        }

        private void lbl_play_Click_1(object sender, EventArgs e)
        {
            if(File.Exists("settings"))
            {
                PlayerInformation information = new PlayerInformation("",new bool[15,15]);
                var saved = File.ReadAllText("settings").Split(';');
                information.name = saved[0];
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        information.picture[i, j] = bool.Parse(saved[i * 15 + j + 1]);
                    }
                }
                var gameSelectorScreen = new GameSelectorScreen(information);
                this.Hide();
                gameSelectorScreen.ShowDialog();
                this.Show();
            }
            else
            {
                var dialog = new DialogScreen("Ok", "Quit", "You must register");
                this.Hide();
                if (dialog.ShowDialog() == DialogResult.Yes)
                {
                    var frm = new SettingsScreen();
                    this.Hide();
                    if (frm.ShowDialog() == DialogResult.OK)
                        this.Show();
                    else
                        Application.Exit();
                }
                this.Show();
            }
        }

        private void lbl_settings_Click(object sender, EventArgs e)
        {
            var frm = new SettingsScreen();
            this.Hide();
            if (frm.ShowDialog() == DialogResult.OK)
                this.Show();
            else
                Application.Exit();
        }
    }
}
