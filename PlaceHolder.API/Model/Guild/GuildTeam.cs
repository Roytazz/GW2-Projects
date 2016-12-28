using GuildWars2APIPlaceHolder.Model.PvP;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Guild
{
    public class GuildTeam
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("members")]
        public List<GuildTeamMember> Members { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("aggregate")]
        public WinLossStats Aggregate { get; set; }

        [JsonProperty("ladders")]
        public WinLossStats Ladders { get; set; }

        [JsonProperty("games")]
        public List<Game> Games { get; set; }

        [JsonProperty("seasons")]
        public List<GuildTeamSeason> Seasons { get; set; }
    }
}
