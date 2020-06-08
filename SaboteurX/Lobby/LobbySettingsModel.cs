using Newtonsoft.Json;
using System.Drawing;

namespace SaboteurX
{
    public partial class LobbySettingsModel
    {
        [JsonProperty("start")]
        public Point StartingPoint { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("diamondsNeeded")]
        public int DiamondsNeeded { get; set; }
        [JsonProperty("remainingCards")]
        public int RemainingCards { get; set; }
        public int Miner { get; set; }
        public int Saboteur { get; set; }
        public int Archeolog { get; set; }
        public LobbySettingsModel()
        {
            StartingPoint = new Point(5, 10);
            Width = 30;
            Height = 20;
            DiamondsNeeded = 3;
            RemainingCards = 100;
            Miner = 3;
            Saboteur = 3;
            Archeolog = 2;
        }
    }
}
