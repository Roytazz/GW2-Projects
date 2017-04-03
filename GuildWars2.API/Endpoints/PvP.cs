using GuildWars2.API.Model.PvP;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API
{
    public static class PvPAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("pvp"); } }

        public static Task<Stats> Stats(string apiKey)
        {
            return Builder.AddDirective("stats")
                .RequestAsync<Stats>(apiKey);
        }

        public static Task<List<Standings>> Standings(string apiKey)
        {
            return Builder.AddDirective("standings")
                .RequestAsync<List<Standings>>(apiKey);
        }

        #region Games
        public static Task<List<string>> GameIDs(string apiKey)
        {
            return Builder.AddDirective("games")
                .RequestAsync<List<string>>(apiKey);
        }

        public static Task<List<Game>> Games(string apiKey)
        {
            return Builder.AddDirective("games")
                .AddParam("ids", "all")
                .RequestAsync<List<Game>>(apiKey);
        }

        public static Task<List<Game>> Games(int pageCount, int page, string apiKey)
        {
            return Builder.AddDirective("games")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Game>>(apiKey);
        }

        public static Task<Game> Games(string ID, string apiKey)
        {
            return Builder.AddDirective("games")
                .AddDirective(ID.ToString())
                .RequestAsync<Game>(apiKey);
        }

        public static Task<List<Game>> Games(List<string> IDs, string apiKey)
        {
            return Builder.AddDirective("games")
                .AddParam("ids", IDs)
                .RequestAsync<List<Game>>(apiKey);
        }
        #endregion Games

        #region Seasons
        public static Task<List<string>> SeasonIDs()
        {
            return Builder.AddDirective("seasons")
                .RequestAsync<List<string>>();
        }

        public static Task<List<Season>> Seasons()
        {
            return Builder.AddDirective("seasons")
                .AddParam("ids", "all")
                .RequestAsync<List<Season>>();
        }

        public static Task<List<Season>> Seasons(int pageCount, int page)
        {
            return Builder.AddDirective("seasons")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Season>>();
        }

        public static Task<Season> Seasons(string ID)
        {
            return Builder.AddDirective("seasons")
                .AddDirective(ID.ToString())
                .RequestAsync<Season>();
        }

        public static Task<List<Season>> Seasons(List<string> IDs)
        {
            return Builder.AddDirective("seasons")
                .AddParam("ids", IDs)
                .RequestAsync<List<Season>>();
        }
        #endregion Seasons

        #region Amulets
        public static Task<List<int>> AmuletIDs()
        {
            return Builder.AddDirective("amulets")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Amulet>> Amulets()
        {
            return Builder.AddDirective("amulets")
                .AddParam("ids", "all")
                .RequestAsync<List<Amulet>>();
        }

        public static Task<List<Amulet>> Amulets(int pageCount, int page)
        {
            return Builder.AddDirective("amulets")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Amulet>>();
        }

        public static Task<Amulet> Amulets(int ID)
        {
            return Builder.AddDirective("amulets")
                .AddDirective(ID.ToString())
                .RequestAsync<Amulet>();
        }

        public static Task<List<Amulet>> Amulets(List<int> IDs)
        {
            return Builder.AddDirective("amulets")
                .AddParam("ids", IDs)
                .RequestAsync<List<Amulet>>();
        }
        #endregion Amulets

        #region Season Leaderboards
        public static Task<List<GuildLeaderboard>> LeaderboardGuild(string ID, int pageCount, int page)
        {
            return Builder.AddDirective("seasons")
                .AddDirective(ID.ToString())
                .AddDirective("leaderboards")
                .AddDirective("guild")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<GuildLeaderboard>>();
        }

        public static Task<List<GuildLeaderboard>> LeaderboardGuild(string ID, Region region, int pageCount, int page) {
            return Builder.AddDirective("seasons")
                .AddDirective(ID.ToString())
                .AddDirective("leaderboards")
                .AddDirective("guild")
                .AddDirective(region.ToString())
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<GuildLeaderboard>>();
        }

        public static Task<List<GuildLeaderboard>> LeaderboardGuild(string ID)
        {
            return Builder.AddDirective("seasons")
               .AddDirective(ID.ToString())
               .AddDirective("leaderboards")
               .AddDirective("guild")
               .RequestAsync<List<GuildLeaderboard>>();
        }

        public static Task<List<GuildLeaderboard>> LeaderboardGuild(string ID, Region region) {
            return Builder.AddDirective("seasons")
               .AddDirective(ID.ToString())
               .AddDirective("leaderboards")
               .AddDirective("guild")
               .AddDirective(region.ToString())
               .RequestAsync<List<GuildLeaderboard>>();
        }

        public static Task<List<BaseLeaderboard>> LeaderboardLegendary(string ID, int pageCount, int page)
        {
            return Builder.AddDirective("seasons")
                .AddDirective(ID.ToString())
                .AddDirective("leaderboards")
                .AddDirective("legendary")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<BaseLeaderboard>>();
        }

        public static Task<List<BaseLeaderboard>> LeaderboardLegendary(string ID, Region region, int pageCount, int page) {
            return Builder.AddDirective("seasons")
                .AddDirective(ID.ToString())
                .AddDirective("leaderboards")
                .AddDirective("legendary")
                .AddDirective(region.ToString())
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<BaseLeaderboard>>();
        }

        public static Task<List<BaseLeaderboard>> LeaderboardLegendary(string ID)
        {
            return Builder.AddDirective("seasons")
               .AddDirective(ID.ToString())
               .AddDirective("leaderboards")
               .AddDirective("legendary")
               .RequestAsync<List<BaseLeaderboard>>();
        }

        public static Task<List<BaseLeaderboard>> LeaderboardLegendary(string ID, Region region) {
            return Builder.AddDirective("seasons")
               .AddDirective(ID.ToString())
               .AddDirective("leaderboards")
               .AddDirective("legendary")
               .AddDirective(region.ToString())
               .RequestAsync<List<BaseLeaderboard>>();
        }
        #endregion Season Leaderboards
    }

    public enum Region
    {
        NA,
        EU
    }
}