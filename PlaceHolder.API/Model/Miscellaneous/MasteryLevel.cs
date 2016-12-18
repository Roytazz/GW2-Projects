using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Miscellaneous
{
    public class MasteryLevel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("point_cost")]
        public int PointCost { get; set; }

        [JsonProperty("exp_cost")]
        public int ExpCost { get; set; }
    }
}
