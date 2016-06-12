using GuildWars2API.Model.Guild;
using GuildWars2API.Network;
using System.Collections.Generic;

using static GuildWars2API.Network.NetworkManager;

namespace GuildWars2API
{
    public static class GuildAPI
    {
#pragma warning disable CSE0003
        public static List<LogEntry> GetGuildLogByName(string guildName, string apiKey) {
            var details = GetGuildDetails(guildName);
            return GetGuildLogByID(details.GuildID, apiKey);
        }

        public static List<LogEntry> GetGuildLogByID(string guildID, string apiKey) {
            return AuthorizedRequest<List<LogEntry>>(URLBuilder.GetGuildLog(guildID), apiKey);
        }

        public static GuildDetails GetGuildDetails(string guildName) {
            return UnauthorizedRequest<GuildDetails>(URLBuilder.GetGuildDetailsByName(guildName));
        }

        public static List<Member> GetMembersByGuildName(string apiKey, string guildName) {
            var guildDetails = GetGuildDetails(guildName);
            return AuthorizedRequest<List<Member>>(URLBuilder.GetGuildMembers(guildDetails.GuildID), apiKey);
        }

        public static List<Member> GetMembersByGuildID(string apiKey, string guildId) {
            return AuthorizedRequest<List<Member>>(URLBuilder.GetGuildMembers(guildId), apiKey);
        }
#pragma warning restore CSE0003
    }
}
