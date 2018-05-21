using GuildWars2.API.Model.Items;
using GuildWars2.Data.Endpoints;
using GuildWars2.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Worker.ValueService
{
    class SkinValueService : IValueService<Skin>
    {
        public async Task<ValueResult<Skin>> CalculateValue(Skin item, bool takeHighestValue) {
            var result = await CalculateValue(new List<Skin> { item }, takeHighestValue);
            return result.FirstOrDefault();
        }

        public async Task<List<ValueResult<Skin>>> CalculateValue(List<Skin> items, bool takeHighestValue) {
            var skinItems = await DataAPI.GetItems((x) => items.Select(y=>y.ID).Contains(x.DefaultSkin));
            skinItems = skinItems.GroupBy(x => x.ID).Select(x => x.First()).ToList();
            var values = await ValueFactory.CalculateValue(skinItems, takeHighestValue);
            values = values.Where(x => x.Value != null).ToList();

            var results = new List<ValueResult<Skin>>();
            foreach (var skin in items) {
                var highestValue = values.Where(x => x.Item.DefaultSkin == skin.ID).OrderByDescending(x => x.Value?.Coins).FirstOrDefault();
                results.Add(new ValueResult<Skin> { Item = skin, Value = highestValue?.Value });
            }
            return results;                      
        }                                           

        public bool IsApplicable(Skin item) {
            return true;
        }
    }
}
