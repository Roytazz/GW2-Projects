using GuildWars2.API.Model.Items;
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

        public Task<List<ValueResult<Skin>>> CalculateValue(List<Skin> items, bool takeHighestValue) {
            throw new NotImplementedException();    //Get all items with the given SkinID and compare their values. 
        }                                           //To do this, we want to index all items first, instead of calling the API every time.

        public bool IsApplicable(Skin item) {
            return true;
        }
    }
}
