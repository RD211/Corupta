using Newtonsoft.Json;
using SaboteurX.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using static SaboteurX.Game.CardHelpers;

namespace SaboteurX.Game 
{
    public class Card : ICloneable
    {
        #region Variables
        public static int Width = 100, Height = 100;
        [JsonProperty("type")]
        public CardType type;
        [JsonProperty("power")]
        public PowerUp power;
        [JsonProperty("connections")]
        public List<Tuple<Gate, Gate>> connections = new List<Tuple<Gate, Gate>>();
        [JsonProperty("special")]
        public Special special;
        [JsonProperty("empty")]
        public bool isEmpty = false;
        [JsonProperty("hidden")]
        public bool isHidden = false;

        [JsonProperty("newest")]
        public bool isNew = false;
        #endregion

        PointF FromGateToPointF(Gate gate)
        {
            var result = new PointF(0, 0);
            switch (gate)
            {
                case Gate.Up:
                    result = new PointF(Width / 2, 0);
                    break;
                case Gate.Down:
                    result = new PointF(Width / 2, Height);
                    break;
                case Gate.Left:
                    result = new PointF(0, Height / 2);
                    break;
                case Gate.Right:
                    result = new PointF(Width, Height / 2);
                    break;
                case Gate.Middle:
                    result = new PointF(Width / 2, Height / 2);
                    break;
            }
            return result;
        }
        public Bitmap image { get {
                Bitmap tmp = new Bitmap(Width, Height);
                Graphics g = Graphics.FromImage(tmp);
                switch (type)
                {
                    case CardType.Path:
                        if (isHidden)
                        {
                            g.FillRectangle(new SolidBrush(Color.Gray), 0, 0, Width, Height);
                        }
                        else
                        {
                            var brsh = new SolidBrush(Color.Black);
                            if (isNew)
                                brsh.Color = Color.FromArgb(40,40,40);
                            g.FillRectangle(brsh, 0, 0, Width, Height);
                            g.DrawRectangle(new Pen(Color.FromArgb(100, Color.LimeGreen), 3), 1, 1, Width - 1, Height - 1);
                            connections.ForEach((con) =>
                            {
                                var left = con.Item1;
                                var right = con.Item2;
                                con = new Tuple<Gate, Gate>(left, right);
                                PointF start = FromGateToPointF(left);
                                PointF end = FromGateToPointF(right);

                                Pen pn = new Pen(Color.DarkGreen, 20);
                                if (left == right)
                                {
                                    switch(left)
                                    {
                                        case Gate.Down:
                                            end.Y -= Height / 4;
                                            break;
                                        case Gate.Up:
                                            end.Y += Height / 4;
                                            break;
                                        case Gate.Left:
                                            end.X += Width / 4;
                                            break;
                                        case Gate.Right:
                                            end.X -= Width / 4;
                                            break;
                                    }
                                }
                                g.DrawLine(pn, start, end);
                                
                            });
                            switch (special)
                            {
                                case Special.Diamond:
                                    g.FillPolygon(new SolidBrush(Color.Blue),new PointF[] {new PointF(Width/10*3,Height/10*6), new PointF(Width/10*4,Height/2), new PointF(Width/10*6,Height/2), new PointF(Width/10*7,Height/10*6), new PointF(Width/2, Height/10*8), new PointF(Width / 10 * 3, Height / 10 * 6) });
                                    break;
                                case Special.Portal:
                                    g.FillEllipse(new SolidBrush(Color.Gold), Width / 2 - 10, Height / 2 - 10, 20, 20);
                                    break;
                            }
                        }
                        break;
                    case CardType.Power:
                        switch (power) {
                            case PowerUp.Build:
                                g.FillRectangle(new SolidBrush(Color.Green), Width / 2 - 20, Height / 2 - 20, 40, 40);
                                break;
                            case PowerUp.NoBuild:
                                g.FillRectangle(new SolidBrush(Color.Red), Width / 2 - 20, Height / 2 - 20, 40, 40);
                                break;
                            case PowerUp.Switch:
                                g.FillRectangle(new SolidBrush(Color.Orange), Width / 2 - 20, Height / 2 - 20, 40, 40);
                                break;
                        }
                        break;
                    case CardType.PathX:
                        Pen redPen = new Pen(Color.Red, 10);
                        g.DrawLine(redPen, 0, 0, Width, Height);
                        g.DrawLine(redPen, 0, Width, 0, Height);
                        break;
                }
                return tmp;

            } }


        #region Constructors
        public Card(List<Tuple<Gate,Gate>> connections,Special special)
        {
            this.connections = connections;
            this.special = special;
            isEmpty = false;
            type = CardType.Path;

        }
        public Card(CardType type)
        {
            this.type = type;
        }
        public Card()
        {
            this.type = CardType.Path;
            this.isEmpty = true;
        }
        #endregion

        public void Rotate()
        {
            for(int i = 0;i<connections.Count;i++)
            {
                var left = connections[i].Item1;
                var right = connections[i].Item2;
                if (left != Gate.Middle)
                    left = (Gate)(((int)left + 1) % 4);
                if (right != Gate.Middle)
                    right = (Gate)(((int)right + 1) % 4);
                connections[i] = new Tuple<Gate, Gate>(left,right);

            }
        }

        public object Clone()
        {
            Card clone = new Card
            {
                connections = new List<Tuple<Gate, Gate>>(connections),
                isEmpty = isEmpty,
                isHidden = isHidden,
                power = power,
                special = special,
                type = type
            };
            return clone;
        }
    }
}
