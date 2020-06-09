using System;
using System.Collections.Generic;
using System.Drawing;

namespace SaboteurX.Game
{
    public class Board
    {
        #region Variables
        public static int Width = 40, Height = 20;
        public static int WidthCell = 20, HeightCell = 20;
        public static int startX = 5, startY = Height/2;
        public static List<Point> ends;
        readonly Card[,] board = new Card[Height, Width];
        readonly int[] addX = new int[]{ 0, 1, 0, -1 };
        readonly int[] addY = new int[]{ -1, 0, 1, 0 };
        public Card SelectedCard { get; set; } = null;
        private Card lastCardAdded = null;
        #endregion

        public Bitmap Image { get
            {
                if (SelectedCard != null)
                    CheckIfDone();

                int realWidth = Width * WidthCell, realHeight = Height * HeightCell;
                Bitmap tmp = new Bitmap(realWidth, realHeight,System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                
                Graphics g = Graphics.FromImage(tmp);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.FillRectangle(new SolidBrush(Color.Red), 0, 0, realWidth, realHeight);
                for(int i = 0;i<Height;i++)
                {
                    for(int j  = 0;j<Width;j++)
                    {
                        if (SelectedCard != null && IsCompatible(SelectedCard, j, i, false))
                        {
                            Bitmap bmp = new Bitmap(WidthCell, HeightCell);
                            Graphics g2 = Graphics.FromImage(bmp);
                            g2.Clear(Color.Purple);
                            g.DrawImage(bmp, j * WidthCell, i * HeightCell, WidthCell, HeightCell);
                        }
                        else
                        {
                            if(lastCardAdded==board[i,j])
                            {
                                board[i, j].SetToNew();
                            }
                            g.DrawImage(board[i, j].Image, j * WidthCell, i * HeightCell, WidthCell, HeightCell);
                            if (lastCardAdded == board[i, j])
                            {
                                board[i, j].SetToOld();
                            }
                        }
                    }
                }

                return tmp;

            } }
        public int Diamonds { get{
                CheckIfDone();
                int dia = 0;
                for(int i = 0;i<Height;i++)
                    for (int j = 0; j < Width; j++)
                        if (board[i, j].special == CardHelpers.Special.Diamond 
                            && visited[(int)CardHelpers.Gate.Middle, i, j])
                            dia++;
                return dia;
            } }


        public void ChangeAt(Card cell, int x, int y)
        {
            board[y, x] = cell;
            lastCardAdded = cell;
        }
        public void SetEndPoint(int index)
        {
            this.board[ends[index].Y, ends[index].X].special = CardHelpers.Special.Portal;
        }
        public void ResetBoard()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
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
            ends.ForEach((end) =>
            {
                board[end.Y, end.X] = new Card(new List<Tuple<CardHelpers.Gate, CardHelpers.Gate>>() {
            new Tuple<CardHelpers.Gate, CardHelpers.Gate>(CardHelpers.Gate.Down,CardHelpers.Gate.Middle),
            new Tuple<CardHelpers.Gate, CardHelpers.Gate>(CardHelpers.Gate.Left,CardHelpers.Gate.Middle),
            new Tuple<CardHelpers.Gate, CardHelpers.Gate>(CardHelpers.Gate.Right,CardHelpers.Gate.Middle),
            new Tuple<CardHelpers.Gate, CardHelpers.Gate>(CardHelpers.Gate.Up,CardHelpers.Gate.Middle),
            }, CardHelpers.Special.None)
                {
                    isHidden = true
                };
            });
        }
        public Board()
        {
            ResetBoard();
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
            ends.ForEach((end)=>ok = ok?ok:board[end.Y,end.X].special==CardHelpers.Special.Portal&&visited[(int)CardHelpers.Gate.Middle,end.Y,end.X]);
            return ok;
        }
        private void ResetVisited()
        {
            visited = new bool[5, Height, Width];
        }
        private void Dfs(CardHelpers.Gate gate,int x, int y)
        {
            board[y, x].isHidden = false;
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
        public bool IsCompatible(Card cell, int x, int y,bool checkDone = true)
        {
            if (board[y, x].isEmpty == false)
                return false;
            bool isObj = IsObjective(x,y);
            if (isObj)
                return false;
            if(checkDone)
                CheckIfDone();
            bool hasOneConnection = false;
            for(int i = 0;i<4;i++)
            {
                int nx = x + addX[i];
                int ny = y + addY[i];
                if (nx >= Width || ny >= Height || nx<0||ny<0) continue;
                bool iHave = CardHelpers.ContainsGate(cell, (CardHelpers.Gate)i);
                bool heHas = CardHelpers.ContainsGate(board[ny, nx], (CardHelpers.Gate)(((int)i + 2) % 4));
                if (board[ny,nx].isEmpty==false && (iHave^heHas))
                    return false;
                if (iHave && heHas && visited[(((int)i + 2) % 4),ny,nx])
                    hasOneConnection = true;
            }
            return hasOneConnection;
        }
        public bool IsObjective(int x, int y)
        {
            bool isObj = false;
            if (x == startX && y == startY)
                isObj = true;
            ends.ForEach((end) => {
                if(end.X==x && end.Y==y)
                {
                    isObj = true;
                }
            });
            return isObj;
        }
    }
}
