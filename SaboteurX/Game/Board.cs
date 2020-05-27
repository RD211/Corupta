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
        public static int startX = 5, startY = 5;
        private List<Point> ends = new List<Point>() { new Point(Width / 3 * 2, Height / 2), new Point(Width / 3 * 2, Height / 2 - Height / 4), new Point(Width / 3 * 2, Height / 2 + Height / 4) };
        Card[,] board = new Card[Height, Width];
        int[] addX = new int[]{ 0, 1, 0, -1 };
        int[] addY = new int[]{ -1, 0, 1, 0 };

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
            board[startY, startX] = new Card(new List<Tuple<CardHelpers.Gate, CardHelpers.Gate>>() { 
            new Tuple<CardHelpers.Gate, CardHelpers.Gate>(CardHelpers.Gate.Down,CardHelpers.Gate.Middle),
            new Tuple<CardHelpers.Gate, CardHelpers.Gate>(CardHelpers.Gate.Left,CardHelpers.Gate.Middle),
            new Tuple<CardHelpers.Gate, CardHelpers.Gate>(CardHelpers.Gate.Right,CardHelpers.Gate.Middle),
            new Tuple<CardHelpers.Gate, CardHelpers.Gate>(CardHelpers.Gate.Up,CardHelpers.Gate.Middle),
            }, CardHelpers.Special.None);
            
        }
        bool[,,] visited = new bool[5,Height, Width];
        public bool CheckIfDone()
        {
            ResetVisited();
            Dfs(CardHelpers.Gate.Middle, startX, startY);
            return CheckEnd();
        }
        private bool CheckEnd()
        {
            bool ok = false;
            this.ends.ForEach((end)=>ok = ok?ok:visited[(int)CardHelpers.Gate.Middle,end.Y,end.X]);
            return ok;
        }
        private void ResetVisited()
        {
            visited = new bool[5, Height, Width];
        }
        private void Dfs(CardHelpers.Gate gate,int x, int y)
        {
            if (!visited[(int)gate, y, x])
            {
                visited[(int)gate, y, x] = true;
                board[y, x].connections.ForEach((con) =>
                {
                    if (con.Item1 == gate)
                        Dfs(con.Item2, x, y);
                    if (con.Item2 == gate)
                        Dfs(con.Item1, x, y);
                });
                if(gate!=CardHelpers.Gate.Middle)
                {
                    int nx = x + addX[(int)gate];
                    int ny = y + addY[(int)gate];
                    CardHelpers.Gate correspondingGate = (CardHelpers.Gate)(((int)gate + 2) % 4);
                    if (CardHelpers.ContainsGate(board[ny,nx],correspondingGate))
                    {
                        Dfs(correspondingGate, nx, ny);
                    }
                }
            }
        }
        public bool IsCompatible(Card cell, int x, int y)
        {
            if (board[y, x].isEmpty == false)
                return false;
            CheckIfDone();
            bool hasOneConnection = false;
            for(int i = 0;i<4;i++)
            {
                int nx = x + addX[i];
                int ny = y + addY[i];
                bool iHave = CardHelpers.ContainsGate(cell, (CardHelpers.Gate)i);
                bool heHas = CardHelpers.ContainsGate(board[ny, nx], (CardHelpers.Gate)(((int)i + 2) % 4));
                if (board[ny,nx].isEmpty==false && (iHave^heHas))
                    return false;
                if (iHave && heHas && visited[(((int)i + 2) % 4),ny,nx])
                    hasOneConnection = true;
            }
            return hasOneConnection;
        }
    }
}
