using GuildWars2.API.Model.Items;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API
{
    public static class ItemAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Finishers
        public static Task<List<int>> FinisherIDs() {
            return Builder.AddDirective("finishers")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Finisher>> Finishers()
        {
            return Builder.AddDirective("finishers")
                .AddParam("ids", "all")
                .RequestAsync<List<Finisher>>();
        }

        public static Task<List<Finisher>> Finishers(int pageCount, int page) {
            return Builder.AddDirective("finishers")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Finisher>>();
        }

        public static Task<Finisher> Finishers(int ID) {
            return Builder.AddDirective("finishers")
                .AddDirective(ID.ToString())
                .RequestAsync<Finisher>();
        }

        public static Task<List<Finisher>> Finishers(List<int> IDs) {
            return Builder.AddDirective("finishers")
                .AddParam("ids", IDs)
                .RequestAsync<List<Finisher>>();
        }
        #endregion Finishers

        #region Skins
        public static Task<List<int>> SkinIDs()
        {
            return Builder.AddDirective("skins")
                .RequestAsync<List<int>>();
        }

        public static Task<Skin> Skins(int ID)
        {
            return Builder.AddDirective("skins")
                .AddDirective(ID.ToString())
                .RequestAsync<Skin>();
        }

        public static Task<List<Skin>> Skins(List<int> IDs)
        {
            return Builder.AddDirective("skins")
                .AddParam("ids", IDs)
                .RequestAsync<List<Skin>>();
        }
        #endregion

        #region Recipes
        public static Task<List<int>> RecipeIDs()
        {
            return Builder.AddDirective("recipes")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Recipe>> Recipes(int pageCount, int page)
        {
            return Builder.AddDirective("recipes")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Recipe>>();
        }

        public static Task<Recipe> Recipes(int ID)
        {
            return Builder.AddDirective("recipes")
                .AddDirective(ID.ToString())
                .RequestAsync<Recipe>();
        }

        public static Task<List<Recipe>> Recipes(List<int> IDs)
        {
            return Builder.AddDirective("recipes")
                .AddParam("ids", IDs)
                .RequestAsync<List<Recipe>>();
        }

        public static Task<List<int>> SearchRecipesByInput(int itemID)
        {
            return Builder.AddDirective("recipes")
                .AddDirective("search")
                .AddParam("input", itemID.ToString())
                .RequestAsync<List<int>>();
        }

        public static Task<List<int>> SearchRecipesByOutput(int itemID)
        {
            return Builder.AddDirective("recipes")
                .AddDirective("search")
                .AddParam("output", itemID.ToString())
                .RequestAsync<List<int>>();
        }
        #endregion Recipes

        #region Mystic Forge
        public static Task<List<RecipeMysticForge>> SearchMysticForgeRecipesByOutput(int ID)
        {
            return Builder/*.AddParam("disciplines", "Mystic Forge")*/      //Weird API thing with AND OR
                .AddParam("output_ids", ID.ToString())
                .RequestAsync<List<RecipeMysticForge>>(Network.API.Profits);
        }

        public static Task<List<RecipeMysticForge>> SearchMysticForgeRecipesByOutput(List<int> ID)
        {
            return Builder/*.AddParam("disciplines", "Mystic%20Forge")*/    //Weird API thing with AND OR
                .AddParam("output_ids", ID)
                .RequestAsync<List<RecipeMysticForge>>(Network.API.Profits);
        }
        #endregion Mystic Forge

        #region Material Storage
        public static Task<List<int>> MaterialIDs()
        {
            return Builder.AddDirective("materials")
                .RequestAsync<List<int>>();
        }

        public static Task<List<MaterialCategory>> Materials()
        {
            return Builder.AddDirective("materials")
                .AddParam("ids", "all")
                .RequestAsync<List<MaterialCategory>>();
        }

        public static Task<List<MaterialCategory>> Materials(int pageCount, int page)
        {
            return Builder.AddDirective("materials")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<MaterialCategory>>();
        }

        public static Task<MaterialCategory> Materials(int ID)
        {
            return Builder.AddDirective("materials")
                .AddDirective(ID.ToString())
                .RequestAsync<MaterialCategory>();
        }

        public static Task<List<MaterialCategory>> Materials(List<int> IDs)
        {
            return Builder.AddDirective("materials")
                .AddParam("ids", IDs)
                .RequestAsync<List<MaterialCategory>>();
        }
        #endregion Material Storage

        #region ItemStats
        public static Task<List<int>> StatPrefixIDs()
        {
            return Builder.AddDirective("itemstats")
                .RequestAsync<List<int>>();
        }

        public static Task<List<ItemStats>> StatPrefixes()
        {
            return Builder.AddDirective("itemstats")
                .AddParam("ids", "all")
                .RequestAsync<List<ItemStats>>();
        }

        public static Task<List<ItemStats>> StatPrefixes(int pageCount, int page)
        {
            return Builder.AddDirective("itemstats")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<ItemStats>>();
        }

        public static Task<ItemStats> StatPrefixes(int ID)
        {
            return Builder.AddDirective("itemstats")
                .AddDirective(ID.ToString())
                .RequestAsync<ItemStats>();
        }

        public static Task<List<ItemStats>> StatPrefixes(List<int> IDs)
        {
            return Builder.AddDirective("itemstats")
                .AddParam("ids", IDs)
                .RequestAsync<List<ItemStats>>();
        }
        #endregion ItemStats

        #region Items
        public static Task<List<int>> ItemIDs()
        {
            return Builder.AddDirective("items")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Item>> Items(int pageCount, int page)
        {
            return Builder.AddDirective("items")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Item>>();
        }

        public static Task<Item> Items(int ID)
        {
            return Builder.AddDirective("items")
                .AddDirective(ID.ToString())
                .RequestAsync<Item>();
        }

        public static Task<List<Item>> Items(List<int> IDs)
        {
            return Builder.AddDirective("items")
                .AddParam("ids", IDs)
                .RequestAsync<List<Item>>();
        }
        #endregion ItemStats

        public static Task<List<ItemSearchResult>> SearchByName(string name)
        {
            return Builder.AddDirective("idbyname")
                .AddDirective(name)
                .RequestAsync<List<ItemSearchResult>>(Network.API.Shinies);
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