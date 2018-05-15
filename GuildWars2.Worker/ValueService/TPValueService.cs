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
    class TPValueService : IValueService<Item>
    {
        public int Priority => 0;

        public async Task<ValueResult<Item>> CalculateValueAsync(Item item) {
            var listing = await API.CommerceAPI.ListingsAggregated(item.ID);
            return new ValueResult<Item> { Item = item, Value = listing.Sells?.Price };
        }

        public async Task<List<ValueResult<Item>>> CalculateValue(List<Item> items) {
            var listings = await API.CommerceAPI.ListingsAggregated(items.ToList().Select(item => item.ID).ToList());
            if (listings == null)
                return null;

            var result = new List<ValueResult<Item>>();
            foreach (var listing in listings) {
                result.Add(new ValueResult<Item> { Item = items.Where(x => x.ID == listing.ItemID).FirstOrDefault(), Value = listing.Sells?.Price });
            }
            return result;
        }

        public bool IsApplicable(Item item) {
            return true;
        }
    }
}