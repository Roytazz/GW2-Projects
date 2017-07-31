using GuildWars2.API.Model.Guild;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API
{
    public static class GuildAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Emblem
        #region Foreground
        public static Task<List<int>> EmblemForegroundIDs()
        {
            return Builder.AddDirective("emblem")
                .AddDirective("foregrounds")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Emblem>> EmblemForegrounds()
        {
            return Builder.AddDirective("emblem")
                .AddDirective("foregrounds")
                .AddParam("ids", "all")
                .RequestAsync<List<Emblem>>();
        }

        public static Task<Emblem> EmblemForegrounds(int ID)
        {
            return Builder.AddDirective("emblem")
                .AddDirective("foregrounds")
                .AddDirective(ID.ToString())
                .RequestAsync<Emblem>();
        }

        public static Task<List<Emblem>> EmblemForegrounds(List<int> IDs)
        {
            return Builder.AddDirective("emblem")
                .AddDirective("foregrounds")
                .AddParam("ids", IDs)
                .RequestAsync<List<Emblem>>();
        }
        #endregion Foreground

        #region Background
        public static Task<List<int>> EmblemBackgroundIDs()
        {
            return Builder.AddDirective("emblem")
                .AddDirective("backgrounds")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Emblem>> EmblemBackgrounds()
        {
            return Builder.AddDirective("emblem")
                .AddDirective("backgrounds")
                .AddParam("ids", "all")
                .RequestAsync<List<Emblem>>();
        }

        public static Task<Emblem> EmblemBackgrounds(int ID)
        {
            return Builder.AddDirective("emblem")
                .AddDirective("backgrounds")
                .AddDirective(ID.ToString())
                .RequestAsync<Emblem>();
        }

        public static Task<List<Emblem>> EmblemBackgrounds(List<int> IDs)
        {
            return Builder.AddDirective("emblem")
                .AddDirective("backgrounds")
                .AddParam("ids", IDs)
                .RequestAsync<List<Emblem>>();
        }
        #endregion Background
        #endregion Emblem

        #region Permission
        public static Task<List<GuildPermissionType>> PermissionIDs()
        {
            return Builder.AddDirective("guild")
                .AddDirective("permissions")
                .RequestAsync<List<GuildPermissionType>>();
        }

        public static Task<List<GuildPermission>> Permissions()
        {
            return Builder.AddDirective("guild")
                .AddDirective("permissions")
                .AddParam("ids", "all")
                .RequestAsync<List<GuildPermission>>();
        }

        public static Task<GuildPermission> Permissions(GuildPermissionType ID)
        {
            return Builder.AddDirective("guild")
                .AddDirective("permissions")
                .AddDirective(ID.ToString())
                .RequestAsync<GuildPermission>();
        }

        public static Task<List<GuildPermission>> Permissions(List<GuildPermissionType> IDs)
        {
            return Builder.AddDirective("guild")
                .AddDirective("permissions")
                .AddParam("ids", IDs)
                .RequestAsync<List<GuildPermission>>();
        }
        #endregion Permission

        #region Upgrades
        public static Task<List<int>> UpgradeIDs()
        {
            return Builder.AddDirective("guild")
                .AddDirective("upgrades")
                .RequestAsync<List<int>>();
        }

        public static Task<List<GuildUpgrade>> Upgrades(int pageCount, int page)
        {
            return Builder.AddDirective("guild")
                .AddDirective("upgrades")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<GuildUpgrade>>();
        }

        public static Task<List<GuildUpgrade>> Upgrades()
        {
            return Builder.AddDirective("guild")
                .AddDirective("upgrades")
                .AddParam("ids", "all")
                .RequestAsync<List<GuildUpgrade>>();
        }

        public static Task<GuildUpgrade> Upgrades(int ID)
        {
            return Builder.AddDirective("guild")
                .AddDirective("upgrades")
                .AddDirective(ID.ToString())
                .RequestAsync<GuildUpgrade>();
        }

        public static Task<List<GuildUpgrade>> Upgrades(List<int> IDs)
        {
            return Builder.AddDirective("guild")
                .AddDirective("upgrades")
                .AddParam("ids", IDs)
                .RequestAsync<List<GuildUpgrade>>();
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

        public static Task<GuildDetails> Details(string guildID) {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .RequestAsync<GuildDetails>();
        }

        public static async Task<GuildDetails> DetailsByName(string name)
        {
            var oldDetails = await Builder.AddDirective("guild_details.json")
                .AddParam("guild_name", name)
                .RequestAsync<GuildDetailsOld>(Network.API.Guildwars2V1);
            return await Details(oldDetails.ID);
        }
        #endregion Details

        public static Task<List<string>> Search(string name) {
            return Builder.AddDirective("guild")
                .AddDirective("search")
                .AddParam("name", name)
                .RequestAsync<List<string>>();
        }

        public static Task<List<LogEntry>> Logs(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("log")
                .RequestAsync<List<LogEntry>>(apiKey);
        }

        public static Task<List<LogEntry>> LogsSince(string guildID, int logID, string apiKey) {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("log")
                .AddParam("since", logID.ToString())
                .RequestAsync<List<LogEntry>>(apiKey);
        }

        public static Task<List<Member>> Members(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("members")
                .RequestAsync<List<Member>>(apiKey);
        }

        public static Task<List<Rank>> Ranks(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("ranks")
                .RequestAsync<List<Rank>>(apiKey);
        }

        public static Task<List<Stash>> Stash(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("stash")
                .RequestAsync<List<Stash>>(apiKey);
        }

        public static Task<List<Treasury>> Treasury(string guildID, string apiKey) 
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("treasury")
                .RequestAsync<List<Treasury>>(apiKey);
        }

        public static Task<List<Stash>> Storage(string guildID, string apiKey) {    //Undocumented Endpoint
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("storage")
                .RequestAsync<List<Stash>>(apiKey);
        }

        public static Task<List<GuildTeam>> Teams(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("teams")
                .RequestAsync<List<GuildTeam>>(apiKey);
        }

        public static Task<List<int>> UpgradesCompleted(string guildID, string apiKey)
        {
            return Builder.AddDirective("guild")
                .AddDirective(guildID)
                .AddDirective("upgrades")
                .RequestAsync<List<int>>(apiKey);
        }
    }
}
