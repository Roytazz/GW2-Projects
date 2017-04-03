using Newtonsoft.Json;

namespace GuildWars2.API.Model.Commerce
{
    public class Listing
    {
        [JsonProperty("listings")]
        public int Listings { get; set; }

        [JsonProperty("unit_price")]
        public int UnitPrice { get; set; }

        [JsonIgnore]
        public ItemPrice Price { get { return new ItemPrice(UnitPrice); } }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}