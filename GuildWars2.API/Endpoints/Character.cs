using GuildWars2.API.Model.Character;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API
{
    public static class CharacterAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("characters"); } }

        public static Task<List<string>> CharacterNames(string apiKey)
        {
            return Builder.RequestAsync<List<string>>(apiKey);
        }

        public static Task<List<Character>> Characters(string apiKey)
        {
            return Builder.AddParam("page", "0")
                .RequestAsync<List<Character>>(apiKey);
        }

        public static Task<List<Character>> Characters(int pageCount, int page, string apiKey)
        {
            return Builder.AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Character>>(apiKey);
        }

        public static Task<Character> Characters(string name, string apiKey)
        {
            return Builder.AddDirective(name)
                .RequestAsync<Character>(apiKey);
        }

        public static Task<List<string>> HeroPoints(string name, string apiKey) {
            return Builder.AddDirective(name)
                .AddDirective("heropoints")
                .RequestAsync<List<string>>(apiKey);
        }

        public static Task<SABProgress> SABProgress(string name, string apiKey) {
            return Builder.AddDirective(name)
                .AddDirective("sab")
                .RequestAsync<SABProgress>(apiKey);
        }
    }
}
