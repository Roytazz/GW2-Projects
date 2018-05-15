using GuildWars2.Value;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace GuildWars2.Worker.ValueService
{
    class RecipeValueService : IValueService<ItemRecipeTreeNode>
    {
        public async Task<ValueResult<ItemRecipeTreeNode>> CalculateValueAsync(ItemRecipeTreeNode item) {
            var result = await CalculateValue(new List<ItemRecipeTreeNode> { item });
            return result.FirstOrDefault();
        }

        public Task<List<ValueResult<ItemRecipeTreeNode>>> CalculateValue(List<ItemRecipeTreeNode> items) {
            throw new NotImplementedException();    //TODO Calculate value of recipe (need to compare all available recipes to find the lowest/higest value recipe)
        }

        public bool IsApplicable(ItemRecipeTreeNode item) {
            return true;
        }
    }
}
