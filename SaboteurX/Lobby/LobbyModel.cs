namespace QuickType
{
    using System.Collections.Generic;
    using System.Drawing;
    using Newtonsoft.Json;
    using SaboteurX;
    using SaboteurX.Game;
    using static SaboteurX.Game.CardHelpers;

    public partial class LobbyModel
    {
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("messages")]
        public List<string> Messages { get; set; }
        [JsonProperty("moves")]
        public List<MoveModel> Moves { get; set; }
        [JsonProperty("players")]
        public List<string> Players { get; set; }
        [JsonProperty("started")]
        public bool Started { get; set; }
        [JsonProperty("host")]
        public string Host { get; set; }
        [JsonProperty("cards")]
        public List<List<Card>> cards { get; set; }
        [JsonProperty("currentPlayer")]
        public int currentPlayer { get; set; }
        [JsonProperty("remainingCards")]
        public int remainingCards { get; set; }
        [JsonProperty("roles")]
        public List<int> roles { get; set; }
        [JsonProperty("effects")]
        public Dictionary<string, PowerUp> effects { get; set; }
        [JsonProperty("target")]
        public int indexOfTarget { get; set; }
        [JsonProperty("discardsLeft")]
        public int discardsLeft { get; set; }
        [JsonProperty("start")]
        public Point startingPoint { get; set; }
        [JsonProperty("width")]
        public int width { get; set; }
        [JsonProperty("height")]
        public int height { get; set; }
        [JsonProperty("diamondsNeeded")]
        public int diamondsNeeded { get; set; }

        public LobbyModel()
        {
            this.Active = false;
            this.Messages = new List<string>();
            this.Moves = new List<MoveModel>();
            this.Players = new List<string>();
            this.cards = new List<List<Card>>();
            this.roles = new List<int>();
            this.effects = new Dictionary<string, PowerUp>();
            this.startingPoint = new Point(5,5);
            width = 30;
            height = 30;
            indexOfTarget = 0;
            discardsLeft = 0;
            diamondsNeeded = 3;
            remainingCards = 100;
        }

    }
}
