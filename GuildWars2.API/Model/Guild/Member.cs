using Newtonsoft.Json;
using System;

namespace GuildWars2API.Model.Guild
{
    public class Member
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public string RankName { get; set; }
        
        [JsonProperty("joined")]
        public DateTime Joined { get; set; } 
    }
}
