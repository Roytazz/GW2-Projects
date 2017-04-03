using Newtonsoft.Json;

namespace GuildWars2.API.Model.Achievements
{
    public class ProgressBit
    {
        [JsonProperty("type")]
        public ProgressBitType Type { get; set; }
        
        [JsonProperty("id")]
        public int ID { get; set; }
        
        [JsonProperty("text")]
        public int Text { get; set; }
    }

    public enum ProgressBitType
    {
        Text,
        Item,
        Skin,
        MiniPet
    }
}