using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.PvP
{
    public class DivisionTier
    {
        [JsonProperty("points")]
        public int Points { get; set; }
    }
}