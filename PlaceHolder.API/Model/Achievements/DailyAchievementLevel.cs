using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Achievements
{
    public class DailyAchievementLevel
    {
        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }
    }
}