namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using SaboteurX;

    public partial class LobbyModel
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("messages")]
        public List<string> Messages { get; set; }

        [JsonProperty("moves")]
        public List<string> Moves { get; set; }

        [JsonProperty("players")]
        public List<string> Players { get; set; }

        [JsonProperty("started")]
        public bool Started { get; set; }
        [JsonProperty("host")]
        public string Host { get; set; }

    }
}
