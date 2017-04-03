using Newtonsoft.Json;

namespace GuildWars2.API.Model.Achievements
{
    public class DailyAchievement
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("level")]
        public DailyAchievementLevel Level { get; set; }
    }
}