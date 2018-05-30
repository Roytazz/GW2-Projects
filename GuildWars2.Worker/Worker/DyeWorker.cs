using GuildWars2.API;
using GuildWars2.Data;
using GuildWars2.Data.Model;
using GuildWars2.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker
{
    public class DyeWorker : IUserWorker
    {
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        public async Task Run(CancellationToken token, params string[] apiKeys) {
            await Run(token, apiKeys.ToList());
        }

        public async Task Run(CancellationToken token, List<string> apiKeys) {
            foreach (var apiKey in apiKeys) {
                token.ThrowIfCancellationRequested();
                var overallProgress = (apiKeys.IndexOf(apiKey) / apiKeys.Count) * 100;

                SetProgress("Retrieving unlocked dyes", 0, overallProgress);
                var currentDyes = await GetAccountDyes(apiKey);
                SetProgress("Retrieving unlocked dyes", 25, overallProgress);
                var savedDyes = await UserAPI.GetAccountDyes(apiKey);

                SetProgress("Saving new dyes", 50, overallProgress);
                var newDyes = currentDyes.Where(x => !savedDyes.Any(y => y.DyeID == x.ID)).ToList();
                if(newDyes.Count > 0)
                    await UserAPI.AddDyes(newDyes, apiKey);

                SetProgress("Calculating total dye value", 65, overallProgress);
                var values = await ValueFactory.CalculateValue(currentDyes);
                if (values.Count > 0) {
                    SetProgress("Saving total dye value", 90, overallProgress);
                    await UserAPI.AddCategoryEntry(CategoryType.Dyes, values.Where(x => x.Value != null).Sum(x => x.Value.Coins), apiKey);
                }
            }
        }

        private async Task<List<API.Model.Items.Item>> GetAccountDyes(string apiKey) {
            var dyes = await AccountAPI.Dyes(apiKey);
            var colors = await MiscellaneousAPI.Colors(dyes);
            return await ItemAPI.Items(colors.Select(x => x.Item).ToList());
        }

        private void SetProgress(string msg, int partialProgress, int overallProgress) {
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs { Message = msg, PartialProgress = partialProgress, OverallProgress = overallProgress });
        }
    }
}