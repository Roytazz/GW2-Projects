using Newtonsoft.Json;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class RaidEvent
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("type")]
        public RaidEventType Type { get; set; }
    }

    public enum RaidEventType
    {
        Boss,
        Checkpoint
    }
}
