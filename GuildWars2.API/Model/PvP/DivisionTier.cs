using Newtonsoft.Json;

namespace GuildWars2.API.Model.PvP
{
    public class DivisionTier
    {
        [JsonProperty("points")]
        public int Points { get; set; }
    }
}