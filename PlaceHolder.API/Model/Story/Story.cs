using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Story
{
    public class Story
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("timeline")]
        public string Timeline { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("chapters")]
        public List<StoryChapter> Chapters { get; set; }

        [JsonProperty("races")]
        public List<Race> Races { get; set; }

        [JsonProperty("flags")]
        public List<string> Flags { get; set; }
    }
}
