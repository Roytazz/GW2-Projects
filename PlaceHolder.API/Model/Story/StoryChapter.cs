using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Story
{
    public class StoryChapter
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}