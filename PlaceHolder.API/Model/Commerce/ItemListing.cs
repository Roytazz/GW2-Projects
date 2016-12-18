using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Commerce
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
