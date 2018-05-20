using GuildWars2.API;
using GuildWars2.Data.Database;
using GuildWars2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Data
{
    /// <summary>
    /// An easy acces point to communicate with the Database
    /// </summary>
    public static class DataAPI            
    {
        private static GW2DataContext DBContext { get; } = new ContextFactory().CreateDbContext();

        public async static Task AddCategoryEntry(CategoryType type, int value, string apiKey) {
            using (var db = new ContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user == null)
                    return;

                var latestEntry = db.CategoryValue.Where(x => x.UserID == user.ID && x.Category == type).OrderByDescending(x => x.Date).FirstOrDefault();
                if (latestEntry == null)
                    db.CategoryValue.Add(new CategoryValue { Category = type, Value = value, Delta = 0, UserID = user.ID });
                else
                    db.CategoryValue.Add(new CategoryValue { Category = type, Value = value, Delta = value - latestEntry.Value, UserID = user.ID });

                await db.SaveChangesAsync();
            }
        }

        internal static User GetUser(string apiKey) {
            using (var db = new ContextFactory().CreateDbContext()) {
                if (db.Key.Any(x => x.APIKey.Equals(apiKey))) {
                    var key = db.Key.FirstOrDefault(x => x.APIKey.Equals(apiKey));
                    return db.User.FirstOrDefault(x => x.ID == key.UserID);
                }
                else
                    return null;
            }
        }

        public static async Task AddUser(string apiKey) {
            using (var db = new ContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user == null) {
                    var account = await AccountAPI.Account(apiKey);
                    if (db.User.Any(x => x.AccountName.Equals(account.Name))) {
                        var existingUser = db.User.FirstOrDefault(x => x.AccountName.Equals(account.Name));
                        db.Key.Add(new Key { UserID = existingUser.ID, APIKey = apiKey });
                    }
                    else {
                        var addedUser = db.User.Add(new User { AccountName = account.Name });
                        await db.SaveChangesAsync();

                        db.Key.Add(new Key { UserID = addedUser.Entity.ID, APIKey = apiKey });
                    }
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
