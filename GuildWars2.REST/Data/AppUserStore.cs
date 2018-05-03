using GuildWars2.API.Model.Items;
using GuildWars2.Manager.InventoryService;
using GuildWars2.REST.Data;
using GuildWars2.REST.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.REST.Database
{
    public class AppUserStore : UserStore<IdentityUser>
    {
        private AppDbContext _db;

        public AppUserStore(
            AppDbContext context,
            IdentityErrorDescriber describer = null)
            : base(context, describer) {
            _db = context;
        }

        #region Keys
        public async Task<List<ApiKey>> GetKeysAsync(IdentityUser user) {
            var keys = await _db.ApiKey.Where(c => c.ApplicationUserId == user.Id).ToListAsync();
            if (keys.Count > 0 && !keys.Any(c => c.Active))
                keys[0].Active = true;

            return keys;
        }

        public async Task<int> AddKeyAsync(IdentityUser user, ApiKey key) {
            key.ApplicationUserId = user.Id;
            await _db.ApiKey.AddAsync(key);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteKeyAsync(IdentityUser user, int id) {
            var key = await _db.ApiKey.FirstAsync(x => x.Id == id);
            if (key?.ApplicationUserId == user.Id) {
                _db.ApiKey.Remove(key);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> ActivateKeyAsync(IdentityUser user, int id) {
            var keys = await GetKeysAsync(user);
            if (keys.Any(key => key.Id == id)) {
                keys.ForEach(c => c.Active = (c.Id == id));
                _db.ApiKey.UpdateRange(keys);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ApiKey> GetActiveKey(IdentityUser user) {
            return await _db.ApiKey.FirstOrDefaultAsync(x => x.ApplicationUserId == user.Id && x.Active == true);
        }
        #endregion Keys

        #region Difference
        public async Task<List<UserCurrencyDifference>> GetAccountDifferenceCurrencies(ApiKey key) {
            return await _db.CurrencyDifference.Where(x => x.AccountName.Equals(key.Name)).ToListAsync();
        }

        public async Task<List<UserItemStackDifference>> GetAccountDifferenceItems(ApiKey key) {
            return await _db.ItemDifference.Where(x => x.AccountName.Equals(key.Name) && x.Difference != 0).ToListAsync();
        }

        private async Task<UserAccountDifference> GetAccountTotalDifference(ApiKey key) {
            return new UserAccountDifference {
                Items = await _db.ItemDifference.Where(x => x.AccountName.Equals(key.Name)).OrderByDescending(y => y.Date).ToListAsync(),
                Currencies = await _db.CurrencyDifference.Where(x => x.AccountName.Equals(key.Name)).OrderByDescending(y => y.Date).ToListAsync()
            };
        }

        public async Task ClearAccountDifference(ApiKey key) {
            _db.ItemDifference.RemoveRange(_db.ItemDifference.Where(x => x.AccountName.Equals(key.Name)));
            //_db.CurrencyDifference.RemoveRange(_db.CurrencyDifference.Where(x => x.AccountName.Equals(key.Name)));
            await _db.SaveChangesAsync();
        }

        public async Task SetAccountDifference(ApiKey key, bool manual) {
            var rawCurrentState = await GetAccountTotalDifference(key);
            var currentState = new AccountDifference {
                Items = rawCurrentState.Items.Cast<ItemStackDifference>().ToList(),
                Currencies = rawCurrentState.Currencies.Cast<CurrencyDifference>().ToList()
            };
            var difference = await InventoryManager.GetAccountDifference(key.Key, currentState);

            //Old Entries
            rawCurrentState.Items.ForEach(x => {
                if (difference.Items.Any(y => y.Equals(x))) {
                    var newState = difference.Items.Find(y => y.Equals(x));
                    x.Count = newState.Count;
                    x.Difference = newState.Difference;
                    x.SkinID = newState.SkinID;
                    x.StatID = newState.StatID;
                }
            });
            rawCurrentState.Currencies.ForEach(x => {
                if (difference.Currencies.Any(y => y.CurrencyID == x.CurrencyID)) {
                    var newState = difference.Currencies.Find(y => y.CurrencyID == x.CurrencyID);
                    x.Count = newState.Count;
                    x.Difference = newState.Difference;
                }
            });

            _db.ItemDifference.UpdateRange(rawCurrentState.Items);
            _db.CurrencyDifference.UpdateRange(rawCurrentState.Currencies);

            //New entries
            var newItems = new List<UserItemStackDifference>();
            var newCurrency = new List<UserCurrencyDifference>();

            var newItemsTrends = new List<UserItemTrend>();
            var newCurrencyTrends = new List<UserCurrencyTrend>();

            difference.Items.ForEach(x => {
                newItemsTrends.Add(new UserItemTrend { ItemID = x.ItemID, Count = x.Count, AccountName = key.Name, Date = DateTime.Now });
                if (!rawCurrentState.Items.Any(y => y.Equals(x)))
                    newItems.Add(new UserItemStackDifference(x, key));
            });
            difference.Currencies.ForEach(x => {
                newCurrencyTrends.Add(new UserCurrencyTrend { CurrencyID = x.CurrencyID, Count = x.Count, AccountName = key.Name, Date = DateTime.Now });
                if (!rawCurrentState.Currencies.Any(y => y.CurrencyID == x.CurrencyID))
                    newCurrency.Add(new UserCurrencyDifference(x, key));
            });

            _db.ItemDifference.AddRange(newItems);
            _db.CurrencyDifference.AddRange(newCurrency);

            _db.ItemTrend.AddRange(newItemsTrends);
            _db.CurrencyTrend.AddRange(newCurrencyTrends);

            await _db.SaveChangesAsync();
        }
        #endregion Difference

        #region Trend
        public async Task<UserAccountTrend> GetAccountTrend(ApiKey key) {
            return new UserAccountTrend {
                Items = await _db.ItemTrend.Where(x => x.AccountName.Equals(key.Name))
                                                    .GroupBy(x => x.AccountName).Select(grp => grp.OrderBy(x => x.Date).ToList()).ToListAsync(),

                Currencies = await _db.CurrencyTrend.Where(x => x.AccountName.Equals(key.Name))
                                                    .GroupBy(x => x.AccountName).Select(grp => grp.OrderBy(x => x.Date).ToList()).ToListAsync(),
            };
        }

        public async Task<List<UserItemTrend>> GetItemTrend(ApiKey key, int id) {
            return await _db.ItemTrend.Where(x => x.AccountName.Equals(key.Name) && x.ItemID == id).OrderBy(x => x.Date).ToListAsync();
        }

        public async Task<List<UserCurrencyTrend>> GetCurrencyTrend(ApiKey key, int id) {
            return await _db.CurrencyTrend.Where(x => x.AccountName.Equals(key.Name) && x.CurrencyID == id).OrderBy(x => x.Date).ToListAsync();
        }
        #endregion Trend

        public void Test() {
            var test = _db.ItemDifference.Where(x => x.AccountName.Contains("Marla") && x.ItemID == 79157);
            return;
        }
    }
}