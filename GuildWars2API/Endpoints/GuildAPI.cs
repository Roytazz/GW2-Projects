using GuildWars2API.Model.Guild;
using GuildWars2API.Network;
using System.Collections.Generic;

using static GuildWars2API.Network.NetworkManager;
using System;

namespace GuildWars2API
{
    public static class GuildAPI
    {
#pragma warning disable CSE0003
        public static GuildDetails GetGuildDetails(string guildName) {
            return UnauthorizedRequest<GuildDetails>(URLBuilder.GetGuildDetailsByName(guildName));
        }

        public static List<LogEntry> GetGuildLogByName(string guildName, string apiKey) {
            var details = GetGuildDetails(guildName);
            return GetGuildLogByID(details.GuildID, apiKey);
        }

        public static List<LogEntry> GetGuildLogByID(string guildID, string apiKey) {
            return AuthorizedRequest<List<LogEntry>>(URLBuilder.GetGuildLog(guildID), apiKey);
        }

        public static List<Rank> GetGuildRanksByGuildName(string guildName, string apiKey) {
            var guildDetails = GetGuildDetails(guildName);
            return GetGuildRanksById(guildDetails.GuildID, apiKey);
        }

        public static List<Rank> GetGuildRanksById(string guildId, string apiKey) {
            return AuthorizedRequest<List<Rank>>(URLBuilder.GetGuildRanks(guildId), apiKey);
        }

        public static List<Member> GetMembersByGuildName(string guildName, string apiKey) {
            var guildDetails = GetGuildDetails(guildName);
            return GetMembersByID(guildDetails.GuildID, apiKey);
        }

        public static List<Member> GetMembersByID(string guildId, string apiKey) {
            return AuthorizedRequest<List<Member>>(URLBuilder.GetGuildMembers(guildId), apiKey);
        }
#pragma warning restore CSE0003
    }
}
