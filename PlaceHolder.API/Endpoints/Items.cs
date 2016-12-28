using GuildWars2APIPlaceHolder.Model.Items;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder
{
    public static class ItemAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Finishers
        public static List<int> FinisherIDs() {
            return Builder.AddDirective("finishers")
                .Request<List<int>>();
        }

        public static List<Finisher> Finishers()
        {
            return Builder.AddDirective("finishers")
                .AddParam("ids", "all")
                .Request<List<Finisher>>();
        }

        public static List<Finisher> Finishers(int pageCount, int page) {
            return Builder.AddDirective("finishers")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Finisher>>();
        }

        public static Finisher Finishers(int ID) {
            return Builder.AddDirective("finishers")
                .AddDirective(ID.ToString())
                .Request<Finisher>();
        }

        public static List<Finisher> Finishers(List<int> IDs) {
            return Builder.AddDirective("finishers")
                .AddParam("ids", IDs)
                .Request<List<Finisher>>();
        }
        #endregion Finishers

        #region Skins
        public static List<int> SkinIDs()
        {
            return Builder.AddDirective("skins")
                .Request<List<int>>();
        }

        public static Skin Skins(int ID)
        {
            return Builder.AddDirective("skins")
                .AddDirective(ID.ToString())
                .Request<Skin>();
        }

        public static List<Skin> Skins(List<int> IDs)
        {
            return Builder.AddDirective("skins")
                .AddParam("ids", IDs)
                .Request<List<Skin>>();
        }
        #endregion

        #region Recipes
        public static List<int> RecipeIDs()
        {
            return Builder.AddDirective("recipes")
                .Request<List<int>>();
        }

        public static List<Recipe> Recipes(int pageCount, int page)
        {
            return Builder.AddDirective("recipes")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Recipe>>();
        }

        public static Recipe Recipes(int ID)
        {
            return Builder.AddDirective("recipes")
                .AddDirective(ID.ToString())
                .Request<Recipe>();
        }

        public static List<Recipe> Recipes(List<int> IDs)
        {
            return Builder.AddDirective("recipes")
                .AddParam("ids", IDs)
                .Request<List<Recipe>>();
        }

        public static List<int> SearchRecipesByInput(int itemID)
        {
            return Builder.AddDirective("recipes")
                .AddDirective("search")
                .AddParam("input", itemID.ToString())
                .Request<List<int>>();
        }

        public static List<int> SearchRecipesByOutput(int itemID)
        {
            return Builder.AddDirective("recipes")
                .AddDirective("search")
                .AddParam("output", itemID.ToString())
                .Request<List<int>>();
        }
        #endregion Recipes

        #region Material Storage
        public static List<int> MaterialIDs()
        {
            return Builder.AddDirective("materials")
                .Request<List<int>>();
        }

        public static List<MaterialCategory> Materials()
        {
            return Builder.AddDirective("materials")
                .AddParam("ids", "all")
                .Request<List<MaterialCategory>>();
        }

        public static List<MaterialCategory> Materials(int pageCount, int page)
        {
            return Builder.AddDirective("materials")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<MaterialCategory>>();
        }

        public static MaterialCategory Materials(int ID)
        {
            return Builder.AddDirective("materials")
                .AddDirective(ID.ToString())
                .Request<MaterialCategory>();
        }

        public static List<MaterialCategory> Materials(List<int> IDs)
        {
            return Builder.AddDirective("materials")
                .AddParam("ids", IDs)
                .Request<List<MaterialCategory>>();
        }
        #endregion Material Storage

        #region ItemStats
        public static List<int> StatPrefixIDs()
        {
            return Builder.AddDirective("itemstats")
                .Request<List<int>>();
        }

        public static List<ItemStats> StatPrefixes()
        {
            return Builder.AddDirective("itemstats")
                .AddParam("ids", "all")
                .Request<List<ItemStats>>();
        }

        public static List<ItemStats> StatPrefixes(int pageCount, int page)
        {
            return Builder.AddDirective("itemstats")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<ItemStats>>();
        }

        public static ItemStats StatPrefixes(int ID)
        {
            return Builder.AddDirective("itemstats")
                .AddDirective(ID.ToString())
                .Request<ItemStats>();
        }

        public static List<ItemStats> StatPrefixes(List<int> IDs)
        {
            return Builder.AddDirective("itemstats")
                .AddParam("ids", IDs)
                .Request<List<ItemStats>>();
        }
        #endregion ItemStats

        #region Items
        public static List<int> ItemIDs()
        {
            return Builder.AddDirective("items")
                .Request<List<int>>();
        }

        public static List<Item> Items(int pageCount, int page)
        {
            return Builder.AddDirective("items")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Item>>();
        }

        public static Item Items(int ID)
        {
            return Builder.AddDirective("items")
                .AddDirective(ID.ToString())
                .Request<Item>();
        }

        public static List<Item> Items(List<int> IDs)
        {
            return Builder.AddDirective("items")
                .AddParam("ids", IDs)
                .Request<List<Item>>();
        }
        #endregion ItemStats
    }
}
