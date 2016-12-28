using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model
{
    public class TokenInfo
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permissions")]
        public List<Permission> Permissions { get; set; }
    }

    public enum Permission
    {
        Account,
        Builds,
        Characters,
        Guilds,
        Inventories,
        Progression,
        PvP,
        Tradingpost,
        Unlocks,
        Wallet
    }
}
