using Newtonsoft.Json;

namespace GuildWars2.API.Model.Guild
{
    public class GuildDetailsOld
    {
        [JsonProperty("guild_id")]
        public string ID { get; set; }

        [JsonProperty("guild_name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("emblem")]
        public GuildEmblemOld Emblem { get; set; }
    }
    
    public class GuildDetails
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("member_count")]
        public string MemberCount { get; set; }

        [JsonProperty("member_capacity")]
        public string MemberCapacity { get; set; }

        [JsonProperty("emblem")]
        public GuildEmblem Emblem { get; set; }
    }
}
