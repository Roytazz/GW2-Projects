using GuildWars2.API;
using GuildWars2.Data.Database;
using GuildWars2.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Data
{
    /// <summary>
    /// An easy acces point to communicate with the User Data DB
    /// </summary>
    public static class UserAPI            
    {
        #region Items
        public static async Task AddAccountItems(List<Item> items, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(apiKey);
                if (user == null)
                    return;

                var currentItems = await db.Item.Where(x => x.UserID == user.ID).ToListAsync();
                var newItems = GetDifference(items, currentItems);
                newItems.ForEach(x => x.UserID = user.ID);

                db.RemoveRange(currentItems);
                db.AddRange(newItems);

                await db.SaveChangesAsync();
            }
        }
        #endregion Items

        #region Dyes
        public static async Task<List<Dye>> GetAccountDyes(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(apiKey);
                if (user != null)
                    return await db.Dye.Where(x => x.UserID == user.ID).ToListAsync();
            }
            return new List<Dye>();
        }

        public static async Task AddDyes(List<API.Model.Items.Item> dyes, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(apiKey);
                if (user == null)
                    return;
                foreach (var dye in dyes) {
                    db.Dye.Add(new Dye { DyeID = dye.ID, UserID = user.ID });
                }
                await db.SaveChangesAsync();
            }
        }
        #endregion Dyes

        #region Minis
        public static async Task<List<Mini>> GetAccountMinis(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(apiKey);
                if (user != null)
                    return await db.Mini.Where(x => x.UserID == user.ID).ToListAsync();
            }
            return new List<Mini>();
        }

        public static async Task AddMinis(List<API.Model.Miscellaneous.Mini> minis, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(apiKey);
                if (user == null)
                    return;
                foreach (var mini in minis) {
                    db.Mini.Add(new Mini { MiniID = mini.ID, ItemID = mini.ItemID, UserID = user.ID });
                }
                await db.SaveChangesAsync();
            }
        }
        #endregion Minis

        #region Skins
        public static async Task<List<Skin>> GetAccountSkins(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(apiKey);
                if (user != null)
                    return await db.Skin.Where(x => x.UserID == user.ID).ToListAsync();
            }
            return new List<Skin>();
        }

        public static async Task AddSkins(List<API.Model.Items.Skin> skins, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(apiKey);
                if (user == null)
                    return;
                foreach (var skin in skins) {
                    db.Skin.Add(new Skin { SkinID = skin.ID, UserID = user.ID });
                }
                await db.SaveChangesAsync();
            }
        }
        #endregion Skins

        #region Wallet
        public static async Task AddWalletEntries(List<API.Model.Account.WalletEntry> entries, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(apiKey);
                if (user == null)
                    return;

                foreach (var entry in entries) {
                    var latestEntry = await db.Wallet.Where(x => x.UserID == user.ID && x.CurrencyID == entry.ID).OrderByDescending(x => x.Date).FirstOrDefaultAsync();
                    if (latestEntry != null)
                        db.Wallet.Add(new Model.WalletEntry { UserID = user.ID, CurrencyID = entry.ID, Value = entry.Value, Delta = entry.Value - latestEntry.Value });
                    else
                        db.Wallet.Add(new Model.WalletEntry { UserID = user.ID, CurrencyID = entry.ID, Value = entry.Value });
                }
                await db.SaveChangesAsync();
            }
        }
        #endregion Wallet

        #region Category
        public async static Task AddCategoryEntry(CategoryType type, int value, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(apiKey);
                if (user == null)
                    return;

                var latestEntry = await db.CategoryValue.Where(x => x.UserID == user.ID && x.Category == type).OrderByDescending(x => x.Date).FirstOrDefaultAsync();
                if (latestEntry == null)
                    db.CategoryValue.Add(new CategoryValue { Category = type, Value = value, Delta = 0, UserID = user.ID });
                else
                    db.CategoryValue.Add(new CategoryValue { Category = type, Value = value, Delta = value - latestEntry.Value, UserID = user.ID });

                await db.SaveChangesAsync();
            }
        }
        #endregion Category

        #region User
        internal static async Task<User> GetUser(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (db.Key.Any(x => x.APIKey.Equals(apiKey))) {
                    var key = await db.Key.FirstOrDefaultAsync(x => x.APIKey.Equals(apiKey));
                    return await db.User.FirstOrDefaultAsync(x => x.ID == key.UserID);
                }
                else
                    return null;
            }
        }

        public static async Task AddUser(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(apiKey);
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
        #endregion User

        private static List<Item> GetDifference(List<Item> newItems, List<Item> oldItems) {
            var result = new List<Item>();
            foreach (var newItem in newItems) {
                if(oldItems.Any(x=>x.ItemID == newItem.ItemID && x.SkinID == newItem.SkinID && x.StatID == newItem.StatID)) {
                    var oldItem = oldItems.FirstOrDefault(x => x.ItemID == newItem.ItemID && x.SkinID == newItem.SkinID && x.StatID == newItem.StatID);
                    result.Add(new Item {
                        ItemID = newItem.ItemID,
                        SkinID = newItem.SkinID,
                        StatID = newItem.StatID,
                        Amount = newItem.Amount,
                        Delta = newItem.Amount - oldItem.Amount
                    });
                }
                else {
                    result.Add(newItem);
                }
            }

            foreach (var oldItem in oldItems) {
                if (!newItems.Any(x => x.ItemID == oldItem.ItemID && x.SkinID == oldItem.SkinID && x.StatID == oldItem.StatID)) {
                    if (oldItem.Amount != 0) {          //Dont want to add another entry with 0 amount, to prevent endless 0-amount entries for items that dont exist anymore.
                        result.Add(new Item {
                            ItemID = oldItem.ItemID,
                            SkinID = oldItem.SkinID,
                            StatID = oldItem.StatID,
                            Amount = 0,
                            Delta = oldItem.Amount * -1
                        });
                    }
                }
            }

            return result;
        }
    }
}