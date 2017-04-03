using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GuildWars2.API.Model.WvW
{
    public class Objective
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("owner")]
        public WvWColor Owner { get; set; }

        [JsonProperty("last_flipped")]
        public DateTime LastFlipped { get; set; }

        [JsonProperty("claimed_by")]
        public string ClaimedBy { get; set; }

        [JsonProperty("claimed_at")]
        public DateTime? ClaimedAt { get; set; }

        [JsonProperty("points_tick")]
        public int PointsPerTick { get; set; }

        [JsonProperty("points_capture")]
        public int PointsForCapture { get; set; }

        [JsonProperty("guild_upgrades")]
        public List<int> GuildUpgrades { get; set; }

        [JsonProperty("yaks_delivered")]
        public int YaksDelivered { get; set; }
    }
}