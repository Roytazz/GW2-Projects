using GuildWars2APIPlaceHolder.Model;
using GuildWars2APIPlaceHolder.Model.Achievements;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder
{
    public static class AchievementsAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("achievements"); } }

        #region Achievements
        public static List<int> AchievementIDs()
        {
            return Builder.Request<List<int>>();
        }

        public static Achievement Achievements(int ID)
        {
            return Builder.AddPointer(ID.ToString())
                .Request<Achievement>();
        }

        public static List<Achievement> Achievements(List<int> IDs)
        {
            return Builder.AddParam("ids", IDs)
                .Request<List<Achievement>>();
        }
        #endregion Achievements

        #region Daylies
        public static Dictionary<GameType, List<DailyAchievement>> DailyAchievements()
        {
            return Builder.AddPointer("daily")
                .Request<Dictionary<GameType, List<DailyAchievement>>>();
        }
        public static Dictionary<GameType, List<DailyAchievement>> DailyAchievementsTomorrow()
        {
            return Builder.AddPointer("daily")
                .AddPointer("tomorrow")
                .Request<Dictionary<GameType, List<DailyAchievement>>>();
        }
        #endregion Daylies

        #region Groups
        public static List<string> GroupIDs()
        {
            return Builder.AddPointer("groups")
                .Request<List<string>>();
        }

        public static List<Group> Groups(int pageCount, int page)
        {
            return Builder.AddPointer("groups")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Group>>();
        }

        public static List<Group> Groups()
        {
            return Builder.AddPointer("groups")
                .AddParam("ids", "all")
                .Request<List<Group>>();
        }

        public static Group Groups(string ID)
        {
            return Builder.AddPointer("groups")
                .AddPointer(ID.ToString())
                .Request<Group>();
        }

        public static List<Group> Groups(List<string> IDs)
        {
            return Builder.AddPointer("groups")
                .AddParam("ids", IDs)
                .Request<List<Group>>();
        }
        #endregion Groups

        #region Categories
        public static List<int> CategoryIds()
        {
            return Builder.AddPointer("categories")
                .Request<List<int>>();
        }

        public static List<Category> Categories()
        {
            return Builder.AddPointer("categories")
                .AddParam("ids", "all")
                .Request<List<Category>>();
        }

        public static List<Category> Categories(int pageCount, int page)
        {
            return Builder.AddPointer("categories")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Category>>();
        }

        public static Category Categories(int ID)
        {
            return Builder.AddPointer("categories")
                .AddPointer(ID.ToString())
                .Request<Category>();
        }

        public static List<Category> Categories(List<int> IDs)
        {
            return Builder.AddPointer("categories")
                .AddParam("ids", IDs)
                .Request<List<Category>>();
        }
        #endregion Categories
    }
}
