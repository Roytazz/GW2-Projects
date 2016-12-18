using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Account
{
    public class AccountMastery
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }
    }
}
