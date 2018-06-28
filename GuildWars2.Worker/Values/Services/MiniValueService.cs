using GuildWars2.API;
using GuildWars2.API.Model.Miscellaneous;
using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static GuildWars2.Worker.Helper.CacheManager;

namespace GuildWars2.Worker.Values.Services
{
    public class MiniValueService : IValueService<Mini>
    {
        public async Task<List<ValueResult<Mini>>> CalculateValue(List<Mini> items, bool takeHighestValue) {
            var cachedItems = await CheckCache(items);
            items = items.Where(x => !cachedItems.Select(y => y.Item.ID).Contains(x.ID)).ToList();

            var miniIDs = items.Select(x => x.ItemID).ToList();
            var miniItems = await ItemAPI.Items(miniIDs);
            var values = await ValueFactory.CalculateValue(miniItems);

            var result = new List<ValueResult<Mini>>();
            foreach (var item in items) {
                var value = values.Where(x => x.Item.ID == item.ItemID).FirstOrDefault();
                result.Add(new ValueResult<Mini> {
                    Item = item,
                    Value = value?.Value
                });
            }
            AddCache(result);

            result.AddRange(cachedItems);
            return result;
        }                                  

        public bool IsApplicable(Mini item) {
            return true;
        }

        private async Task<List<ValueResult<Mini>>> CheckCache(List<Mini> entities) {
#pragma warning disable CS0618
            IAppCache cache = new CachingService();
#pragma warning restore CS0618

            var result = new List<ValueResult<Mini>>();
            foreach (var entity in entities) {
                var item = await cache.GetAsync<ValueResult<Mini>>(GenerateKey(GetType(), entity.ID));
                if (item != null)
                    result.Add(item);
            }
            return result;
        }

        private void AddCache(List<ValueResult<Mini>> entities) {
#pragma warning disable CS0618
            IAppCache cache = new CachingService();
#pragma warning restore CS0618

            foreach (var entity in entities) {
                cache.GetOrAdd(GenerateKey(GetType(), entity.Item.ID), () => entity, CACHE_DURATION);
            }
        }
    }
}
