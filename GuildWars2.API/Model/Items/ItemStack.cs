using Newtonsoft.Json;

namespace GuildWars2.API.Model.Items
{
    public class ItemStack
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
