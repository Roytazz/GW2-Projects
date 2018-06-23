using GuildWars2.API.Items;
using GuildWars2.API.Model;
using GuildWars2.API.Model.Items;
using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Worker.Values
{
    public class CraftingValueService : IValueService<Item>
    {
        public async Task<List<ValueResult<Item>>> CalculateValue(List<Item> entities, bool takeHighestValue) {
            var cachedItems = await CheckCache(entities);
            entities = entities.Where(x => !cachedItems.Select(y => y.Item.ID).Contains(x.ID)).ToList();

            var recipes = new List<ItemRecipeTreeNode>();
            foreach (var item in entities) {
                var recipe = new ItemRecipeTreeNode(item.ID);
                await recipe.Populate();
                recipes.Add(recipe);
            }
            
            var result = new List<ValueResult<Item>>();
            var values = await ValueFactory.CalculateValue(recipes, takeHighestValue);
            foreach (var item in entities) {
                result.Add(new ValueResult<Item> {
                    Item = item,
                    Value = values.FirstOrDefault(x => x.Item.ItemID == item.ID)?.Value
                });
            }
            AddCache(result);

            result.AddRange(cachedItems);
            return result;
        }

        public bool IsApplicable(Item item) {
            return item.Rarity == ItemRarity.Ascended;
        }

        private async Task<List<ValueResult<Item>>> CheckCache(List<Item> entities) {
#pragma warning disable CS0618
            IAppCache cache = new CachingService();
#pragma warning restore CS0618

            var result = new List<ValueResult<Item>>();
            foreach (var entity in entities) {
                var item = await cache.GetAsync<ValueResult<Item>>($"{nameof(CraftingValueService)}-{entity.ID}");
                if (item != null)
                    result.Add(item);
            }
            return result;
        }

        private void AddCache(List<ValueResult<Item>> entities) {
#pragma warning disable CS0618
            IAppCache cache = new CachingService();
#pragma warning restore CS0618

            foreach (var entity in entities) {
                cache.GetOrAdd($"{nameof(CraftingValueService)}-{entity.Item.ID}", () => entity, new TimeSpan(0,5,0));
            }
        }
    }
}
