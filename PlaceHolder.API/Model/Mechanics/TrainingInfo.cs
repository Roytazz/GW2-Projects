using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Mechanics
{
    public class TrainingInfo
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("category")]
        public TrainingCategory Category { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("track")]
        public List<TrainingTrack> Track { get; set; }
    }

    public enum TrainingCategory
    {
        Skills,
        Specializations,
        EliteSpecializations
    }
}