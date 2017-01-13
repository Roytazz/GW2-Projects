using Newtonsoft.Json;

namespace GuildWars2API.Model.PvP
{
    public class DivisionTier
    {
        [JsonProperty("points")]
        public int Points { get; set; }
    }
}