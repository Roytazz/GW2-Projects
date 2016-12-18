using GuildWars2APIPlaceHolder.Model.Items;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Account
{
    public class BankEntity
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("slot")]
        public int Slot { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("skin")]
        public int Skin { get; set; }

        [JsonProperty("charges")]
        public int Charges { get; set; }

        [JsonProperty("upgrades")]
        public List<int> Upgrades { get; set; }

        [JsonProperty("stats")]
        public ItemStats Stats { get; set; }

        [JsonProperty("infusions")]
        public List<int> Infusions { get; set; }

        [JsonProperty("binding")]
        public EntityBinding Binding { get; set; }

        [JsonProperty("bound_to")]
        public string BoundTo { get; set; }
    }
}
