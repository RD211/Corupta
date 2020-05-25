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
        public enum Orientation
        {
            Angle0,
            Angle90,
            Angle180,
            Angle270,
        };
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

        public static Card RandomCardGenerator()
        {
            Random rnd = new Random();
            switch(rnd.Next(0,2))
            {
                case 0:
                    Card path = new Card(CardType.Path);
                    int connections = rnd.Next(1, 6);
                    for (int i = 0; i < connections; i++)
                    {
                        Gate x = (Gate)rnd.Next(0, 4);
                        Gate y = (Gate)rnd.Next(0, 4);
                        path.connections.Add(new Tuple<Gate, Gate>(x, y));
                    }
                    if (rnd.Next(0, 30) == 10)
                        path.special = (Special)rnd.Next(0, 3);
                    else
                        path.special = Special.None;
                    path.isEmpty = false;
                    path.isHidden = false;
                    return path;
                case 1:
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
            }
            return null;

        }
    }
}
