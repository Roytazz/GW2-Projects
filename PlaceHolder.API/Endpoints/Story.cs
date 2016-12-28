using GuildWars2APIPlaceHolder.Model.Backstory;
using GuildWars2APIPlaceHolder.Model.Story;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder
{
    public static class StoryAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Answers
        public static List<string> AnswerIDs()
        {
            return Builder.AddDirective("backstory")
                .AddDirective("answers")
                .Request<List<string>>();
        }

        public static List<Awnser> Answers()
        {
            return Builder.AddDirective("backstory")
                .AddDirective("answers")
                .AddParam("ids", "all")
                .Request<List<Awnser>>();
        }

        public static List<Awnser> Answers(int pageCount, int page)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("answers")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Awnser>>();
        }

        public static Awnser Answers(string ID)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("answers")
                .AddDirective(ID)
                .Request<Awnser>();
        }

        public static List<Awnser> Answers(List<string> IDs)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("answers")
                .AddParam("ids", IDs)
                .Request<List<Awnser>>();
        }
        #endregion Answers

        #region Questions
        public static List<int> QuestionIDs()
        {
            return Builder.AddDirective("backstory")
                .AddDirective("questions")
                .Request<List<int>>();
        }

        public static List<Question> Questions()
        {
            return Builder.AddDirective("backstory")
                .AddDirective("questions")
                .AddParam("ids", "all")
                .Request<List<Question>>();
        }

        public static List<Question> Questions(int pageCount, int page)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("questions")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Question>>();
        }

        public static Question Questions(int ID)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("questions")
                .AddDirective(ID.ToString())
                .Request<Question>();
        }

        public static List<Question> Questions(List<int> IDs)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("questions")
                .AddParam("ids", IDs)
                .Request<List<Question>>();
        }
        #endregion Questions

        #region Story
        public static List<int> StoryIDs()
        {
            return Builder.AddDirective("stories")
                .Request<List<int>>();
        }

        public static List<Story> Stories()
        {
            return Builder.AddDirective("stories")
                .AddParam("ids", "all")
                .Request<List<Story>>();
        }

        public static List<Story> Stories(int pageCount, int page)
        {
            return Builder.AddDirective("stories")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Story>>();
        }

        public static Story Stories(int ID)
        {
            return Builder.AddDirective("stories")
                .AddDirective(ID.ToString())
                .Request<Story>();
        }

        public static List<Story> Stories(List<int> IDs)
        {
            return Builder.AddDirective("stories")
                .AddParam("ids", IDs)
                .Request<List<Story>>();
        }
        #endregion Story

        #region Story Seasons
        public static List<string> SeasonIDs()
        {
            return Builder.AddDirective("stories")
                .AddDirective("seasons")
                .Request<List<string>>();
        }

        public static List<StorySeason> Seasons()
        {
            return Builder.AddDirective("stories")
                .AddDirective("seasons")
                .AddParam("ids", "all")
                .Request<List<StorySeason>>();
        }

        public static List<StorySeason> Seasons(int pageCount, int page)
        {
            return Builder.AddDirective("stories")
                .AddDirective("seasons")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<StorySeason>>();
        }

        public static StorySeason Seasons(string ID)
        {
            return Builder.AddDirective("stories")
                .AddDirective("seasons")
                .AddDirective(ID)
                .Request<StorySeason>();
        }

        public static List<StorySeason> Seasons(List<string> IDs)
        {
            return Builder.AddDirective("stories")
                .AddDirective("seasons")
                .AddParam("ids", IDs)
                .Request<List<StorySeason>>();
        }
        #endregion Story Seasons
    }
}
