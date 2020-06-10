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
        }
        public enum CardType
        {
            Power,
            Path,
            PathX,
        }
        public enum PowerUp
        {
            Build,
            NoBuild,
            Switch,
            Map
        }
        #endregion

        static readonly Random rnd = new Random(System.Environment.TickCount);
        public static Card RandomCardGenerator()
        {
            switch(rnd.Next(0,100))
            {
                case int n when (n<=70):
                    Card path = new Card(CardType.Path);
                    int connections = rnd.Next(1, 6);
                    for (int i = 0; i < connections; i++)
                    {
                        Gate x = (Gate)rnd.Next(0, 5);
                        Gate y = (Gate)rnd.Next(0, 5);
                        if (Math.Abs(x - y) == 2 && x != Gate.Middle && y != Gate.Middle) {
                            path.connections.Add(new Tuple<Gate, Gate>(x, Gate.Middle));
                            path.connections.Add(new Tuple<Gate, Gate>(y, Gate.Middle));
                        }
                        path.connections.Add(new Tuple<Gate, Gate>(x, y));
                    }
                    if (rnd.Next(0, 10) == 5)
                        path.special = (Special)rnd.Next(0, 2);
                    else
                        path.special = Special.None;
                    path.isEmpty = false;
                    path.isHidden = false;
                    return path;
                case int n when (n > 70 && n<90):
                    Card power = new Card(CardType.Power)
                    {
                        power = (PowerUp)rnd.Next(0, 4)
                    };
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
        public static int RandomRoleGenerator(ref int miner, ref int saboteur, ref int archeolog)
        {
            int sum = miner + saboteur + archeolog;
            int random = rnd.Next(0, sum);
            if (random < miner)
            {
                miner--;
                return 0;
            }
            if (random < miner + saboteur)
            {
                saboteur--;
                return 1;
            }
            archeolog--;
            return 2;
        }
    }
}
