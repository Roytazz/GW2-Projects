using Newtonsoft.Json;

namespace GuildWars2API.Model.Story
{
    public class StoryChapter
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}