using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using GuildWars2.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var listings = await API.CommerceAPI.ListingsAggregated(items.ToList().Select(item => item.ID).ToList());
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