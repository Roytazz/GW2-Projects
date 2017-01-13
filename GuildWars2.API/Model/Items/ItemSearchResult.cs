using Newtonsoft.Json;

namespace GuildWars2API.Model.Items
{
    public class ItemSearchResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("item_id")]
        public int ID { get; set; }
    }
}
