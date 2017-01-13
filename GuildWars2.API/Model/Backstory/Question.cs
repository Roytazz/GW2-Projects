using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Backstory
{
    public class Question
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("answers")]
        public List<string> Answers { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("professions")]
        public List<Profession> Professions { get; set; }

        [JsonProperty("races")]
        public List<Race> Races { get; set; }
    }
}
