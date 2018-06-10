using GuildWars2.API;
using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using GuildWars2.Data.Endpoints;
using GuildWars2.Value;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Worker.ValueService
{
    public class SkinValueService : IValueService<Skin>
    {
        public async Task<List<ValueResult<Skin>>> CalculateValue(List<Skin> items, bool takeHighestValue) {
            var skinItemGrps = await DataAPI.GetSkinItemGroups(items.Select(x => x.ID).ToList());
            List<int> ids = new List<int>();
            foreach (var IDGroup in skinItemGrps.Values) {
                ids.AddRange(IDGroup);
            }
            var sellableItems = await DataAPI.GetItemSellable(ids);
            var allListings = new List<ItemListingAggregated>();
            if(sellableItems.Count > 0)
                await CommerceAPI.ListingsAggregated(sellableItems);

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
            return results;                      
        }                                           

        public bool IsApplicable(Skin item) {
            return true;
        }
    }
}
