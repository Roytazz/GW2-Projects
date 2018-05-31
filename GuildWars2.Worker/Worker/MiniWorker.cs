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
    public class MiniWorker : IUserWorker
    {
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        public async Task Run(CancellationToken token, params string[] apiKeys) {
            await Run(token, apiKeys.ToList());
        }

        public async Task Run(CancellationToken token, List<string> apiKeys) {
            foreach (var apiKey in apiKeys) {
                token.ThrowIfCancellationRequested();
                var overallProgress = (int)Math.Round(((double)apiKeys.IndexOf(apiKey) / apiKeys.Count) * 100, 0);

                SetProgress("Retrieving unlocked minis", 0, overallProgress);
                var currentMinis = await GetAccountMinis(apiKey);
                SetProgress("Retrieving unlocked minis", 25, overallProgress);
                var savedMinis = await UserAPI.GetAccountMinis(apiKey);

                SetProgress("Saving new minis", 50, overallProgress);
                var newMinis = currentMinis.Where(x => !savedMinis.Any(y => y.MiniID == x.ID)).ToList();
                if (newMinis.Count > 0)
                    //await UserAPI.AddMinis(newMinis, apiKey);

                SetProgress("Calculating total mini value", 70, overallProgress);
                var values = await ValueFactory.CalculateValue(currentMinis);
                if (values.Count > 0) {
                    SetProgress("Saving total mini value", 90, overallProgress);
                    //await UserAPI.AddCategoryEntry(CategoryType.Minis, values.Where(x => x.Value != null).Sum(x => x.Value.Coins), apiKey);
                }
            }
        }

        private async Task<List<API.Model.Miscellaneous.Mini>> GetAccountMinis(string apiKey) {
            var miniIDs = await AccountAPI.Minis(apiKey);
            return await MiscellaneousAPI.Minis(miniIDs);
        }

        private void SetProgress(string msg, int partialProgress, int overallProgress) {
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs { Message = msg, PartialProgress = partialProgress, OverallProgress = overallProgress });
        }
    }
}