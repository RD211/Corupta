namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
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
        public LobbyModel()
        {
            this.Active = false;
            this.Messages = new List<string>();
            this.Moves = new List<MoveModel>();
            this.Players = new List<string>();
            this.cards = new List<List<Card>>();
            this.roles = new List<int>();
            this.effects = new Dictionary<string, PowerUp>();
        }

    }
}
