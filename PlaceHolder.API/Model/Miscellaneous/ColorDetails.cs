using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Color
{
    public class ColorDetails
    {
        [JsonProperty("brightness")]
        public int Brightness { get; set; }
        [JsonProperty("contrast")]
        public float Contrast { get; set; }
        [JsonProperty("hue")]
        public int Hue { get; set; }
        [JsonProperty("saturation")]
        public float Saturation { get; set; }
        [JsonProperty("lightness")]
        public float Lightness { get; set; }
        [JsonProperty("rgb")]
        public List<int> RGB { get; set; }
    }
}