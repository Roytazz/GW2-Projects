using Newtonsoft.Json;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Server
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("population")]
        public PopulationDensity Population { get; set; }
    }

    public enum PopulationDensity
    {
        Low,
        Medium,
        High,
        VeryHigh,
        Full
    }
}
