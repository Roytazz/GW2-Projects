using GuildWars2.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GuildWars2.Data.DataAPI;

namespace GuildWars2.Data
{
    public class WalletAPI
    {
        public static async Task AddWalletEntries(List<API.Model.Account.WalletEntry> entries, string apiKey) {
            using (var db = new ContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user == null)
                    return;

                foreach (var entry in entries) {
                    var latestEntry = db.Wallet.Where(x => x.UserID == user.ID && x.CurrencyID == entry.ID).OrderByDescending(x => x.Date).FirstOrDefault();
                    if(latestEntry != null)
                        db.Wallet.Add(new Model.WalletEntry { UserID = user.ID, CurrencyID = entry.ID, Value = entry.Value, Delta = entry.Value - latestEntry.Value });
                    else
                        db.Wallet.Add(new Model.WalletEntry { UserID = user.ID, CurrencyID = entry.ID, Value = entry.Value });
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
