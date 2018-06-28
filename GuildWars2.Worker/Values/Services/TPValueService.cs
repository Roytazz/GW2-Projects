using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using GuildWars2.Data.Endpoints;
using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static GuildWars2.Worker.Helper.CacheManager;

namespace GuildWars2.Worker.Values.Services
{
    public class TPValueService : IValueService<Item>
    {
        public async Task<List<ValueResult<Item>>> CalculateValue(List<Item> items, bool takeHighestValue) {
            var cachedItems = await CheckCache(items);
            items = items.Where(x => !cachedItems.Select(y => y.Item.ID).Contains(x.ID)).ToList();

            var result = new List<ValueResult<Item>>();
            if (items.Count <= 0)
                return result;

            var sellableItems = await DataAPI.GetItemSellable(items.Select(x => x.ID).ToList());
            var listings = new List<ItemListingAggregated>();
            if(sellableItems.Count > 0)
                listings = await API.CommerceAPI.ListingsAggregated(sellableItems);
            
            foreach (var item in items) {
                if (listings.Any(x => x.ItemID == item.ID)) {
                    var listing = listings.Where(x => x.ItemID == item.ID).FirstOrDefault();
                    if (takeHighestValue && listing.Sells.UnitPrice > listing.Buys.UnitPrice)   //Extra check in case there are no sells and only buys. Sells is 0 if there are none 
                        result.Add(new ValueResult<Item> { Item = item, Value = listing.Sells?.Price });
                    else
                        result.Add(new ValueResult<Item> { Item = item, Value = listing.Buys?.Price });
                }
                else
                    result.Add(new ValueResult<Item> { Item = item });
            }
            AddCache(result);

            result.AddRange(cachedItems);
            return result;
        }

        public bool IsApplicable(Item item) {
            return true;
        }

        private async Task<List<ValueResult<Item>>> CheckCache(List<Item> entities) {
#pragma warning disable CS0618
            IAppCache cache = new CachingService();
#pragma warning restore CS0618

            var result = new List<ValueResult<Item>>();
            foreach (var entity in entities) {
                var item = await cache.GetAsync<ValueResult<Item>>(GenerateKey(GetType(), entity.ID));
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
                cache.GetOrAdd(GenerateKey(GetType(), entity.Item.ID), () => entity, CACHE_DURATION);
            }
        }
    }
}