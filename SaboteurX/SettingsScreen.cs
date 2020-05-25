using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SaboteurX
{
    public partial class SettingsScreen : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        PlayerInformation information = new PlayerInformation("", new bool[25, 25]);
        Label selectedLabel;
        public SettingsScreen()
        {
            InitializeComponent();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
        }
        private void LabelZoomOut(object sender, EventArgs e)
        {
            ((Label)sender).Font = new Font(((Label)sender).Font.Name, ((Label)sender).Font.Size - 1);
        }
        private void LabelZoomIn(object sender, EventArgs e)
        {
            ((Label)sender).Font = new Font(((Label)sender).Font.Name, ((Label)sender).Font.Size + 1);
        }

        void UpdateAvatarImage()
        {
            Bitmap bmp = information.GetPictureBitmap(600,600);
            Graphics g = Graphics.FromImage(bmp);
            Pen pn = new Pen(Color.Chartreuse,1);
            for(int j = 0;j<15;j++)
            {
                g.DrawLine(pn, j * (600f / 15f), 0f, j * (600f / 15f), 600-1);
                g.DrawLine(pn, 0f, j * (600f / 15f), 600 - 1, j * (600f / 15f));
            }
            g.DrawLine(pn, 600-1, 0, 600-1, 600);
            g.DrawLine(pn, 0, 600 - 1, 600 , 600-1);

            this.pbox_avatar.Image = bmp;
        }
        private void SettingsScreen_Load(object sender, EventArgs e)
        {
            lbl_settings.Text = lbl_settings.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.lbl_name_here.Text = this.lbl_name_here.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.lbl_settings.Text = this.lbl_settings.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.lbl_name_title.Text = this.lbl_name_title.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.lbl_avatar_title.Text = this.lbl_avatar_title.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.lbl_save.Text = this.lbl_save.Tag.ToString().Split(';')[0].ToAsciiArt();
            selectedLabel = lbl_name_here;
            if(File.Exists("settings"))
            {
                information = new PlayerInformation(File.ReadAllText("settings"));
                txt_name.Text = information.name;
            }
            UpdateAvatarImage();

        }
        private void lbl_maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void card_moveForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void lbl_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void lbl_close_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            List<string> stringsToReplace = new List<string>();
            foreach(var c in txt_name.Text)
            {
                if (!TextToAsciiArtConverter.BigFontDictionary.ContainsKey(c))
                    stringsToReplace.Add(c.ToString());
            }
            stringsToReplace.ForEach((s) => txt_name.Text=txt_name.Text.Replace(s, string.Empty));
            this.lbl_name_here.Tag = $"{txt_name.Text};NO";
            this.lbl_name_here.Text = this.lbl_name_here.Tag.ToString().Split(';')[0].ToAsciiArt();
        }

        private void pbox_avatar_Click(object sender, EventArgs e)
        {
            information.picture[(int)(((MouseEventArgs)e).X*2 / (600f / 15f)), (int)(((MouseEventArgs)e).Y*2 / (600f / 15f))] 
                = !information.picture[(int)(((MouseEventArgs)e).X*2 / (600f / 15f)), (int)(((MouseEventArgs)e).Y*2 / (600f / 15f))];
            UpdateAvatarImage();
        }
        private void SelectLabelEvent(object sender, EventArgs e)
        {
            this.selectedLabel.Text = this.selectedLabel.Tag.ToString().Split(';')[0].ToAsciiArt();
            this.selectedLabel = (Label)sender;
            timer_animation_Tick(null, null);
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

        private void lbl_save_MouseLeave(object sender, EventArgs e)
        {
            SelectLabelEvent(this.lbl_name_here, null);
        }

        private void lbl_save_Click(object sender, EventArgs e)
        {
            var info = new PlayerInformation(txt_name.Text, information.picture);

            var frm = new DialogScreen("Yes", "No", "Are you sure");
            this.Hide();
            if(frm.ShowDialog() == DialogResult.Yes)
            {
                File.WriteAllText("settings", info.ToCompressedString());
            }
            this.Show();
        }
    }
}
