using Newtonsoft.Json;

namespace GuildWars2API.Model.Character
{
    public class WvWAbilities
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}