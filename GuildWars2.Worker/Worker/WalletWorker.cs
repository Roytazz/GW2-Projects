using GuildWars2.API;
using GuildWars2.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker
{
    public class WalletWorker : IAccountWorker
    {
        public async Task Run(CancellationToken token, params string[] apiKeys) {
            await Run(token, apiKeys.ToList());
        }

        public async Task Run(CancellationToken token, List<string> apiKeys) {
            foreach (var apiKey in apiKeys) {
                var wallet = await AccountAPI.Wallet(apiKey);
                await UserAPI.AddWalletEntries(wallet, apiKey);
            }
        }
    }
}