using GuildWars2.API;
using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using GuildWars2.Data.Database;
using GuildWars2.Data.Model;
using GuildWars2.Value;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker.Worker
{
    public class DyeWorker : IWorker
    {
        public async Task Run(CancellationToken token, params string[] apiKeys) {
            foreach (var key in apiKeys) {
                token.ThrowIfCancellationRequested();
                var dyes = await GetAccountDyes(key);
                var values = await ValueFactory.CalculateValue(dyes);
                var totalValue = values.Sum(x => x.Value.Coins);
                using (var db = new DataContextFactory().CreateDbContext()) {
                    var user = db.User.FirstOrDefault(x => x.ID == db.Key.FirstOrDefault(y => y.APIKey.Equals(key)).UserID);
                    if (user == null)
                        continue;

                    var latestEntry = db.CategoryValue.Where(x => x.UserID == user.ID && x.CategoryID == (int)CategoryType.Dyes).OrderByDescending(x => x.Date).FirstOrDefault();
                    if (latestEntry == null)
                        latestEntry = new CategoryValue { Value = 0 };
                    db.CategoryValue.Add(new CategoryValue { CategoryID = (int)CategoryType.Dyes, Value = totalValue, Delta = totalValue - latestEntry.Value });

                    var currentDyes = db.Dye.Where(x => x.UserID == user.ID).ToList();
                    var newDyes = dyes.Where(x => !currentDyes.Any(y => y.DyeID == x.ID));
                    var dyesToAdd = new List<Dye>();
                    foreach (var dye in newDyes) {
                        dyesToAdd.Add(new Dye { DyeID = dye.ID, UserID = user.ID });
                    }
                    db.Dye.AddRange(dyesToAdd);

                    //await db.SaveChangesAsync();
                }
            }
        }

        private async Task<List<API.Model.Items.Item>> GetAccountDyes(string apiKey) {
            var dyes = await AccountAPI.Dyes(apiKey);
            var colors = await MiscellaneousAPI.Colors(dyes);
            return await ItemAPI.Items(colors.Select(x => x.Item).ToList());
        }

        private async Task<ItemPrice> GetDyeValue(API.Model.Items.Item dye) {
            var result = await ValueFactory.CalculateValue(dye);
            return result.Value;
        }
    }
}
