using GuildWars2.API.Model.Items;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.API.Items
{
    public class ItemRecipeTreeNode
    {
        public int ItemID { get; set; }

        public int ItemCount { get; set; }

        public List<ItemRecipeTreeNode> Children { get; set; }

        private List<Recipe> _recipes;
        private int _currentRecipeIndex = 0;

        public ItemRecipeTreeNode(int itemID, int itemCount = 1) {
            _recipes = new List<Recipe>();
            Children = new List<ItemRecipeTreeNode>();
            ItemID = itemID;
            ItemCount = itemCount;
        }

        public async Task ChangeRecipe() {
            if (_recipes.Count <= 1)
                return;

            var newIndex = _currentRecipeIndex + 1;
            if(newIndex >= _recipes.Count) {
                _currentRecipeIndex = 0;
            }
            else {
                _currentRecipeIndex = newIndex;
            }
            await Populate();
        }

        /// <summary>
        /// Used to override a recipe or select a specific one.
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public async Task ChangeRecipe(int recipeID) {
            if (_recipes.Any(x => x.ID == recipeID)) {
                _currentRecipeIndex = _recipes.IndexOf(_recipes.FirstOrDefault(x => x.ID == recipeID));
            }
            else {
                var newRecipe = await ItemAPI.Recipes(recipeID);
                _recipes = new List<Recipe> { newRecipe };
                _currentRecipeIndex = 0;
            }
            await Populate();
        }

        public Recipe CurrentRecipe() {
            return _recipes[_currentRecipeIndex];
        }

        public async Task Populate() {
            await PopulateRecipe();
            await PopulateChildren();
        }

        private async Task PopulateRecipe() {
            var _recipeIDs = await ItemAPI.SearchRecipesByOutput(ItemID);
            if (_recipeIDs?.Count > 0) {                                                                //Check for normal recipe
                _recipes = await ItemAPI.Recipes(_recipeIDs);
            }
            /*else if (!ItemAPI.IsPromotionItem(ItemID)) {                                              //Check for Mystic Forge recipe
                var mysticForgeRecipes = await ItemAPI.SearchMysticForgeRecipesByOutput(ItemID);

                if (mysticForgeRecipes?.Count > 0) {
                    _recipe = mysticForgeRecipes[0];
                    foreach (var recipe in mysticForgeRecipes) {
                        _recipeIDs.Add(recipe.ID);
                    }
                }
            }*/
            /*else {                                                                                    //This should onlu occur when the item is a consumable recipe
                if (_item == null)
                    _item = await ItemAPI.Items(ItemID);

                if (_item?.Details != null && _item?.Details.RecipeID != 0) {          
                    _recipeIDs.Add(_item.Details.RecipeID);                                              
                    _recipe = await ItemAPI.Recipes(_item.Details.RecipeID);
                }
            }*/
        }

        private async Task PopulateChildren() {
            if (_recipes?.Count <= _currentRecipeIndex || _recipes?[_currentRecipeIndex] == null)
                return;

            foreach (RecipeIngredient ingredient in _recipes[_currentRecipeIndex].Ingredients) {
                var node = new ItemRecipeTreeNode(ingredient.ItemID, ItemCount * ingredient.Count);
                await node.Populate();
                Children.Add(node);
            }
        }
    }
}