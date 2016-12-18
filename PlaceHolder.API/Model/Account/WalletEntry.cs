using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Account
{
    public class WalletEntry
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
