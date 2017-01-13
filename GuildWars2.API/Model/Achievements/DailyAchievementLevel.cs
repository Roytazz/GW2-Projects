using Newtonsoft.Json;

namespace GuildWars2API.Model.Achievements
{
    public class DailyAchievementLevel
    {
        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }
    }
}