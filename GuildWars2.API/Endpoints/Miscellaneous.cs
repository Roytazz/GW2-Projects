using GuildWars2API.Model;
using GuildWars2API.Model.Color;
using GuildWars2API.Model.Miscellaneous;
using System.Collections.Generic;

namespace GuildWars2API
{
    public class MiscellaneousAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Colors
        public static List<int> ColorIDs()
        {
            return Builder.AddDirective("colors")
                .Request<List<int>>();
        }

        public static List<Color> Colors()
        {
            return Builder.AddDirective("colors")
                .AddParam("ids", "all")
                .Request<List<Color>>();
        }

        public static Color Colors(int ID)
        {
            return Builder.AddDirective("colors")
                .AddDirective(ID.ToString())
                .Request<Color>();
        }

        public static List<Color> Colors(List<int> IDs)
        {
            return Builder.AddDirective("colors")
                .AddParam("ids", IDs)
                .Request<List<Color>>();
        }
        #endregion Colors

        #region Minis
        public static List<int> MiniIDs()
        {
            return Builder.AddDirective("minis")
                .Request<List<int>>();
        }

        public static List<Mini> Minis()
        {
            return Builder.AddDirective("minis")
                .AddParam("ids", "all")
                .Request<List<Mini>>();
        }

        public static Mini Minis(int ID)
        {
            return Builder.AddDirective("minis")
                .AddDirective(ID.ToString())
                .Request<Mini>();
        }

        public static List<Mini> Minis(List<int> IDs)
        {
            return Builder.AddDirective("minis")
                .AddParam("ids", IDs)
                .Request<List<Mini>>();
        }
        #endregion Minis

        #region Titles
        public static List<int> TitleIDs()
        {
            return Builder.AddDirective("titles")
                .Request<List<int>>();
        }

        public static List<Title> Titles()
        {
            return Builder.AddDirective("titles")
                .AddParam("ids", "all")
                .Request<List<Title>>();
        }

        public static List<Title> Titles(int pageCount, int page)
        {
            return Builder.AddDirective("titles")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Title>>();
        }

        public static Title Titles(int ID)
        {
            return Builder.AddDirective("titles")
                .AddDirective(ID.ToString())
                .Request<Title>();
        }

        public static List<Title> Titles(List<int> IDs)
        {
            return Builder.AddDirective("titles")
                .AddParam("ids", IDs)
                .Request<List<Title>>();
        }
        #endregion Titles

        #region Currency
        public static List<int> CurrencyIDs()
        {
            return Builder.AddDirective("currencies")
                .Request<List<int>>();
        }

        public static List<Currency> Currencies()
        {
            return Builder.AddDirective("currencies")
                .AddParam("ids", "all")
                .Request<List<Currency>>();
        }

        public static Currency Currencies(int ID)
        {
            return Builder.AddDirective("currencies")
                .AddDirective(ID.ToString())
                .Request<Currency>();
        }

        public static List<Currency> Currencies(List<int> IDs)
        {
            return Builder.AddDirective("currencies")
                .AddParam("ids", IDs)
                .Request<List<Currency>>();
        }
        #endregion Currency

        #region Mastery
        public static List<int> MasteryIDs()
        {
            return Builder.AddDirective("masteries")
                .Request<List<int>>();
        }

        public static Mastery Masteries()
        {
            return Builder.AddDirective("masteries")
                .AddParam("ids", "all")
                .Request<Mastery>();
        }

        public static Mastery Masteries(int ID)
        {
            return Builder.AddDirective("masteries")
                .AddDirective(ID.ToString())
                .Request<Mastery>();
        }

        public static List<Mastery> Masteries(List<int> IDs)
        {
            return Builder.AddDirective("masteries")
                .AddParam("ids", IDs)
                .Request<List<Mastery>>();
        }
        #endregion Mastery

        #region Outfits
        public static List<int> OutfitIDs()
        {
            return Builder.AddDirective("outfits")
                .Request<List<int>>();
        }

        public static List<Outfit> Outfits()
        {
            return Builder.AddDirective("outfits")
                .AddParam("ids", "all")
                .Request<List<Outfit>>();
        }

        public static List<Outfit> Outfits(int pageCount, int page)
        {
            return Builder.AddDirective("outfits")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Outfit>>();
        }

        public static Outfit Outfits(int ID)
        {
            return Builder.AddDirective("outfits")
                .AddDirective(ID.ToString())
                .Request<Outfit>();
        }

        public static List<Outfit> Outfits(List<int> IDs)
        {
            return Builder.AddDirective("outfits")
                .AddParam("ids", IDs)
                .Request<List<Outfit>>();
        }
        #endregion Outfits

        #region Files/Assets
        public static List<string> AssetIDs()
        {
            return Builder.AddDirective("files")
                .Request<List<string>>();
        }

        public static List<Asset> Assets()
        {
            return Builder.AddDirective("files")
                .AddParam("ids", "all")
                .Request<List<Asset>>();
        }

        public static List<Asset> Assets(int pageCount, int page)
        {
            return Builder.AddDirective("files")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Asset>>();
        }

        public static Asset Assets(string ID)
        {
            return Builder.AddDirective("files")
                .AddDirective(ID.ToString())
                .Request<Asset>();
        }

        public static List<Asset> Assets(List<string> IDs)
        {
            return Builder.AddDirective("files")
                .AddParam("ids", IDs)
                .Request<List<Asset>>();
        }
        #endregion Files/Assets

        #region Quaggans
        public static List<string> QuagganIDs()
        {
            return Builder.AddDirective("quaggans")
                .Request<List<string>>();
        }

        public static List<Asset> Quaggans()
        {
            return Builder.AddDirective("quaggans")
                .AddParam("ids", "all")
                .Request<List<Asset>>();
        }

        public static List<Asset> Quaggans(int pageCount, int page)
        {
            return Builder.AddDirective("quaggans")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Asset>>();
        }

        public static Asset Quaggans(string ID)
        {
            return Builder.AddDirective("quaggans")
                .AddDirective(ID.ToString())
                .Request<Asset>();
        }

        public static List<Asset> Quaggans(List<string> IDs)
        {
            return Builder.AddDirective("quaggans")
                .AddParam("ids", IDs)
                .Request<List<Asset>>();
        }
        #endregion Quaggans

        #region Worlds
        public static List<int> WorldIDs()
        {
            return Builder.AddDirective("worlds")
                .Request<List<int>>();
        }

        public static List<Server> Worlds()
        {
            return Builder.AddDirective("worlds")
                .AddParam("ids", "all")
                .Request<List<Server>>();
        }

        public static List<Server> Worlds(int pageCount, int page)
        {
            return Builder.AddDirective("worlds")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Server>>();
        }

        public static Server Worlds(int ID)
        {
            return Builder.AddDirective("worlds")
                .AddDirective(ID.ToString())
                .Request<Server>();
        }

        public static List<Server> Worlds(List<int> IDs)
        {
            return Builder.AddDirective("worlds")
                .AddParam("ids", IDs)
                .Request<List<Server>>();
        }
        #endregion Worlds

        public static Build CurrentBuild()
        {
            return Builder.AddDirective("build")
                .Request<Build>();
        }
    }
}
