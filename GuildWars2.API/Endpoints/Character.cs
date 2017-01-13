using GuildWars2API.Model.Character;
using System;
using System.Collections.Generic;

namespace GuildWars2API
{
    public static class CharacterAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder("characters"); } }

        public static List<string> CharacterNames(string apiKey)
        {
            return Builder.Request<List<string>>(apiKey);
        }

        public static List<Character> Characters(string apiKey)
        {
            return Builder.AddParam("page", "0")
                .Request<List<Character>>(apiKey);
        }

        public static List<Character> Characters(int pageCount, int page, string apiKey)
        {
            return Builder.AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Character>>(apiKey);
        }

        public static Character Characters(string name, string apiKey)
        {
            return Builder.AddDirective(Uri.EscapeDataString(name))
                .Request<Character>(apiKey);
        }
    }
}
