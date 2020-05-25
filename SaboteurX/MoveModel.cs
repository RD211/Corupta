using Newtonsoft.Json;
using SaboteurX.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaboteurX
{
    public partial class MoveModel
    {
        [JsonProperty("card")]
        public Card card { get; set; }
        [JsonProperty("destination")]
        public string destination { get; set; }

        public MoveModel(Card card, string destination)
        {
            this.card = card;
            this.destination = destination;
        }
    }
}
