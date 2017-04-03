using Newtonsoft.Json;

namespace GuildWars2.API.Model.WvW
{
    public class MapBonus
    {
        [JsonProperty("type")]
        public MapBonusType Type { get; set; }    

        [JsonProperty("owner")]
        public WvWColor Owner { get; set; }
    }

    public enum MapBonusType
    {
        Bloodlust
    }
}
