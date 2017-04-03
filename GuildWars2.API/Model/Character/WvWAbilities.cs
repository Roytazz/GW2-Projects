using Newtonsoft.Json;

namespace GuildWars2.API.Model.Character
{
    public class WvWAbilities
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}