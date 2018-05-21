using GuildWars2.API;
using GuildWars2.Data.Database;
using GuildWars2.Data.Model;
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
        #region Dyes
        public static List<Dye> GetAccountDyes(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user != null)
                    return db.Dye.Where(x => x.UserID == user.ID).ToList();
            }
            return new List<Dye>();
        }

        public static async void AddDyes(List<API.Model.Items.Item> dyes, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
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
        public static List<Mini> GetAccountMinis(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user != null)
                    return db.Mini.Where(x => x.UserID == user.ID).ToList();
            }
            return new List<Mini>();
        }

        public static async void AddMinis(List<API.Model.Miscellaneous.Mini> minis, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
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
        public static List<Skin> GetAccountSkins(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
                if (user != null)
                    return db.Skin.Where(x => x.UserID == user.ID).ToList();
            }
            return new List<Skin>();
        }

        public static async Task AddSkins(List<API.Model.Items.Skin> skins, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = GetUser(apiKey);
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
                var user = GetUser(apiKey);
                if (user == null)
                    return;

                foreach (var entry in entries) {
                    var latestEntry = db.Wallet.Where(x => x.UserID == user.ID && x.CurrencyID == entry.ID).OrderByDescending(x => x.Date).FirstOrDefault();
                    if (latestEntry != null)
                        db.Wallet.Add(new Model.WalletEntry { UserID = user.ID, CurrencyID = entry.ID, Value = entry.Value, Delta = entry.Value - latestEntry.Value });
                    else
                        db.Wallet.Add(new Model.WalletEntry { UserID = user.ID, CurrencyID = entry.ID, Value = entry.Value });
                }
                await db.SaveChangesAsync();
            }
        }
        #endregion Wallet

        public async static Task AddCategoryEntry(CategoryType type, int value, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
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
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (db.Key.Any(x => x.APIKey.Equals(apiKey))) {
                    var key = db.Key.FirstOrDefault(x => x.APIKey.Equals(apiKey));
                    return db.User.FirstOrDefault(x => x.ID == key.UserID);
                }
                else
                    return null;
            }
        }

        public static async Task AddUser(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
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
