using Newtonsoft.Json;

namespace GuildWars2APIPlaceHolder.Model.Character
{
    public class CharacterCraftingDiscipline
    {
        [JsonProperty("discipline")]
        public Discipline Discipline { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}
