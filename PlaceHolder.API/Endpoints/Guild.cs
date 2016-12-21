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
        public static List<GuildPermission> PermissionIDs()
        {
            return Builder.AddPointer("guild")
                .AddPointer("permissions")
                .Request<List<GuildPermission>>();
        }

        public static List<Permission> Permissions()
        {
            return Builder.AddPointer("guild")
                .AddPointer("permissions")
                .AddParam("ids", "all")
                .Request<List<Permission>>();
        }

        public static Permission Permissions(GuildPermission ID)
        {
            return Builder.AddPointer("guild")
                .AddPointer("permissions")
                .AddPointer(ID.ToString())
                .Request<Permission>();
        }

        public static List<Permission> Permissions(List<GuildPermission> IDs)
        {
            return Builder.AddPointer("guild")
                .AddPointer("permissions")
                .AddParam("ids", IDs)
                .Request<List<Permission>>();
        }
        #endregion Permission

        #region Upgrades
        #endregion Upgrades
    }
}
