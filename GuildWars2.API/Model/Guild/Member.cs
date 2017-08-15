using Newtonsoft.Json;
using System;

namespace GuildWars2.API.Model.Guild
{
    public class Member
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public string RankName { get; set; }
        
        [JsonProperty("joined")]
        public DateTime? Joined { get; set; } 
    }
}
