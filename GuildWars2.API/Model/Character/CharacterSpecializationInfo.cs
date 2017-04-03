using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Character
{
    public class CharacterSpecialization
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("traits")]
        public List<int?> Traits { get; set; }
    }
}