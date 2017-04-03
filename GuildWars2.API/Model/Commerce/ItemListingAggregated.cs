using Newtonsoft.Json;

namespace GuildWars2.API.Model.Commerce
{
    public class ItemListingAggregated
    {
        [JsonProperty("id")]
        public int ItemID { get; set; }

        [JsonProperty("buys")]
        public Listing Buys { get; set; }

        [JsonProperty("sells")]
        public Listing Sells { get; set; }

        [JsonProperty("whitelisted")]
        public bool Whitelisted { get; set; }
    }
}
