using GuildWars2.API;
using GuildWars2.Data;
using GuildWars2.Data.Model;
using GuildWars2.Worker.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker
{
    public class SkinWorker : IUserWorker
    {
        public event EventHandler<WorkerStartedEventArgs> WorkerStarted;
        public event EventHandler<WorkerProgressEventArgs> ProgressChanged;
        public event EventHandler<WorkerFinishedEventArgs> WorkerFinished;

        public async Task Run(CancellationToken token, params string[] apiKeys) {
            await Run(token, apiKeys.ToList());
        }

        public async Task Run(CancellationToken token, List<string> apiKeys) {
            WorkerStarted?.Invoke(this, new WorkerStartedEventArgs { WorkerType = GetType() });
            var startTime = DateTime.Now;

            foreach (var apiKey in apiKeys) {
                token.ThrowIfCancellationRequested();
                var overallProgress = (int)Math.Round(((double)apiKeys.IndexOf(apiKey) / apiKeys.Count) * 100, 0);

                SetProgress("Retrieving unlocked skins", 0, overallProgress);
                var currentSkins = await GetAccountSkins(apiKey);
                SetProgress("Retrieving unlocked skins", 15, overallProgress);
                var savedSkins = await UserAPI.GetAccountSkins(apiKey);
                SetProgress("Saving new skins", 30, overallProgress);
                var newSkins = currentSkins.Where(x => !savedSkins.Any(y => y.SkinID == x.ID)).ToList();
                if (newSkins.Count > 0)
                    await UserAPI.AddSkins(newSkins, apiKey);

                SetProgress("Calculating total skin value", 40, overallProgress);
                var values = await ValueFactory.CalculateValue(currentSkins);
                if (values.Count > 0) {
                    SetProgress("Saving total skin value", 95, overallProgress);
                    await UserAPI.AddCategoryEntry(CategoryValueType.Skins, values.Where(x => x.Value != null).Sum(x => x.Value.Coins), apiKey);
                }
            }
            WorkerFinished?.Invoke(this, new WorkerFinishedEventArgs { WorkerType = GetType(), Duration = DateTime.Now - startTime });
        }

        private async Task<List<API.Model.Items.Skin>> GetAccountSkins(string apiKey) {
            var skinIDs = await AccountAPI.Skins(apiKey);
            return await ItemAPI.Skins(skinIDs);
        }

        private void SetProgress(string msg, int partialProgress, int overallProgress) {
            ProgressChanged?.Invoke(this, new WorkerProgressEventArgs { Message = msg, PartialProgress = partialProgress, OverallProgress = overallProgress });
        }
    }
}