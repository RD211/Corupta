using Newtonsoft.Json;
using SaboteurX.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using static SaboteurX.Game.CardHelpers;

namespace SaboteurX.Game
{
    public class Card
    {
        public static int Width = 100, Height = 100;

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
                        g.FillRectangle(new SolidBrush(Color.Black), 0, 0, Width, Height);
                        g.DrawRectangle(new Pen(Color.FromArgb(100, Color.LimeGreen), 3), 1, 1, Width - 1, Height - 1);
                        connections.ForEach((con) =>
                        {
                            var left = con.Item1;
                            if (left != Gate.Middle)
                            {
                                left = (Gate)(((int)left + (int)orientation) % 4);
                            }
                            var right = con.Item2;
                            if (right != Gate.Middle)
                            {
                                right = (Gate)(((int)right + (int)orientation) % 4);
                            }
                            con = new Tuple<Gate, Gate>(left, right);
                            PointF start = FromGateToPointF(left);
                            PointF end = FromGateToPointF(right);
                            Pen pn = new Pen(Color.DarkGreen, 20);
                            g.DrawLine(pn, start, end);
                        });
                        switch (special)
                        {
                            case Special.Diamond:
                                g.DrawPolygon(new Pen(Color.Red), new PointF[] { new PointF(Width/2-15,Height/2), new PointF(Width/2 + 15, Height / 2),
                             new PointF(Width/2,Height/2+15), new PointF(Width/2,Height/2-15) });
                                break;
                            case Special.Portal:
                                g.FillEllipse(new SolidBrush(Color.Pink), Width / 2 - 5, Height / 2 - 5, 10, 10);
                                break;
                            case Special.Switch:

                                break;
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
                        }
                        break;
                }
                return tmp;

            } }

        [JsonProperty("type")]
        public CardType type;
        [JsonProperty("power")]
        public PowerUp power;
        [JsonProperty("orientation")]
        public Orientation orientation;
        [JsonProperty("connections")]
        public List<Tuple<Gate, Gate>> connections = new List<Tuple<Gate, Gate>>();
        [JsonProperty("special")]
        public Special special;
        [JsonProperty("empty")]
        public bool isEmpty = true;
        [JsonProperty("hidden")]
        public bool isHidden = false;
        public Card(List<Tuple<Gate,Gate>> connections, Orientation orientation, Special special)
        {
            this.connections = connections;
            this.orientation = orientation;
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
        }

    }
}
