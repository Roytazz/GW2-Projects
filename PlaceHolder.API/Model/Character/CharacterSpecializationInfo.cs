using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.Character
{
    public class CharacterSpecialization
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("traits")]
        public List<int?> Traits { get; set; }
    }
}