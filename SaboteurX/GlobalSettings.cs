using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SaboteurX
{
    public static class GlobalSettings
    {
        public static Color mainColor = Color.DarkGreen;
        public static Color secondaryColor = Color.Chartreuse;
        public static Color textColor = Color.Chartreuse;
        public static Color boardColor = Color.Black;
        public static Color pathColor = Color.Green;

        public static void GetFromFile()
        {
            try
            {
                if (File.Exists("colors.txt"))
                {
                    var fileContents = File.ReadAllText("colors.txt");
                    

                    var main = Regex.Split(Regex.Split(fileContents,"<mainColor>")[1],"</mainColor>")[0].Split(',');
                    var secondary = Regex.Split(Regex.Split(fileContents, "<secondaryColor>")[1], "</secondaryColor>")[0].Split(',');
                    var text = Regex.Split(Regex.Split(fileContents, "<textColor>")[1], "</textColor>")[0].Split(',');
                    var board = Regex.Split(Regex.Split(fileContents, "<boardColor>")[1], "</boardColor>")[0].Split(',');
                    var path = Regex.Split(Regex.Split(fileContents, "<pathColor>")[1], "</pathColor>")[0].Split(',');

                    mainColor = Color.FromArgb(int.Parse(main[0]), int.Parse(main[1]), int.Parse(main[2]));
                    secondaryColor = Color.FromArgb(int.Parse(secondary[0]), int.Parse(secondary[1]), int.Parse(secondary[2]));
                    textColor = Color.FromArgb(int.Parse(text[0]), int.Parse(text[1]), int.Parse(text[2]));
                    boardColor = Color.FromArgb(int.Parse(board[0]), int.Parse(board[1]), int.Parse(board[2]));
                    pathColor = Color.FromArgb(int.Parse(path[0]), int.Parse(path[1]), int.Parse(path[2]));
                }
            }
            catch { MessageBox.Show("Dumb format for colors.txt"); }
        }
        public static void ChangeFormColor(this Control control)
        {
            control.Controls.OfType<Control>().ToList().ForEach((control1) =>
            {
                if (control1.ForeColor == Color.DarkGreen)
                {
                    control1.ForeColor = mainColor;
                }
                else if (control1.ForeColor == Color.Chartreuse)
                {
                    control1.ForeColor = secondaryColor;
                }
                else if (control1.ForeColor == Color.Black)
                {
                    control1.ForeColor = textColor;
                }

                if (control1.BackColor == Color.DarkGreen)
                {
                    control1.BackColor = mainColor;
                }
                else if (control1.BackColor == Color.Chartreuse)
                {
                    control1.BackColor = secondaryColor;
                }
                else if (control1.BackColor == Color.Black)
                {
                    control1.BackColor = textColor;
                }
                control1.ChangeFormColor();
            });
        }
    }
}
