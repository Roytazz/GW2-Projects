using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.PvP
{
    public class Standings
    {
        [JsonProperty("current")]
        public StandingsInfo Current { get; set; }

        [JsonProperty("best")]
        public StandingsInfo Best { get; set; }

        [JsonProperty("season_id")]
        public string SeasonID { get; set; }
    }
}
