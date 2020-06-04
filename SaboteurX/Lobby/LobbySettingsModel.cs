using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurX
{
    public partial class LobbySettingsModel
    {
        [JsonProperty("start")]
        public Point startingPoint { get; set; }
        [JsonProperty("width")]
        public int width { get; set; }
        [JsonProperty("height")]
        public int height { get; set; }
        [JsonProperty("diamondsNeeded")]
        public int diamondsNeeded { get; set; }
        [JsonProperty("remainingCards")]
        public int remainingCards { get; set; }
        public int miner { get; set; }
        public int saboteur { get; set; }
        public int archeolog { get; set; }
        public LobbySettingsModel()
        {
            startingPoint = new Point(5, 10);
            width = 30;
            height = 20;
            diamondsNeeded = 3;
            remainingCards = 100;
            miner = 3;
            saboteur = 3;
            archeolog = 2;
        }
    }
}
