using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Commerce
{
    public class ItemListing
    {
        [JsonProperty("id")]
        public int ItemID { get; set; }

        [JsonProperty("buys")]
        public List<Listing> Buys { get; set; }

        [JsonProperty("sells")]
        public List<Listing> Sells { get; set; }

        [JsonProperty("whitelisted")]
        public bool Whitelisted { get; set; }
    }
}
