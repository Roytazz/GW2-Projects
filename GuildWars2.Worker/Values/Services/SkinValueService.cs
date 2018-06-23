using GuildWars2.API;
using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using GuildWars2.Data.Endpoints;
using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Worker.Values.Services
{
    public class SkinValueService : IValueService<Skin>
    {
        public async Task<List<ValueResult<Skin>>> CalculateValue(List<Skin> items, bool takeHighestValue) {
            var cachedItems = await CheckCache(items);
            items = items.Where(x => !cachedItems.Select(y => y.Item.ID).Contains(x.ID)).ToList();

            var skinItemGrps = await DataAPI.GetSkinItemGroups(items.Select(x => x.ID).ToList());
            List<int> ids = new List<int>();
            foreach (var IDGroup in skinItemGrps.Values) {
                ids.AddRange(IDGroup);
            }
            var sellableItems = await DataAPI.GetItemSellable(ids);
            var allListings = new List<ItemListingAggregated>();
            if(sellableItems.Count > 0)
                allListings = await CommerceAPI.ListingsAggregated(sellableItems);

            var results = new List<ValueResult<Skin>>();
            foreach (var skin in skinItemGrps) {
                if(!allListings.Any(x => skin.Value.Contains(x.ItemID))) {
                    results.Add(new ValueResult<Skin> { Item = items.Where(x => x.ID == skin.Key).FirstOrDefault() });
                }
                else if (takeHighestValue) {
                    var listing = allListings.Where(x => skin.Value.Contains(x.ItemID)).OrderBy(x => x.Sells.Price).FirstOrDefault();
                    results.Add(new ValueResult<Skin> { Item = items.Where(x=>x.ID == skin.Key).FirstOrDefault(), Value = listing?.Sells.Price });
                }
                else {
                    var listing = allListings.Where(x => skin.Value.Contains(x.ItemID)).OrderBy(x => x.Sells.Price).FirstOrDefault();
                    results.Add(new ValueResult<Skin> { Item = items.Where(x => x.ID == skin.Key).FirstOrDefault(), Value = listing?.Buys.Price });
                }
            }
            AddCache(results);

            results.AddRange(cachedItems);
            return results;                      
        }                                           

        public bool IsApplicable(Skin item) {
            return true;
        }

        private async Task<List<ValueResult<Skin>>> CheckCache(List<Skin> entities) {
#pragma warning disable CS0618
            IAppCache cache = new CachingService();
#pragma warning restore CS0618

            var result = new List<ValueResult<Skin>>();
            foreach (var entity in entities) {
                var item = await cache.GetAsync<ValueResult<Skin>>($"{nameof(SkinValueService)}-{entity.ID}");
                if (item != null)
                    result.Add(item);
            }
            return result;
        }

        private void AddCache(List<ValueResult<Skin>> entities) {
#pragma warning disable CS0618
            IAppCache cache = new CachingService();
#pragma warning restore CS0618

            foreach (var entity in entities) {
                cache.GetOrAdd($"{nameof(SkinValueService)}-{entity.Item.ID}", () => entity, new TimeSpan(0, 5, 0));
            }
        }
    }
}
