using Newtonsoft.Json;

namespace GuildWars2.API.Model.Items
{
    public class InfixBuff
    {
        [JsonProperty("skill_id")]
        public int SkillID { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}