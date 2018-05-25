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
    public class MiniWorker : IAccountWorker
    {
        public async Task Run(CancellationToken token, params string[] apiKeys) {
            await Run(token, apiKeys.ToList());
        }

        public async Task Run(CancellationToken token, List<string> apiKeys) {
            foreach (var apiKey in apiKeys) {
                token.ThrowIfCancellationRequested();
                var currentMinis = await GetAccountMinis(apiKey);
                var savedMinis = await UserAPI.GetAccountMinis(apiKey);
                var newMinis = currentMinis.Where(x => !savedMinis.Any(y => y.MiniID == x.ID)).ToList();
                if (newMinis.Count > 0)
                    await UserAPI.AddMinis(newMinis, apiKey);

                var values = await ValueFactory.CalculateValue(currentMinis);
                if (values.Count > 0)
                    await UserAPI.AddCategoryEntry(CategoryType.Minis, values.Where(x => x.Value != null).Sum(x => x.Value.Coins), apiKey);
            }
        }

        private async Task<List<API.Model.Miscellaneous.Mini>> GetAccountMinis(string apiKey) {
            var miniIDs = await AccountAPI.Minis(apiKey);
            return await MiscellaneousAPI.Minis(miniIDs);
        }
    }
}