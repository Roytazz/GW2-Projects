using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Items
{
    public class SkinDetails
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("weight_class")]
        public WeightClass WeightClass { get; set; }

        [JsonProperty("damage_type")]
        public DamageType DamageType { get; set; }
    }
}
