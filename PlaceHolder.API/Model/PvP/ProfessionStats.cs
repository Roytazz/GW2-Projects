using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.PvP
{
    public class ProfessionStats
    {
        [JsonProperty("guardian")]
        public WinLossStats Guardian { get; set; }

        [JsonProperty("warrior")]
        public WinLossStats Warrior { get; set; }

        [JsonProperty("revenant")]
        public WinLossStats Revenant { get; set; }

        [JsonProperty("thief")]
        public WinLossStats Thief { get; set; }

        [JsonProperty("ranger")]
        public WinLossStats Ranger { get; set; }

        [JsonProperty("engineer")]
        public WinLossStats Engineer { get; set; }

        [JsonProperty("mesmer")]
        public WinLossStats Mesmer { get; set; }

        [JsonProperty("elementalist")]
        public WinLossStats Elementalist { get; set; }

        [JsonProperty("necromancer")]
        public WinLossStats Necromancer { get; set; }
    }
}