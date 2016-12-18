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
    }
}
