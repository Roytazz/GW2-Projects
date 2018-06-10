using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using GuildWars2.Data.Endpoints;
using GuildWars2.Value;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Worker.ValueService
{
    public class TPValueService : IValueService<Item>
    {
        public async Task<List<ValueResult<Item>>> CalculateValue(List<Item> items, bool takeHighestValue) {
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
                    if (takeHighestValue) 
                        result.Add(new ValueResult<Item> { Item = item, Value = listing.Sells?.Price });
                    else 
                        result.Add(new ValueResult<Item> { Item = item, Value = listing.Buys?.Price });
                }
                else
                    result.Add(new ValueResult<Item> { Item = item });
            }
            return result;
        }

        public bool IsApplicable(Item item) {
            return true;
        }
    }
}