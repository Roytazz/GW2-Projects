using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.WvW
{
    class ObjectiveDetail
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("type")]
        public WvWObjectiveType Type { get; set; }

        [JsonProperty("map_type")]
        public WvWMapType MapType { get; set; }

        [JsonProperty("map_id")]
        public int MapID { get; set; }

        [JsonProperty("sector_id")]
        public int SectorID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("label_coord")]
        public List<double> LabelCoordinates { get; set; }

        [JsonProperty("chat_link")]
        public string ChatLink { get; set; }

        [JsonProperty("upgrade_id")]
        public int UpgradeID { get; set; }

        [JsonProperty("marker")]
        public string Marker { get; set; }
    }
}
