using Newtonsoft.Json;

namespace GuildWars2.API.Model.Character
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
