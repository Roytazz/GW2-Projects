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
            foreach (var listing in listings) {
                if(takeHighestValue)
                    result.Add(new ValueResult<Item> { Item = items.Where(x => x.ID == listing.ItemID).FirstOrDefault(), Value = listing.Sells?.Price });
                else
                    result.Add(new ValueResult<Item> { Item = items.Where(x => x.ID == listing.ItemID).FirstOrDefault(), Value = listing.Buys?.Price });
            }
            return result;
        }

        public bool IsApplicable(Item item) {
            return true;
        }
    }
}