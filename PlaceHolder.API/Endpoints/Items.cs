using GuildWars2APIPlaceHolder.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder
{
    public static class ItemAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Finishers
        public static List<int> FinisherIDs() {
            return Builder.AddPointer("finishers")
                .Request<List<int>>();
        }

        public static List<Finisher> Finishers()
        {
            return Builder.AddPointer("finishers")
                .AddParam("ids", "all")
                .Request<List<Finisher>>();
        }

        public static List<Finisher> Finishers(int pageCount, int page) {
            return Builder.AddPointer("finishers")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Finisher>>();
        }

        public static Finisher Finishers(int ID) {
            return Builder.AddPointer("finishers")
                .AddPointer(ID.ToString())
                .Request<Finisher>();
        }

        public static List<Finisher> Finishers(List<int> IDs) {
            return Builder.AddPointer("finishers")
                .AddParam("ids", IDs)
                .Request<List<Finisher>>();
        }
        #endregion Finishers

        #region Skins
        public static List<int> SkinIDs()
        {
            return Builder.AddPointer("skins")
                .Request<List<int>>();
        }

        public static Skin Skins(int ID)
        {
            return Builder.AddPointer("skins")
                .AddPointer(ID.ToString())
                .Request<Skin>();
        }

        public static List<Skin> Skins(List<int> IDs)
        {
            return Builder.AddPointer("skins")
                .AddParam("ids", IDs)
                .Request<List<Skin>>();
        }
        #endregion

        #region Recipes
        public static List<int> RecipeIDs()
        {
            return Builder.AddPointer("recipes")
                .Request<List<int>>();
        }

        public static List<Recipe> Recipes(int pageCount, int page)
        {
            return Builder.AddPointer("recipes")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Recipe>>();
        }

        public static Recipe Recipes(int ID)
        {
            return Builder.AddPointer("recipes")
                .AddPointer(ID.ToString())
                .Request<Recipe>();
        }

        public static List<Recipe> Recipes(List<int> IDs)
        {
            return Builder.AddPointer("recipes")
                .AddParam("ids", IDs)
                .Request<List<Recipe>>();
        }

        public static List<int> SearchRecipesByInput(int itemID)
        {
            return Builder.AddPointer("recipes")
                .AddPointer("search")
                .AddParam("input", itemID.ToString())
                .Request<List<int>>();
        }

        public static List<int> SearchRecipesByOutput(int itemID)
        {
            return Builder.AddPointer("recipes")
                .AddPointer("search")
                .AddParam("output", itemID.ToString())
                .Request<List<int>>();
        }
        #endregion Recipes

        #region Material Storage
        public static List<int> MaterialIDs()
        {
            return Builder.AddPointer("materials")
                .Request<List<int>>();
        }

        public static List<MaterialCategory> Materials()
        {
            return Builder.AddPointer("materials")
                .AddParam("ids", "all")
                .Request<List<MaterialCategory>>();
        }

        public static List<MaterialCategory> Materials(int pageCount, int page)
        {
            return Builder.AddPointer("materials")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<MaterialCategory>>();
        }

        public static MaterialCategory Materials(int ID)
        {
            return Builder.AddPointer("materials")
                .AddPointer(ID.ToString())
                .Request<MaterialCategory>();
        }

        public static List<MaterialCategory> Materials(List<int> IDs)
        {
            return Builder.AddPointer("materials")
                .AddParam("ids", IDs)
                .Request<List<MaterialCategory>>();
        }
        #endregion Material Storage

        #region ItemStats
        public static List<int> StatPrefixIDs()
        {
            return Builder.AddPointer("itemstats")
                .Request<List<int>>();
        }

        public static List<ItemStats> StatPrefixes()
        {
            return Builder.AddPointer("itemstats")
                .AddParam("ids", "all")
                .Request<List<ItemStats>>();
        }

        public static List<ItemStats> StatPrefixes(int pageCount, int page)
        {
            return Builder.AddPointer("itemstats")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<ItemStats>>();
        }

        public static ItemStats StatPrefixes(int ID)
        {
            return Builder.AddPointer("itemstats")
                .AddPointer(ID.ToString())
                .Request<ItemStats>();
        }

        public static List<ItemStats> StatPrefixes(List<int> IDs)
        {
            return Builder.AddPointer("itemstats")
                .AddParam("ids", IDs)
                .Request<List<ItemStats>>();
        }
        #endregion ItemStats

        #region Items
        public static List<int> ItemIDs()
        {
            return Builder.AddPointer("items")
                .Request<List<int>>();
        }

        public static List<Item> Items(int pageCount, int page)
        {
            return Builder.AddPointer("items")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Item>>();
        }

        public static Item Items(int ID)
        {
            return Builder.AddPointer("items")
                .AddPointer(ID.ToString())
                .Request<Item>();
        }

        public static List<Item> Items(List<int> IDs)
        {
            return Builder.AddPointer("items")
                .AddParam("ids", IDs)
                .Request<List<Item>>();
        }
        #endregion ItemStats
    }
}
