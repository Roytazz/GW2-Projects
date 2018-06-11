using GuildWars2.API;
using GuildWars2.Data.Database;
using GuildWars2.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Data
{
    public class AuthAPI
    {
        public static async Task AddKey(int userID, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (apiKey == null || apiKey.Equals(string.Empty) || await GetUser(userID) == null)
                    return;

                var account = await AccountAPI.Account(apiKey);
                if (account != null && await db.Account.AnyAsync(x => x.Name.Equals(account.Name))) {
                    var existingAccount = await db.Account.FirstOrDefaultAsync(x => x.Name.Equals(account.Name));
                    db.Key.Add(new Key { AccountID = existingAccount.ID, APIKey = apiKey, UserID = userID });
                }
                else {
                    await AddAccount(account.Name, account.ID);
                    var addedAccount = await GetAccount(apiKey);
                    db.Key.Add(new Key { AccountID = addedAccount.ID, APIKey = apiKey, UserID = userID });
                }
                await db.SaveChangesAsync();
            }
        }

        public static async Task<List<KeyInfo>> GetKeys(int userID) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var keys = await db.Key.Where(x => x.UserID == userID).ToListAsync();
                var result = new List<KeyInfo>();
                foreach (var key in keys) {
                    var account = await db.Account.FirstOrDefaultAsync(x => x.ID == key.AccountID);
                    if(account != null)
                        result.Add(new KeyInfo { APIKey = key.APIKey, AccountName = account?.Name });
                }
                return result;
            }
        }

        public static async Task<User> LoginUser(string username, string password) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var users = await db.User.Where(x => x.UserName.Equals(username) && x.Password.Equals(password)).ToListAsync();
                if (users.Count() == 1)
                    return users.FirstOrDefault();
                else
                    return null;
            }
        }

        public static async Task<AuthResult> AddUser(string userName, string password) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (!await db.User.AnyAsync(x => x.UserName.Equals(userName))) {
                    db.User.Add(new User { UserName = userName, Password = password });
                    await db.SaveChangesAsync();
                    return new AuthResult { Message = "User succesfully added", Succeeded = true };
                }
                return new AuthResult { Message = "Username already exists", Succeeded = false };
            }
        }

        internal static async Task<User> GetUser(int userID) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (await db.User.AnyAsync(x => x.ID == userID)) {
                    return await db.User.FirstOrDefaultAsync(x => x.ID == userID);
                }
                else
                    return null;
            }
        }

        internal static async Task AddAccount(string accountName, string accountGUID) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (!await db.Account.AnyAsync(x => x.Name.Equals(accountName))) {
                    db.Account.Add(new Account { Name = accountName, AccountGUID = accountGUID });
                    await db.SaveChangesAsync();
                }
            }
        }

        internal static async Task<Account> GetAccount(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (await db.Key.AnyAsync(x => x.APIKey.Equals(apiKey))) {
                    var key = await db.Key.FirstOrDefaultAsync(x => x.APIKey.Equals(apiKey));
                    return await db.Account.FirstOrDefaultAsync(x => x.ID == key.AccountID);
                }
                else
                    return null;
            }
        }
    }

    public class KeyInfo
    {
        public string APIKey { get; set; }

        public string AccountName { get; set; }
    }

    public class AuthResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}