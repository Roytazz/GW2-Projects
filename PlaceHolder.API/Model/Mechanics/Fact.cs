using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Mechanics
{
    public class Fact
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("type")]
        public SkillFactType Type { get; set; }


        [JsonProperty("required_trait")]
        public int RequiredTrait { get; set; }

        [JsonProperty("overrides")]
        public int Overrides { get; set; }

        //.. Optional Fields ..//

        /// <summary>
        /// Either int or bool
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("target")]
        public ItemAttribute Target { get; set; }  

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("apply_count")]
        public int ApplyCount { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("field_type")]
        public FieldType FieldType { get; set; }

        [JsonProperty("finisher_type")]
        public FinisherType FinisherType { get; set; }

        [JsonProperty("percent")]
        public decimal Percent { get; set; }

        [JsonProperty("hit_count")]
        public int HitCount { get; set; }

        [JsonProperty("distance")]
        public int Distance { get; set; }
    }
}