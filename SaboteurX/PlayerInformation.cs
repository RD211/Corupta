using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurX
{
    public class PlayerInformation
    {
        public string name;
        public bool[,] picture = new bool[15, 15];
        public PlayerInformation(string name, bool[,] picture)
        {
            this.name = name;
            this.picture = picture;
        }
        public PlayerInformation(string compressed)
        {
            var saved = compressed.Split(';');
            this.name = saved[0];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    picture[i, j] = bool.Parse(saved[i * 15 + j + 1]);
                }
            }
        }
        public Bitmap GetPictureBitmap()
        {
            Bitmap bmp = new Bitmap(600, 600);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(Color.DarkGreen), 0, 0, 600, 600);
            Pen pn = new Pen(Color.Chartreuse, 1);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (picture[i, j])
                    {
                        g.FillRectangle(blackBrush, i * (600f / 15f), j * (600f / 15f), 600f / 15f, 600f / 15f);
                    }
                }
            }
            return bmp;
        }
        public string ToCompressedString()
        {
            string settings = name;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    settings += ";" + picture[i, j];
                }
            }
            return settings;
        }

    }
}
