using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Backstory
{
    public class Awnser
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("journal")]
        public string Journal { get; set; }

        [JsonProperty("question")]
        public int Question { get; set; }

        [JsonProperty("professions")]
        public List<Profession> Professions { get; set; }

        [JsonProperty("races")]
        public List<Race> Races { get; set; }
    }
}
