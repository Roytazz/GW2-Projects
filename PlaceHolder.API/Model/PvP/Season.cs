using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.PvP
{
    public class Season
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("divisions")]
        public List<Division> Divisions { get; set; }

        [JsonProperty("leadersboards"), JsonIgnore]
        public List<object> Leaderboards { get; set; }  //TODO PvP Leaderbords
    }
}
