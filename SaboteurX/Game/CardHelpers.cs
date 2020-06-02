using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurX.Game
{
    public class CardHelpers
    {
        #region Enums
        public enum Gate
        {
            Up,
            Right,
            Down,
            Left,
            Middle
        }
        public enum Special
        {
            None,
            Diamond,
            Portal,
            Switch
        }
        public enum CardType
        {
            Power,
            Path,
            PathX
        }
        public enum PowerUp
        {
            Build,
            NoBuild,
        }
        #endregion

        static Random rnd = new Random(System.Environment.TickCount);
        public static Card RandomCardGenerator(int cardnumber = 1)
        {
            switch(rnd.Next(0,100))
            {
                case int n when (n<=80):
                    Card path = new Card(CardType.Path);
                    int connections = rnd.Next(1, 6);
                    for (int i = 0; i < connections; i++)
                    {
                        Gate x = (Gate)rnd.Next(0, 4);
                        Gate y = (Gate)rnd.Next(0, 4);
                        if (x == y) continue;
                        path.connections.Add(new Tuple<Gate, Gate>(x, y));
                    }
                    if (rnd.Next(0, 30) == 10)
                        path.special = (Special)rnd.Next(0, 3);
                    else
                        path.special = Special.None;
                    path.isEmpty = false;
                    path.isHidden = false;
                    return path;
                case int n when (n > 80 && n<90):
                    Card power = new Card(CardType.Power);
                    switch(rnd.Next(0,2))
                    {
                        case 0:
                            power.power = PowerUp.Build;
                            break;
                        case 1:
                            power.power = PowerUp.NoBuild;
                            break;
                    }
                    return power;
                case int n when (n >= 90):
                    Card pathx = new Card(CardType.PathX);
                    return pathx;
            }
            return null;

        }
        public static bool ContainsGate(Card card, Gate gate)
        {
            bool ok = false;
            card.connections.ForEach((con) => {
                if (con.Item1 == gate || con.Item2 == gate)
                    ok=true;
            });
            return ok;
        }
    }
}
