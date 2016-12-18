using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Character
{
    public class PvPEquipment
    {
        [JsonProperty("amulet")]
        public int Amulet { get; set; }

        [JsonProperty("rune")]
        public int Rune { get; set; }

        [JsonProperty("sigils")]
        public List<int> Sigils { get; set; }
    }
}