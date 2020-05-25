using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurX.Game
{
    public class Board
    {
        public static int Width = 30, Height = 20;
        public static int WidthCell = 50, HeightCell = 50;
        Card[,] board = new Card[Height, Width];
        public Bitmap image { get
            {
                
                int realWidth = Width * WidthCell, realHeight = Height * HeightCell;
                Bitmap tmp = new Bitmap(realWidth, realHeight);
                Graphics g = Graphics.FromImage(tmp);
                g.FillRectangle(new SolidBrush(Color.Red), 0, 0, realWidth, realHeight);
                for(int i = 0;i<Height;i++)
                {
                    for(int j  = 0;j<Width;j++)
                    {
                        g.DrawImage(board[i, j].image,j * WidthCell, i * HeightCell,WidthCell,HeightCell);
                    }
                }
                return tmp;

            } }
        public void ChangeAt(Card cell, int x, int y)
        {
            board[y, x] = cell;
        }
        public Board()
        {
            for(int i = 0;i<Height;i++)
            {
                for(int j = 0;j<Width;j++)
                {
                    board[i, j] = new Card();
                }
            }
        }
    }
}
