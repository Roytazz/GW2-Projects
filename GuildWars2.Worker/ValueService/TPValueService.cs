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
        public async Task<ValueResult<Item>> CalculateValue(Item item, bool takeHighestValue) {
            var result = await CalculateValue(new List<Item> { item }, takeHighestValue);
            return result.FirstOrDefault();
        }

        public async Task<List<ValueResult<Item>>> CalculateValue(List<Item> items, bool takeHighestValue) {
            var sellableItems = await DataAPI.GetItemSellable(items.Select(x => x.ID).ToList());
            var listings = await API.CommerceAPI.ListingsAggregated(sellableItems);
            if (listings == null)
                return null;

            var result = new List<ValueResult<Item>>();
            foreach (var item in items) {
                if (listings.Any(x => x.ItemID == item.ID)) {
                    if (takeHighestValue)
                        result.Add(new ValueResult<Item> { Item = item, Value = listings.Where(x => x.ItemID == item.ID).FirstOrDefault().Sells?.Price });
                    else
                        result.Add(new ValueResult<Item> { Item = item, Value = listings.Where(x => x.ItemID == item.ID).FirstOrDefault().Buys?.Price });
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