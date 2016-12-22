using GuildWars2APIPlaceHolder.Model.Guild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder
{
    public static class GuildAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Emblem
        #region Foreground
        public static List<int> EmblemForegroundIDs()
        {
            return Builder.AddPointer("emblem")
                .AddPointer("foregrounds")
                .Request<List<int>>();
        }

        public static List<Emblem> EmblemForegrounds()
        {
            return Builder.AddPointer("emblem")
                .AddPointer("foregrounds")
                .AddParam("ids", "all")
                .Request<List<Emblem>>();
        }

        public static Emblem EmblemForegrounds(int ID)
        {
            return Builder.AddPointer("emblem")
                .AddPointer("foregrounds")
                .AddPointer(ID.ToString())
                .Request<Emblem>();
        }

        public static List<Emblem> EmblemForegrounds(List<int> IDs)
        {
            return Builder.AddPointer("emblem")
                .AddPointer("foregrounds")
                .AddParam("ids", IDs)
                .Request<List<Emblem>>();
        }
        #endregion Foreground

        #region Background
        public static List<int> EmblemBackgroundIDs()
        {
            return Builder.AddPointer("emblem")
                .AddPointer("backgrounds")
                .Request<List<int>>();
        }

        public static List<Emblem> EmblemBackgrounds()
        {
            return Builder.AddPointer("emblem")
                .AddPointer("backgrounds")
                .AddParam("ids", "all")
                .Request<List<Emblem>>();
        }

        public static Emblem EmblemBackgrounds(int ID)
        {
            return Builder.AddPointer("emblem")
                .AddPointer("backgrounds")
                .AddPointer(ID.ToString())
                .Request<Emblem>();
        }

        public static List<Emblem> EmblemBackgrounds(List<int> IDs)
        {
            return Builder.AddPointer("emblem")
                .AddPointer("backgrounds")
                .AddParam("ids", IDs)
                .Request<List<Emblem>>();
        }
        #endregion Background
        #endregion Emblem

        #region Permission
        public static List<GuildPermissionType> PermissionIDs()
        {
            return Builder.AddPointer("guild")
                .AddPointer("permissions")
                .Request<List<GuildPermissionType>>();
        }

        public static List<GuildPermission> Permissions()
        {
            return Builder.AddPointer("guild")
                .AddPointer("permissions")
                .AddParam("ids", "all")
                .Request<List<GuildPermission>>();
        }

        public static GuildPermission Permissions(GuildPermissionType ID)
        {
            return Builder.AddPointer("guild")
                .AddPointer("permissions")
                .AddPointer(ID.ToString())
                .Request<GuildPermission>();
        }

        public static List<GuildPermission> Permissions(List<GuildPermissionType> IDs)
        {
            return Builder.AddPointer("guild")
                .AddPointer("permissions")
                .AddParam("ids", IDs)
                .Request<List<GuildPermission>>();
        }
        #endregion Permission

        #region Upgrades
        public static List<int> UpgradeIDs()
        {
            return Builder.AddPointer("guild")
                .AddPointer("upgrades")
                .Request<List<int>>();
        }

        public static List<GuildUpgrade> Upgrades(int pageCount, int page)
        {
            return Builder.AddPointer("guild")
                .AddPointer("upgrades")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<GuildUpgrade>>();
        }

        public static List<GuildUpgrade> Upgrades()
        {
            return Builder.AddPointer("guild")
                .AddPointer("upgrades")
                .AddParam("ids", "all")
                .Request<List<GuildUpgrade>>();
        }

        public static GuildUpgrade Upgrades(int ID)
        {
            return Builder.AddPointer("guild")
                .AddPointer("upgrades")
                .AddPointer(ID.ToString())
                .Request<GuildUpgrade>();
        }

        public static List<GuildUpgrade> Upgrades(List<int> IDs)
        {
            return Builder.AddPointer("guild")
                .AddPointer("upgrades")
                .AddParam("ids", IDs)
                .Request<List<GuildUpgrade>>();
        }
        #endregion Upgrades

        public static List<LogEntry> Logs(string guildID, string apiKey)
        {
            return Builder.AddPointer("guild")
                .AddPointer(guildID)
                .AddPointer("log")
                .Request<List<LogEntry>>(apiKey);
        }

        public static List<Member> Members(string guildID, string apiKey)
        {
            return Builder.AddPointer("guild")
                .AddPointer(guildID)
                .AddPointer("members")
                .Request<List<Member>>(apiKey);
        }

        public static List<Rank> Ranks(string guildID, string apiKey)
        {
            return Builder.AddPointer("guild")
                .AddPointer(guildID)
                .AddPointer("ranks")
                .Request<List<Rank>>(apiKey);
        }

        public static List<Stash> Stash(string guildID, string apiKey)
        {
            return Builder.AddPointer("guild")
                .AddPointer(guildID)
                .AddPointer("stash")
                .Request<List<Stash>>(apiKey);
        }

        public static List<Stash> Treasury(string guildID, string apiKey)
        {
            return Builder.AddPointer("guild")
                .AddPointer(guildID)
                .AddPointer("treasury")
                .Request<List<Stash>>(apiKey);
        }

        public static List<GuildTeam> Teams(string guildID, string apiKey)
        {
            return Builder.AddPointer("guild")
                .AddPointer(guildID)
                .AddPointer("teams")
                .Request<List<GuildTeam>>(apiKey);
        }

        public static List<int> UpgradesCompleted(string guildID, string apiKey)
        {
            return Builder.AddPointer("guild")
                .AddPointer(guildID)
                .AddPointer("upgrades")
                .Request<List<int>>(apiKey);
        }
    }
}
