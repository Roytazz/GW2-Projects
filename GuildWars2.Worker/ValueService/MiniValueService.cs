using GuildWars2.API;
using GuildWars2.API.Model.Miscellaneous;
using GuildWars2.Value;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Worker.ValueService
{
    public class MiniValueService : IValueService<Mini>
    {
        public async Task<ValueResult<Mini>> CalculateValue(Mini item, bool takeHighestValue) {
            var result = await CalculateValue(new List<Mini> { item }, takeHighestValue);
            return result.FirstOrDefault();
        }

        public async Task<List<ValueResult<Mini>>> CalculateValue(List<Mini> items, bool takeHighestValue) {
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
            return result;
        }                                  

        public bool IsApplicable(Mini item) {
            return true;
        }
    }
}
