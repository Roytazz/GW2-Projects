using Newtonsoft.Json;

namespace GuildWars2API.Model.Guild
{
    public class GuildDetails
    {
        [JsonProperty("guild_id")]
        public string ID { get; set; }

        [JsonProperty("guild_name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("emblem")]
        public GuildEmblem Emblem { get; set; }
    }
}
