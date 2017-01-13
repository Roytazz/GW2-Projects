using Newtonsoft.Json;

namespace GuildWars2API.Model.Guild
{
    public class GuildTeamMember
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public GuildTeamRole Role { get; set; }
    }

    public enum GuildTeamRole
    {
        Captain,
        Member
    }
}