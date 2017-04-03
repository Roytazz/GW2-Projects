using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Account
{
    public class AccountAchievement
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("bits")]
        public List<int> Bits { get; set; }

        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("done")]
        public bool Done { get; set; }

        [JsonProperty("unlocked")]
        public bool Unlocked { get; set; }

        [JsonProperty("repeated")]
        public int Repeated { get; set; }
    }
}
