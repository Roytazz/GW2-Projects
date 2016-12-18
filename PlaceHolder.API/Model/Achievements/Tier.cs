using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Achievements
{
    public class Tier
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }
    }
}