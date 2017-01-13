using Newtonsoft.Json;

namespace GuildWars2API.Model.Account
{
    // GET /v2/account/finishers?access_token=$APIKEY
    public class AccountFinisher
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("permanent")]
        public bool Permanent { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
