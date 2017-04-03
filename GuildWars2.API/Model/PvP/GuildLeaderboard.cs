using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.API.Model.PvP
{
    public class GuildLeaderboard : BaseLeaderboard
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("team_id")]
        public int TeamID { get; set; }
    }
}
