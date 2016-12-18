using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Character
{
    public class CharacterSkillTree
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("spend")]
        public int Spend { get; set; }

        [JsonProperty("done")]
        public bool Done { get; set; }
    }
}
