using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Character
{
    public class SABProgress
    {
        [JsonProperty("zones")]
        public List<SABZone> Zones { get; set; }

        [JsonProperty("unlocks")]
        public List<SABUnlock> Unlocks { get; set; }

        [JsonProperty("songs")]
        public List<SABUnlock> Songs { get; set; }
    }
}
