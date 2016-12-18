using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.PvP
{
    public class Stats
    {
        [JsonProperty("pvp_rank")]
        public int PvPRank { get; set; }

        [JsonProperty("pvp_rank_points")]
        public int PvPRankPoints { get; set; }

        [JsonProperty("pvp_rank_rollover")]
        public int PvPRankRollovers { get; set; }

        [JsonProperty("aggregate")]
        public WinLossStats Aggregate { get; set; }

        [JsonProperty("professions")]
        public Dictionary<Profession, WinLossStats> Professions { get; set; }

        [JsonProperty("ladders")]
        public Dictionary<PvPMode, WinLossStats> Ladders { get; set; }
    }
}
