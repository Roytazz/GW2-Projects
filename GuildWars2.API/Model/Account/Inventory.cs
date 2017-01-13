using Newtonsoft.Json;

namespace GuildWars2API.Model.Account
{
    //Shared inventory
    public class Inventory
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("binding")]
        public EntityBinding Binding { get; set; }
    }
}
