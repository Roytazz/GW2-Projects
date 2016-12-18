using GuildWars2APIPlaceHolder.Model.Color;
using GuildWars2APIPlaceHolder.Model.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder
{
    public class MiscellaneousAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Colors
        public static List<int> ColorIDs()
        {
            return Builder.AddPointer("colors")
                .Request<List<int>>();
        }

        public static List<Color> Colors()
        {
            return Builder.AddPointer("colors")
                .AddParam("ids", "all")
                .Request<List<Color>>();
        }

        public static Color Colors(int ID)
        {
            return Builder.AddPointer("colors")
                .AddPointer(ID.ToString())
                .Request<Color>();
        }

        public static List<Color> Colors(List<int> IDs)
        {
            return Builder.AddPointer("colors")
                .AddParam("ids", IDs)
                .Request<List<Color>>();
        }
        #endregion Colors

        #region Minis
        public static List<int> MiniIDs()
        {
            return Builder.AddPointer("minis")
                .Request<List<int>>();
        }

        public static List<Mini> Minis()
        {
            return Builder.AddPointer("minis")
                .AddParam("ids", "all")
                .Request<List<Mini>>();
        }

        public static Mini Minis(int ID)
        {
            return Builder.AddPointer("minis")
                .AddPointer(ID.ToString())
                .Request<Mini>();
        }

        public static List<Mini> Minis(List<int> IDs)
        {
            return Builder.AddPointer("minis")
                .AddParam("ids", IDs)
                .Request<List<Mini>>();
        }
        #endregion Minis

        #region Titles
        public static List<int> TitleIDs()
        {
            return Builder.AddPointer("titles")
                .Request<List<int>>();
        }

        public static List<Title> Titles()
        {
            return Builder.AddPointer("titles")
                .AddParam("ids", "all")
                .Request<List<Title>>();
        }

        public static List<Title> Titles(int pageCount, int page)
        {
            return Builder.AddPointer("titles")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Title>>();
        }

        public static Title Titles(int ID)
        {
            return Builder.AddPointer("titles")
                .AddPointer(ID.ToString())
                .Request<Title>();
        }

        public static List<Title> Titles(List<int> IDs)
        {
            return Builder.AddPointer("titles")
                .AddParam("ids", IDs)
                .Request<List<Title>>();
        }
        #endregion Titles

        #region Currency
        public static List<int> CurrencyIDs()
        {
            return Builder.AddPointer("currencies")
                .Request<List<int>>();
        }

        public static List<Currency> Currencies()
        {
            return Builder.AddPointer("currencies")
                .AddParam("ids", "all")
                .Request<List<Currency>>();
        }

        public static Currency Currencies(int ID)
        {
            return Builder.AddPointer("currencies")
                .AddPointer(ID.ToString())
                .Request<Currency>();
        }

        public static List<Currency> Currencies(List<int> IDs)
        {
            return Builder.AddPointer("currencies")
                .AddParam("ids", IDs)
                .Request<List<Currency>>();
        }
        #endregion Currency

        #region Mastery
        public static List<int> MasteryIDs()
        {
            return Builder.AddPointer("masteries")
                .Request<List<int>>();
        }

        public static Mastery Masteries()
        {
            return Builder.AddPointer("masteries")
                .AddParam("ids", "all")
                .Request<Mastery>();
        }

        public static Mastery Masteries(int ID)
        {
            return Builder.AddPointer("masteries")
                .AddPointer(ID.ToString())
                .Request<Mastery>();
        }

        public static List<Mastery> Masteries(List<int> IDs)
        {
            return Builder.AddPointer("masteries")
                .AddParam("ids", IDs)
                .Request<List<Mastery>>();
        }
        #endregion Mastery

        #region Outfits
        public static List<int> OutfitIDs()
        {
            return Builder.AddPointer("outfits")
                .Request<List<int>>();
        }

        public static List<Outfit> Outfits()
        {
            return Builder.AddPointer("outfits")
                .AddParam("ids", "all")
                .Request<List<Outfit>>();
        }

        public static List<Outfit> Outfits(int pageCount, int page)
        {
            return Builder.AddPointer("outfits")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Outfit>>();
        }

        public static Outfit Outfits(int ID)
        {
            return Builder.AddPointer("outfits")
                .AddPointer(ID.ToString())
                .Request<Outfit>();
        }

        public static List<Outfit> Outfits(List<int> IDs)
        {
            return Builder.AddPointer("outfits")
                .AddParam("ids", IDs)
                .Request<List<Outfit>>();
        }
        #endregion Outfits
    }
}
