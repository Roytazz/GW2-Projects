using GuildWars2.API;
using GuildWars2.Data.Database;
using GuildWars2.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Data
{
    public class AuthAPI
    {
        public static async Task<User> LoginUser(User user) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var users = await db.User.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password)).ToListAsync();
                if (users.Count() != 1)
                    return null;
                else
                    return users.FirstOrDefault();
            }
        }

        public static async Task<bool> AddUser(User user) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (!db.User.Any(x => x.UserName.Equals(user.UserName))) {
                    db.User.Add(user);
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public static async Task AddKey(int userID, string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                var user = await GetUser(userID);
                if (user == null)
                    return;

                var account = await AccountAPI.Account(apiKey);
                if (db.Account.Any(x => x.Name.Equals(account.Name))) {
                    var existingAccount = await db.Account.FirstOrDefaultAsync(x => x.Name.Equals(account.Name));
                    db.Key.Add(new Key { AccountID = existingAccount.ID, APIKey = apiKey, UserID = userID });
                }
                else {
                    await AddAccount(account);
                    var addedAccount = await GetAccount(apiKey);
                    db.Key.Add(new Key { AccountID = addedAccount.ID, APIKey = apiKey, UserID = userID });
                }
                await db.SaveChangesAsync();
            }
        }

        internal static async Task AddAccount(API.Model.Account.Account account) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (!db.Account.Any(x => x.Name.Equals(account.Name))) {
                    db.Account.Add(new Account { Name = account.Name, AccountGUID = account.ID });
                    await db.SaveChangesAsync();
                }
            }
        }

        internal static async Task<Account> GetAccount(string apiKey) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (db.Key.Any(x => x.APIKey.Equals(apiKey))) {
                    var key = await db.Key.FirstOrDefaultAsync(x => x.APIKey.Equals(apiKey));
                    return await db.Account.FirstOrDefaultAsync(x => x.ID == key.AccountID);
                }
                else
                    return null;
            }
        }

        internal static async Task<User> GetUser(int userID) {
            using (var db = new UserContextFactory().CreateDbContext()) {
                if (db.User.Any(x => x.ID == userID)) {
                    return await db.User.FirstOrDefaultAsync(x => x.ID == userID);
                }
                else
                    return null;
            }
        }
    }
}