using GuildWars2.API.Model;
using GuildWars2.API.Model.Achievements;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API
{
    public static class AchievementsAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("achievements"); } }

        #region Achievements
        public static Task<List<int>> AchievementIDs() {
            return Builder.RequestAsync<List<int>>();
        }

        public static Task<Achievement> Achievements(int ID) {
            return Builder.AddDirective(ID.ToString())
                .RequestAsync<Achievement>();
        }

        public static Task<List<Achievement>> Achievements(List<int> IDs) {
            return Builder.AddParam("ids", IDs)
                .RequestAsync<List<Achievement>>();
        }
        #endregion Achievements

        #region Dailies
        public static Task<Dictionary<GameType, List<DailyAchievement>>> DailyAchievements()
        {
            return Builder.AddDirective("daily")
                .RequestAsync<Dictionary<GameType, List<DailyAchievement>>>();
        }
        public static Task<Dictionary<GameType, List<DailyAchievement>>> DailyAchievementsTomorrow()
        {
            return Builder.AddDirective("daily")
                .AddDirective("tomorrow")
                .RequestAsync<Dictionary<GameType, List<DailyAchievement>>>();
        }
        #endregion Dailies

        #region Groups
        public static Task<List<string>> GroupIDs()
        {
            return Builder.AddDirective("groups")
                .RequestAsync<List<string>>();
        }

        public static Task<List<Group>> Groups(int pageCount, int page)
        {
            return Builder.AddDirective("groups")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Group>>();
        }

        public static Task<List<Group>> Groups()
        {
            return Builder.AddDirective("groups")
                .AddParam("ids", "all")
                .RequestAsync<List<Group>>();
        }

        public static Task<Group> Groups(string ID)
        {
            return Builder.AddDirective("groups")
                .AddDirective(ID.ToString())
                .RequestAsync<Group>();
        }

        public static Task<List<Group>> Groups(List<string> IDs)
        {
            return Builder.AddDirective("groups")
                .AddParam("ids", IDs)
                .RequestAsync<List<Group>>();
        }
        #endregion Groups

        #region Categories
        public static Task<List<int>> CategoryIds()
        {
            return Builder.AddDirective("categories")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Category>> Categories()
        {
            return Builder.AddDirective("categories")
                .AddParam("ids", "all")
                .RequestAsync<List<Category>>();
        }

        public static Task<List<Category>> Categories(int pageCount, int page)
        {
            return Builder.AddDirective("categories")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Category>>();
        }

        public static Task<Category> Categories(int ID)
        {
            return Builder.AddDirective("categories")
                .AddDirective(ID.ToString())
                .RequestAsync<Category>();
        }

        public static Task<List<Category>> Categories(List<int> IDs)
        {
            return Builder.AddDirective("categories")
                .AddParam("ids", IDs)
                .RequestAsync<List<Category>>();
        }
        #endregion Categories
    }
}
