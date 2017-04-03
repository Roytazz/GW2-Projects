using GuildWars2.API.Model.Backstory;
using GuildWars2.API.Model.Story;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API
{
    public static class StoryAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Answers
        public static Task<List<string>> AnswerIDs()
        {
            return Builder.AddDirective("backstory")
                .AddDirective("answers")
                .RequestAsync<List<string>>();
        }

        public static Task<List<Awnser>> Answers()
        {
            return Builder.AddDirective("backstory")
                .AddDirective("answers")
                .AddParam("ids", "all")
                .RequestAsync<List<Awnser>>();
        }

        public static Task<List<Awnser>> Answers(int pageCount, int page)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("answers")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Awnser>>();
        }

        public static Task<Awnser> Answers(string ID)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("answers")
                .AddDirective(ID)
                .RequestAsync<Awnser>();
        }

        public static Task<List<Awnser>> Answers(List<string> IDs)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("answers")
                .AddParam("ids", IDs)
                .RequestAsync<List<Awnser>>();
        }
        #endregion Answers

        #region Questions
        public static Task<List<int>> QuestionIDs()
        {
            return Builder.AddDirective("backstory")
                .AddDirective("questions")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Question>> Questions()
        {
            return Builder.AddDirective("backstory")
                .AddDirective("questions")
                .AddParam("ids", "all")
                .RequestAsync<List<Question>>();
        }

        public static Task<List<Question>> Questions(int pageCount, int page)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("questions")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Question>>();
        }

        public static Task<Question> Questions(int ID)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("questions")
                .AddDirective(ID.ToString())
                .RequestAsync<Question>();
        }

        public static Task<List<Question>> Questions(List<int> IDs)
        {
            return Builder.AddDirective("backstory")
                .AddDirective("questions")
                .AddParam("ids", IDs)
                .RequestAsync<List<Question>>();
        }
        #endregion Questions

        #region Story
        public static Task<List<int>> StoryIDs()
        {
            return Builder.AddDirective("stories")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Story>> Stories()
        {
            return Builder.AddDirective("stories")
                .AddParam("ids", "all")
                .RequestAsync<List<Story>>();
        }

        public static Task<List<Story>> Stories(int pageCount, int page)
        {
            return Builder.AddDirective("stories")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Story>>();
        }

        public static Task<Story> Stories(int ID)
        {
            return Builder.AddDirective("stories")
                .AddDirective(ID.ToString())
                .RequestAsync<Story>();
        }

        public static Task<List<Story>> Stories(List<int> IDs)
        {
            return Builder.AddDirective("stories")
                .AddParam("ids", IDs)
                .RequestAsync<List<Story>>();
        }
        #endregion Story

        #region Story Seasons
        public static Task<List<string>> SeasonIDs()
        {
            return Builder.AddDirective("stories")
                .AddDirective("seasons")
                .RequestAsync<List<string>>();
        }

        public static Task<List<StorySeason>> Seasons()
        {
            return Builder.AddDirective("stories")
                .AddDirective("seasons")
                .AddParam("ids", "all")
                .RequestAsync<List<StorySeason>>();
        }

        public static Task<List<StorySeason>> Seasons(int pageCount, int page)
        {
            return Builder.AddDirective("stories")
                .AddDirective("seasons")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<StorySeason>>();
        }

        public static Task<StorySeason> Seasons(string ID)
        {
            return Builder.AddDirective("stories")
                .AddDirective("seasons")
                .AddDirective(ID)
                .RequestAsync<StorySeason>();
        }

        public static Task<List<StorySeason>> Seasons(List<string> IDs)
        {
            return Builder.AddDirective("stories")
                .AddDirective("seasons")
                .AddParam("ids", IDs)
                .RequestAsync<List<StorySeason>>();
        }
        #endregion Story Seasons
    }
}
