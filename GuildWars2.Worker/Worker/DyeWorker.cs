using GuildWars2.API;
using GuildWars2.Data;
using GuildWars2.Data.Model;
using GuildWars2.Value;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker
{
    public class DyeWorker : IAccountWorker
    {
        public async Task Run(CancellationToken token, params string[] apiKeys) {
            await Run(token, apiKeys.ToList());
        }

        public async Task Run(CancellationToken token, List<string> apiKeys) {
            foreach (var apiKey in apiKeys) {                  
                token.ThrowIfCancellationRequested();
                var currentDyes = await GetAccountDyes(apiKey);
                var savedDyes = await UserAPI.GetAccountDyes(apiKey);
                var newDyes = currentDyes.Where(x => !savedDyes.Any(y => y.DyeID == x.ID)).ToList();
                if(newDyes.Count > 0)
                    await UserAPI.AddDyes(newDyes, apiKey);

                var values = await ValueFactory.CalculateValue(currentDyes);
                if (values.Count > 0)
                    await UserAPI.AddCategoryEntry(CategoryType.Dyes, values.Where(x => x.Value != null).Sum(x => x.Value.Coins), apiKey);
            }
        }

        private async Task<List<API.Model.Items.Item>> GetAccountDyes(string apiKey) {
            var dyes = await AccountAPI.Dyes(apiKey);
            var colors = await MiscellaneousAPI.Colors(dyes);
            return await ItemAPI.Items(colors.Select(x => x.Item).ToList());
        }
    }
}