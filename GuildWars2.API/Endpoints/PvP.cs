using GuildWars2API.Model.PvP;
using System.Collections.Generic;

namespace GuildWars2API
{
    public static class PvPAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("pvp"); } }

        public static Stats Stats(string apiKey)
        {
            return Builder.AddDirective("stats")
                .Request<Stats>(apiKey);
        }

        public static List<Standings> Standings(string apiKey)
        {
            return Builder.AddDirective("standings")
                .Request<List<Standings>>(apiKey);
        }

        #region Games
        public static List<string> GameIDs(string apiKey)
        {
            return Builder.AddDirective("games")
                .Request<List<string>>(apiKey);
        }

        public static List<Game> Games(string apiKey)
        {
            return Builder.AddDirective("games")
                .AddParam("ids", "all")
                .Request<List<Game>>(apiKey);
        }

        public static List<Game> Games(int pageCount, int page, string apiKey)
        {
            return Builder.AddDirective("games")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Game>>(apiKey);
        }

        public static Game Games(string ID, string apiKey)
        {
            return Builder.AddDirective("games")
                .AddDirective(ID.ToString())
                .Request<Game>(apiKey);
        }

        public static List<Game> Games(List<string> IDs, string apiKey)
        {
            return Builder.AddDirective("games")
                .AddParam("ids", IDs)
                .Request<List<Game>>(apiKey);
        }
        #endregion Games

        #region Seasons
        public static List<string> SeasonIDs()
        {
            return Builder.AddDirective("seasons")
                .Request<List<string>>();
        }

        public static List<Season> Seasons()
        {
            return Builder.AddDirective("seasons")
                .AddParam("ids", "all")
                .Request<List<Season>>();
        }

        public static List<Season> Seasons(int pageCount, int page)
        {
            return Builder.AddDirective("seasons")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Season>>();
        }

        public static Season Seasons(string ID)
        {
            return Builder.AddDirective("seasons")
                .AddDirective(ID.ToString())
                .Request<Season>();
        }

        public static List<Season> Seasons(List<string> IDs)
        {
            return Builder.AddDirective("seasons")
                .AddParam("ids", IDs)
                .Request<List<Season>>();
        }
        #endregion Seasons

        #region Amulets
        public static List<int> AmuletIDs()
        {
            return Builder.AddDirective("amulets")
                .Request<List<int>>();
        }

        public static List<Amulet> Amulets()
        {
            return Builder.AddDirective("amulets")
                .AddParam("ids", "all")
                .Request<List<Amulet>>();
        }

        public static List<Amulet> Amulets(int pageCount, int page)
        {
            return Builder.AddDirective("amulets")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Amulet>>();
        }

        public static Amulet Amulets(int ID)
        {
            return Builder.AddDirective("amulets")
                .AddDirective(ID.ToString())
                .Request<Amulet>();
        }

        public static List<Amulet> Amulets(List<int> IDs)
        {
            return Builder.AddDirective("amulets")
                .AddParam("ids", IDs)
                .Request<List<Amulet>>();
        }
        #endregion Amulets

        #region Season Leaderboards
        public static List<GuildLeaderboard> LeaderboardGuild(string ID, int pageCount, int page)
        {
            return Builder.AddDirective("seasons")
                .AddDirective(ID.ToString())
                .AddDirective("leaderboards")
                .AddDirective("guild")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<GuildLeaderboard>>();
        }

        public static List<GuildLeaderboard> LeaderboardGuild(string ID, Region region, int pageCount, int page) {
            return Builder.AddDirective("seasons")
                .AddDirective(ID.ToString())
                .AddDirective("leaderboards")
                .AddDirective("guild")
                .AddDirective(region.ToString())
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<GuildLeaderboard>>();
        }

        public static List<GuildLeaderboard> LeaderboardGuild(string ID)
        {
            return Builder.AddDirective("seasons")
               .AddDirective(ID.ToString())
               .AddDirective("leaderboards")
               .AddDirective("guild")
               .Request<List<GuildLeaderboard>>();
        }

        public static List<GuildLeaderboard> LeaderboardGuild(string ID, Region region) {
            return Builder.AddDirective("seasons")
               .AddDirective(ID.ToString())
               .AddDirective("leaderboards")
               .AddDirective("guild")
               .AddDirective(region.ToString())
               .Request<List<GuildLeaderboard>>();
        }

        public static List<BaseLeaderboard> LeaderboardLegendary(string ID, int pageCount, int page)
        {
            return Builder.AddDirective("seasons")
                .AddDirective(ID.ToString())
                .AddDirective("leaderboards")
                .AddDirective("legendary")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<BaseLeaderboard>>();
        }

        public static List<BaseLeaderboard> LeaderboardLegendary(string ID, Region region, int pageCount, int page) {
            return Builder.AddDirective("seasons")
                .AddDirective(ID.ToString())
                .AddDirective("leaderboards")
                .AddDirective("legendary")
                .AddDirective(region.ToString())
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<BaseLeaderboard>>();
        }

        public static List<BaseLeaderboard> LeaderboardLegendary(string ID)
        {
            return Builder.AddDirective("seasons")
               .AddDirective(ID.ToString())
               .AddDirective("leaderboards")
               .AddDirective("legendary")
               .Request<List<BaseLeaderboard>>();
        }

        public static List<BaseLeaderboard> LeaderboardLegendary(string ID, Region region) {
            return Builder.AddDirective("seasons")
               .AddDirective(ID.ToString())
               .AddDirective("leaderboards")
               .AddDirective("legendary")
               .AddDirective(region.ToString())
               .Request<List<BaseLeaderboard>>();
        }
        #endregion Season Leaderboards
    }

    public enum Region
    {
        NA,
        EU
    }
}
