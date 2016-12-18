using GuildWars2APIPlaceHolder.Model.PvP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder
{
    public static class PvPAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("pvp"); } }

        public static Stats Stats(string apiKey)
        {
            return Builder.AddPointer("stats")
                .Request<Stats>(apiKey);
        }

        public static List<Standings> Standings(string apiKey)
        {
            return Builder.AddPointer("standings")
                .Request<List<Standings>>(apiKey);
        }

        #region Games
        public static List<string> GameIDs(string apiKey)
        {
            return Builder.AddPointer("games")
                .Request<List<string>>(apiKey);
        }

        public static List<Game> Games(string apiKey)
        {
            return Builder.AddPointer("games")
                .AddParam("ids", "all")
                .Request<List<Game>>(apiKey);
        }

        public static List<Game> Games(int pageCount, int page, string apiKey)
        {
            return Builder.AddPointer("games")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Game>>(apiKey);
        }

        public static Game Games(string ID, string apiKey)
        {
            return Builder.AddPointer("games")
                .AddPointer(ID.ToString())
                .Request<Game>(apiKey);
        }

        public static List<Game> Games(List<string> IDs, string apiKey)
        {
            return Builder.AddPointer("games")
                .AddParam("ids", IDs)
                .Request<List<Game>>(apiKey);
        }
        #endregion Games

        #region Seasons
        public static List<string> SeasonIDs()
        {
            return Builder.AddPointer("seasons")
                .Request<List<string>>();
        }

        public static List<Season> Seasons()
        {
            return Builder.AddPointer("seasons")
                .AddParam("ids", "all")
                .Request<List<Season>>();
        }

        public static List<Season> Seasons(int pageCount, int page)
        {
            return Builder.AddPointer("seasons")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Season>>();
        }

        public static Season Seasons(string ID)
        {
            return Builder.AddPointer("seasons")
                .AddPointer(ID.ToString())
                .Request<Season>();
        }

        public static List<Season> Seasons(List<string> IDs)
        {
            return Builder.AddPointer("seasons")
                .AddParam("ids", IDs)
                .Request<List<Season>>();
        }
        #endregion Seasons

        #region Amulets
        public static List<int> AmuletIDs()
        {
            return Builder.AddPointer("amulets")
                .Request<List<int>>();
        }

        public static List<Amulet> Amulets()
        {
            return Builder.AddPointer("amulets")
                .AddParam("ids", "all")
                .Request<List<Amulet>>();
        }

        public static List<Amulet> Amulets(int pageCount, int page)
        {
            return Builder.AddPointer("amulets")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Amulet>>();
        }

        public static Amulet Amulets(int ID)
        {
            return Builder.AddPointer("amulets")
                .AddPointer(ID.ToString())
                .Request<Amulet>();
        }

        public static List<Amulet> Amulets(List<int> IDs)
        {
            return Builder.AddPointer("amulets")
                .AddParam("ids", IDs)
                .Request<List<Amulet>>();
        }
        #endregion Amulets
    }
}
