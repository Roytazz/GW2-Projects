using Newtonsoft.Json;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Mini
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("unlock")]
        public string Unlock { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("item_id")]
        public int ItemID { get; set; }
    }
}
