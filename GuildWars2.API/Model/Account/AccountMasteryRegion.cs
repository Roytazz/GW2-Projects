using Newtonsoft.Json;

namespace GuildWars2.API.Model.Account
{
    public class AccountMasteryRegion
    {
        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("spent")]
        public int Spent { get; set; }

        [JsonProperty("earned")]
        public int Earned { get; set; }
    }

    public enum Region
    {
        Tyria,
        Maguuma
    }
}
