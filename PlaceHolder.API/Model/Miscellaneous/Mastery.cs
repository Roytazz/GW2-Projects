using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Miscellaneous
{
    public class Mastery
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("requirement")]
        public string Requirement { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("levels")]
        public List<MasteryLevel> Levels { get; set; }
    }
}
