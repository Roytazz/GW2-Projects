using GuildWars2API;
using GuildWars2API.Model.Items;
using System.Collections.Generic;

namespace GuildWars2Value.Recipes
{
    public class ItemRecipeTreeNode
    {
        private Item _item;
        private Recipe _recipe;
        private List<int> _recipeIDs;

        public List<ItemRecipeTreeNode> Children { get; set; }

        public int ItemID { get; set; }

        public Item Item {
            get {
                if (_item == null)
                    Item = ItemAPI.Items(ItemID);

                return _item;
            }
            protected set {
                _item = value;
            }
        }

        public ItemRecipeTreeNode(int itemID) {
            _recipeIDs = new List<int>();
            Children = new List<ItemRecipeTreeNode>();
            ItemID = itemID;

            PopulateRecipe();
            PopulateChildren();
        }

        private void PopulateRecipe() {
            _recipeIDs = ItemAPI.SearchRecipesByOutput(ItemID);
            if (_recipeIDs?.Count > 0) {                                                            //Check for normal recipe
                _recipe = ItemAPI.Recipes(_recipeIDs[0]);
            }
            else if (!ItemAPI.IsPromotionItem(ItemID)) {                                            //Check for Mystic Forge recipe
                var mysticForgeRecipes = ItemAPI.SearchMysticForgeRecipesByOutput(ItemID);

                if (mysticForgeRecipes?.Count > 0) {
                    _recipe = mysticForgeRecipes[0];
                    foreach (var recipe in mysticForgeRecipes) {
                        _recipeIDs.Add(recipe.ID);
                    }
                }
            }
            else {
                Item = ItemAPI.Items(ItemID);
                if (Item != null && Item.Details != null && Item.Details.RecipeID != 0) {          //Check for weird recipe in Item.Details
                    _recipeIDs.Add(Item.Details.RecipeID);                                         //This forces us to load the Item object.
                    _recipe = ItemAPI.Recipes(Item.Details.RecipeID);
                }
            }
        }

        private void PopulateChildren() {
            if (_recipe == null)
                return;

            foreach (RecipeIngredient ingredient in _recipe?.Ingredients) {
                Children.Add(new ItemRecipeTreeNode(ingredient.ItemID));
            }
        }

        public ItemRecipeTreeNode(Item item) : this(item.ID) { Item = item; }
    }
}
