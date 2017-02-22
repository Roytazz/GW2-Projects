using GuildWars2API.Model.Guild;
using System.Collections.Generic;

namespace GuildWars2API
{
    public static class GuildAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Emblem
        #region Foreground
        public static List<int> EmblemForegroundIDs()
        {
            return Builder.AddDirective("emblem")
                .AddDirective("foregrounds")
                .Request<List<int>>();
        }

        public static List<Emblem> EmblemForegrounds()
        {
            return Builder.AddDirective("emblem")
                .AddDirective("foregrounds")
                .AddParam("ids", "all")
                .Request<List<Emblem>>();
        }

        public static Emblem EmblemForegrounds(int ID)
        {
            return Builder.AddDirective("emblem")
                .AddDirective("foregrounds")
                .AddDirective(ID.ToString())
                .Request<Emblem>();
        }

        public static List<Emblem> EmblemForegrounds(List<int> IDs)
        {
            return Builder.AddDirective("emblem")
                .AddDirective("foregrounds")
                .AddParam("ids", IDs)
                .Request<List<Emblem>>();
        }
        #endregion Foreground

        #region Background
        public static List<int> EmblemBackgroundIDs()
        {
            return Builder.AddDirective("emblem")
                .AddDirective("backgrounds")
                .Request<List<int>>();
        }

        public static List<Emblem> EmblemBackgrounds()
        {
            return Builder.AddDirective("emblem")
                .AddDirective("backgrounds")
                .AddParam("ids", "all")
                .Request<List<Emblem>>();
        }

        public static Emblem EmblemBackgrounds(int ID)
        {
            return Builder.AddDirective("emblem")
                .AddDirective("backgrounds")
                .AddDirective(ID.ToString())
                .Request<Emblem>();
        }

        public static List<Emblem> EmblemBackgrounds(List<int> IDs)
        {
            return Builder.AddDirective("emblem")
                .AddDirective("backgrounds")
                .AddParam("ids", IDs)
                .Request<List<Emblem>>();
        }
        #endregion Background
        #endregion Emblem

        #region Permission
        public static List<GuildPermissionType> PermissionIDs()
        {
            return Builder.AddDirective("guild")
                .AddDirective("permissions")
                .Request<List<GuildPermissionType>>();
        }

        public static List<GuildPermission> Permissions()
        {
            return Builder.AddDirective("guild")
                .AddDirective("permissions")
                .AddParam("ids", "all")
                .Request<List<GuildPermission>>();
        }

        public static GuildPermission Permissions(GuildPermissionType ID)
        {
            return Builder.AddDirective("guild")
                .AddDirective("permissions")
                .AddDirective(ID.ToString())
                .Request<GuildPermission>();
        }

        public static List<GuildPermission> Permissions(List<GuildPermissionType> IDs)
        {
            return Builder.AddDirective("guild")
                .AddDirective("permissions")
                .AddParam("ids", IDs)
                .Request<List<GuildPermission>>();
        }
        #endregion Permission

        #region Upgrades
        public static List<int> UpgradeIDs()
        {
            return Builder.AddDirective("guild")
                .AddDirective("upgrades")
                .Request<List<int>>();
        }

        public static List<GuildUpgrade> Upgrades(int pageCount, int page)
        {
            return Builder.AddDirective("guild")
                .AddDirective("upgrades")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<GuildUpgrade>>();
        }

        public static List<GuildUpgrade> Upgrades()
        {
            return Builder.AddDirective("guild")
                .AddDirective("upgrades")
                .AddParam("ids", "all")
                .Request<List<GuildUpgrade>>();
        }

        public static GuildUpgrade Upgrades(int ID)
        {
            return Builder.AddDirective("guild")
                .AddDirective("upgrades")
                .AddDirective(ID.ToString())
                .Request<GuildUpgrade>();
        }

        public static List<GuildUpgrade> Upgrades(List<int> IDs)
        {
            return Builder.AddDirective("guild")
                .AddDirective("upgrades")
                .AddParam("ids", IDs)
                .Request<List<GuildUpgrade>>();
        }
        #endregion Upgrades

        #region Details
        //New methods when Anet implementation is finished
        /*public static List<string> Guilds(string apiKey) 
        {
            return Builder.AddDirective("guild")
                .Request<List<string>>(apiKey);
        }*/

        /*public static GuildDetails Details(List<string> guildIDs, string apiKey) {
            return Builder.AddDirective("guild")
                .AddParam("ids", guildIDs)
                .Request<GuildDetails>(apiKey);
        }*/

        public static GuildDetails Details(string guildID) {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .Request<GuildDetails>();
        }

        public static GuildDetails DetailsByName(string name)
        {
            var oldDetails = Builder.AddDirective("guild_details.json")
                .AddParam("guild_name", name)
                .Request<GuildDetailsOld>(API.Guildwars2V1);
            return Details(oldDetails.ID);
        }
        #endregion Details

        public static List<LogEntry> Logs(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("log")
                .Request<List<LogEntry>>(apiKey);
        }

        public static List<LogEntry> LogsSince(string guildID, int logID, string apiKey) {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("log")
                .AddParam("since", logID.ToString())
                .Request<List<LogEntry>>(apiKey);
        }

        public static List<Member> Members(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("members")
                .Request<List<Member>>(apiKey);
        }

        public static List<Rank> Ranks(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("ranks")
                .Request<List<Rank>>(apiKey);
        }

        public static List<Stash> Stash(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("stash")
                .Request<List<Stash>>(apiKey);
        }

        public static List<Stash> Treasury(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("treasury")
                .Request<List<Stash>>(apiKey);
        }

        public static List<GuildTeam> Teams(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("teams")
                .Request<List<GuildTeam>>(apiKey);
        }

        public static List<int> UpgradesCompleted(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("upgrades")
                .Request<List<int>>(apiKey);
        }
    }
}
