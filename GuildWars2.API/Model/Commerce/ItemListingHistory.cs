using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.API.Model.Commerce
{
    public class ItemListingHistory
    {
        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [JsonIgnore]
        public DateTime Date {
            get {
                return new DateTime(1970, 1, 1, 0, 0, 0 , DateTimeKind.Utc).AddMilliseconds(TimeStamp);
            }
        }

        [JsonProperty("buy")]
        public int Buy { get; set; }

        [JsonIgnore]
        public ItemPrice BuyPrice { get { return new ItemPrice(Buy); } }

        [JsonProperty("sell")]
        public int Sell { get; set; }

        [JsonIgnore]
        public ItemPrice SellPrice { get { return new ItemPrice(Sell); } }

        [JsonProperty("supply")]
        public int Supply { get; set; }

        [JsonProperty("demand")]
        public int Demand { get; set; }
    }
}
