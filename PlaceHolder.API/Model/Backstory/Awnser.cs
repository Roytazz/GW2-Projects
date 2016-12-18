using GuildWars2APIPlaceHolder.Model.Character;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Backstory
{
    public class Awnser
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("journal")]
        public string Journal { get; set; }

        [JsonProperty("question")]
        public int Question { get; set; }

        [JsonProperty("professions")]
        public List<Profession> Professions { get; set; }

        [JsonProperty("races")]
        public List<Race> Races { get; set; }
    }
}
