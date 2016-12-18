﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Commerce
{
    public class Transaction
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("item_id")]
        public int ItemID { get; set; }

        [JsonProperty("price")]
        public int PriceCoins { get; set; }

        [JsonIgnore]
        public ItemPrice Price { get { return new ItemPrice(PriceCoins); } }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("purchased")]
        public DateTime Purchased { get; set; }
    }
}