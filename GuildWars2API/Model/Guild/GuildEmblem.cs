using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2API.Model.Guild
{
    public class GuildEmblem
    {
        //For colors see API:1/colors

        [JsonProperty("background_id")]
        public int BackgroundID { get; set; }

        [JsonProperty("background_color_id")]
        public int BackgroundColorID { get; set; }

        [JsonProperty("foreground_id")]
        public int ForegroundID { get; set; }

        [JsonProperty("foreground_primary_color_id")]
        public int ForegroundPrimaryColorID { get; set; }

        [JsonProperty("foreground_seconday_color_id")]
        public int ForegroundSecondaryColorID { get; set; }

        [JsonProperty("flags")]
        public List<EmblemFlip> Flags { get; set; }
    }

    public enum EmblemFlip
    {
        FlipBackgroundHorizontal,
        FlipBackgroundVertical,
        FlipForegroundHorizontal,
        FlipForegroundVertical
    }
}