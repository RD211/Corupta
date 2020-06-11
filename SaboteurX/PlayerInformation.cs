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
        public static int Dimension = 20;
        public string name;
        public bool[,] picture = new bool[Dimension, Dimension];
        private Bitmap bmp;
        public PlayerInformation(string name, bool[,] picture)
        {
            this.name = name;
            this.picture = picture;
        }
        public PlayerInformation(string compressed)
        {
            var saved = compressed.Split(';');
            this.name = saved[0];
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    picture[i, j] = bool.Parse(saved[i * Dimension + j + 1]);
                }
            }
        }
        public Bitmap GetPictureBitmap(int width, int height)
        {
            bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(GlobalSettings.mainColor), 0, 0, width, height);
            SolidBrush blackBrush = new SolidBrush(GlobalSettings.secondaryColor);
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (picture[i, j])
                    {
                        g.FillRectangle(blackBrush, i * (width / (float)Dimension), j * (height / (float)Dimension), width / (float)Dimension, height / (float)Dimension);
                    }
                }
            }
            GC.Collect();
            return bmp;
        }
        public string ToCompressedString()
        {
            string settings = name;
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    settings += ";" + picture[i, j];
                }
            }
            return settings;
        }

    }
}
