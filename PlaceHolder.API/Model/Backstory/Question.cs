using GuildWars2APIPlaceHolder.Model.Character;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Backstory
{
    public class Question
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("answers")]
        public List<string> Answers { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("professions")]
        public List<Profession> Professions { get; set; }

        [JsonProperty("races")]
        public List<Race> Races { get; set; }
    }
}
