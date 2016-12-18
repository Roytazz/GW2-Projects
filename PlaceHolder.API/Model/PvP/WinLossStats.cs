using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.PvP
{
    public class WinLossStats
    {
        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("loss")]
        public int Loss { get; set; }

        [JsonProperty("desertions")]
        public int Desertions { get; set; }

        [JsonProperty("byes")]
        public int Byes { get; set; }

        [JsonProperty("forfeits")]
        public int Forfeits { get; set; }
    }
}
