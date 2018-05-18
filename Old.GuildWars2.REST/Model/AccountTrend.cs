using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuildWars2.REST.Model
{
    public class UserItemTrend
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }

        [JsonProperty("itemId")]
        public int ItemID { get; set; }

        public int Count { get; set; }

        public DateTime Date { get; set; }

        [JsonIgnore]
        public string AccountName { get; set; }
    }

    public class UserCurrencyTrend
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }

        [JsonProperty("currencyId")]
        public int CurrencyID { get; set; }

        public int Count { get; set; }

        public DateTime Date { get; set; }

        [JsonIgnore]
        public string AccountName { get; set; }
    }

    public class UserAccountTrend
    {
        public List<List<UserItemTrend>> Items { get; set; }

        public List<List<UserCurrencyTrend>> Currencies { get; set; }
    }
}