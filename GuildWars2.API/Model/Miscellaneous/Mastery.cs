using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Miscellaneous
{
    public class Mastery
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("requirement")]
        public string Requirement { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("levels")]
        public List<MasteryLevel> Levels { get; set; }
    }
}
