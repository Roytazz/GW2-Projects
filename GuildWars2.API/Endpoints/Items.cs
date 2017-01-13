using GuildWars2API.Model.Items;
using System.Collections.Generic;

namespace GuildWars2API
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

        #region Mystic Forge
        public static List<RecipeMysticForge> SearchMysticForgeRecipesByOutput(int ID)
        {
            return Builder/*.AddParam("disciplines", "Mystic Forge")*/      //Weird API thing with AND OR
                .AddParam("output_ids", ID.ToString())
                .Request<List<RecipeMysticForge>>(API.Profits);
        }

        public static List<RecipeMysticForge> SearchMysticForgeRecipesByOutput(List<int> ID)
        {
            return Builder/*.AddParam("disciplines", "Mystic%20Forge")*/    //Weird API thing with AND OR
                .AddParam("output_ids", ID)
                .Request<List<RecipeMysticForge>>(API.Profits);
        }
        #endregion Mystic Forge

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

        public static List<ItemSearchResult> SearchByName(string name)
        {
            return Builder.AddDirective("idbyname")
                .AddDirective(name)
                .Request<List<ItemSearchResult>>(API.Shinies);
        }

        public static bool IsPromotionItem(int itemID)
        {
            var promotionItemIDs = new List<int>() {
                19743, 19745, 19741, 19748, 19739, 19732, 19728, 19729, 19730, 19731, 74724, 74798, 74084, 74825, 75123, 24307, 24308, 24310, 38014, 38024, 38023, 75536, 76313, 76572, 76209,
                76456, 75542, 76044, 76342, 70545, 70724, 73158, 70779, 71049, 70956, 73229, 70792, 72012, 70537, 70675, 71900, 72677, 73415, 46733, 45884, 45885, 12244, 19701, 19703, 19697,
                19698, 19702, 19699, 24304, 13243, 24324, 13248, 24339, 24329, 13256, 13244, 13245, 13257, 13258, 13260, 13246, 19700, 13259, 13247, 24314, 13255, 24319, 24309, 19726, 19727,
                19723, 19722, 19724, 19725, 19744, 19720, 46741, 19742, 19740, 19746, 72845, 19747, 19738, 19735, 19733, 46739, 19736, 19734, 19737, 19685, 46743, 73537, 19686, 19681, 19688,
                19684, 19680, 19683, 19687, 19679, 75640, 19682, 46738, 46732, 19712, 19713, 19714, 19709, 19710, 19711, 46736, 24343, 24345, 24358, 24341, 24344, 24351, 24350, 24348, 24347,
                24349, 24275, 24273, 24276, 24274, 24277, 24356, 24357, 24354, 24353, 24355, 24288, 24289, 24285, 24287, 24286, 24363, 24297, 24300, 24299, 24298, 24280, 24282, 24283, 24281,
                24279, 24293, 24295, 24294, 24292, 24291, 24302, 24304, 24305, 24303, 24339, 24338, 24337, 24340, 24330, 24329, 24277, 24327, 24328, 46683, 46682, 24325, 24323, 24324, 71653,
                24322, 77190, 77082, 24335, 24334, 38024, 24331, 24332, 38014, 74544, 71163, 75801, 71852, 71856, 72445, 71437, 71036, 74457, 70439, 73671, 70493, 76379, 72142, 71873, 75781,
                72934, 75043, 71260, 72331, 73753, 70730, 72846, 72454, 72551, 73332, 72337, 76380, 24333, 38023, 76405, 75818, 76806, 73381, 75504, 74643, 75769, 75899, 75939, 75215, 70658,
                71979, 73375, 75228, 73111, 74378, 76157, 72766, 24317, 24318, 24319, 24320, 24312, 24314, 24313, 24315, 24309, 24332, 24333, 24334, 24335
            };
            return promotionItemIDs.Contains(itemID);
        }
    }
}