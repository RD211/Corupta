using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Threading.Tasks;

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
        private bool changed = false;
        #endregion

        public Bitmap Image { get
            {
                if (SelectedCard != null && changed)
                    CheckIfDone();

                int realWidth = Width * WidthCell, realHeight = Height * HeightCell;
                Bitmap tmp = new Bitmap(realWidth, realHeight,System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                
                Graphics g = Graphics.FromImage(tmp);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                for(int i = 0;i<Height;i++)
                {
                    for(int j  = 0;j<Width;j++)
                    {
                        if (SelectedCard != null && IsCompatible(SelectedCard, j, i, false))
                        {
                            Bitmap bmp = new Bitmap(WidthCell, HeightCell);
                            Graphics g2 = Graphics.FromImage(bmp);
                            g2.Clear(Color.Purple);
                            tryAgain:
                            try
                            {
                                g.DrawImage(bmp, j * WidthCell, i * HeightCell, WidthCell, HeightCell);
                            }
                            catch { System.Threading.Thread.Sleep(1);goto tryAgain; }
                            bmp.Dispose();
                            g2.Dispose();
                        }
                        else
                        {
                            if(lastCardAdded==board[i,j])
                            {
                                board[i, j].SetToNew();
                            }
                            retry:
                            try
                            {
                                g.DrawImage(board[i, j].Image, j * WidthCell, i * HeightCell, WidthCell, HeightCell);
                            }
                            catch { System.Threading.Thread.Sleep(1); goto retry; }
                            if (lastCardAdded == board[i, j])
                            {
                                board[i, j].SetToOld();
                            }
                        }
                    }
                }
                changed = false;
                g.Dispose();
                GC.Collect();
                return tmp;

            } }
        public int Diamonds
        {
            get
            {
                ResetVisited();
                return Dfs(CardHelpers.Gate.Middle, startX, startY);
            }
        }


        public void ChangeAt(Card cell, int x, int y)
        {
            board[y, x] = cell;
            lastCardAdded = cell;
            changed = true;
        }
        public void SetVisible(int x, int y)
        {
            board[y, x].isHidden = false;
        }
        public void SetEndPoint(int index)
        {
            this.board[ends[index].Y, ends[index].X].special = CardHelpers.Special.Chest;
        }
        public void ResetBoard()
        {
            Parallel.ForEach(Enumerable.Range(0, Height), (i) => {
                Parallel.ForEach(Enumerable.Range(0, Width), (j) =>
                {
                    board[i, j] = new Card();
                });
            });
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
            ends.ForEach((end)=>ok = ok?ok:board[end.Y,end.X].special==CardHelpers.Special.Chest&&visited[(int)CardHelpers.Gate.Middle,end.Y,end.X]);
            return ok;
        }
        private void ResetVisited()
        {
            visited = new bool[5, Height, Width];
        }
        private int Dfs(CardHelpers.Gate gate,int x, int y)
        {
            int diamonds = 0;

            if (!visited[(int)gate, y, x]) {
            if(gate==CardHelpers.Gate.Middle && board[y,x].special==CardHelpers.Special.Diamond)
            {
                diamonds++;
            }
            board[y, x].isHidden = false;
                visited[(int)gate, y, x] = true;
                board[y, x].connections.ForEach((con) =>
                {
                    if (con.Item1 == gate)
                        diamonds+=Dfs(con.Item2, x, y);
                    if (con.Item2 == gate)
                        diamonds+=Dfs(con.Item1, x, y);
                });
                if(gate!=CardHelpers.Gate.Middle)
                {
                    int nx = x + addX[(int)gate];
                    int ny = y + addY[(int)gate];
                    if (!(nx >= Width || ny >= Height || nx < 0 || ny < 0))
                    {
                        CardHelpers.Gate correspondingGate = (CardHelpers.Gate)(((int)gate + 2) % 4);
                        if (CardHelpers.ContainsGate(board[ny, nx], correspondingGate))
                        {
                            diamonds+=Dfs(correspondingGate, nx, ny);
                        }
                    }
                }
            }
            return diamonds;
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
