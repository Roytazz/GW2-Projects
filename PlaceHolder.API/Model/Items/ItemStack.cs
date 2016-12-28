using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Items
{
    public class ItemStack
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
