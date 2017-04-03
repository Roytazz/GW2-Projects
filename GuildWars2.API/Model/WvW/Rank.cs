using Newtonsoft.Json;

namespace GuildWars2.API.Model.WvW
{
    public class Rank
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("min_rank")]
        public int MinRank { get; set; }
    }
}
