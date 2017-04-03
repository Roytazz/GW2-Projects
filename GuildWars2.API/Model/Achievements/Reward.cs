using Newtonsoft.Json;

namespace GuildWars2.API.Model.Achievements
{
    public class Reward
    {
        [JsonProperty("type")]
        public RewardType Type { get; set; }
        
        [JsonProperty("id")]
        public int ID { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
       
        [JsonProperty("region")]
        public string Region { get; set; }
    }

    public enum RewardType
    {
        Coins,
        Item,
        Mastery
    }
}