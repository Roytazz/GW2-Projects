using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model
{
    public class TokenInfo
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permissions")]
        public List<string> Permissions { get; set; }
    }

    public enum Permission
    {
        [JsonProperty("account")] Account,
        [JsonProperty("builds")] Builds,
        [JsonProperty("characters")] Characters,
        [JsonProperty("guilds")] Guilds,
        [JsonProperty("inventories")] Inventories,
        [JsonProperty("progession")] Progression,
        [JsonProperty("pvp")] PvP,
        [JsonProperty("tradingpost")] Tradingpost,
        [JsonProperty("unlocks")] Unlocks,
        [JsonProperty("wallet")] Wallet
    }
}
