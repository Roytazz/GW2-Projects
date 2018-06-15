using GuildWars2.API.Items;
using GuildWars2.API.Model;
using GuildWars2.API.Model.Items;
using GuildWars2.Value;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Worker.Values
{
    public class CraftingValueService : IValueService<Item>
    {
        public async Task<List<ValueResult<Item>>> CalculateValue(List<Item> entities, bool takeHighestValue) {
            var recipes = new List<ItemRecipeTreeNode>();
            foreach (var item in entities) {
                var recipe = new ItemRecipeTreeNode(item.ID);
                await recipe.Populate();
                recipes.Add(recipe);
            }

            var result = new List<ValueResult<Item>>();
            var values = await Value.ValueFactory.CalculateValue(recipes, takeHighestValue);
            foreach (var item in entities) {
                result.Add(new ValueResult<Item> {
                    Item = item,
                    Value = values.FirstOrDefault(x => x.Item.ItemID == item.ID)?.Value
                });
            }
            return result;
        }

        public bool IsApplicable(Item item) {
            return item.Rarity == ItemRarity.Ascended;
        }
    }
}
