using GuildWars2.Manager.InventoryService;
using GuildWars2.REST.Data;
using GuildWars2.REST.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.REST.Database
{
    public class AppUserStore : UserStore<AppUser>
    {
        private AppDbContext _db;

        public AppUserStore(
            AppDbContext context,
            IdentityErrorDescriber describer = null)
            : base(context, describer) {
            _db = context;
        }

        #region Keys
        public async Task<List<ApiKey>> GetKeysAsync(AppUser user) {
            return await _db.ApiKey.Where(c => c.ApplicationUserId == user.Id).ToListAsync();
        }

        public async Task<int> AddKeyAsync(AppUser user, ApiKey key) {
            key.ApplicationUserId = user.Id;
            await _db.ApiKey.AddAsync(key);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteKeyAsync(AppUser user, int id) {
            var key = await _db.ApiKey.FirstAsync(x => x.Id == id);
            if (key?.ApplicationUserId == user.Id) {
                _db.ApiKey.Remove(key);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> ActivateKeyAsync(AppUser user, int id) {
            var keys = await GetKeysAsync(user);
            if (keys.Any(key => key.Id == id)) {
                keys.ForEach(c => c.Active = (c.Id == id));
                _db.ApiKey.UpdateRange(keys);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        #endregion Keys

        public async Task<UserAccountDifference> GetAccountDifference(ApiKey key) {
            return new UserAccountDifference {
                Items = await _db.ItemDifference.Where(x => x.AccountName.Equals(key.Name)).ToListAsync(),
                Currencies = await _db.CurrencyDifference.Where(x => x.AccountName.Equals(key.Name)).ToListAsync()
            };
        }
        
        public async Task SetAccountDifferences(ApiKey key) {
            var rawCurrentState = await GetAccountDifference(key);
            var currentState = new AccountDifference {
                Items = rawCurrentState.Items.Cast<ItemStackDifference>().ToList(),
                Currencies = rawCurrentState.Currencies.Cast<CurrencyDifference>().ToList()
            };
            var difference = await InventoryManager.GetAccountDifference(key.Key, currentState);

            var newState = new UserAccountDifference { Items = new List<UserItemStackDifference>(), Currencies = new List<UserCurrencyDifference>() };
            difference.Items.ForEach(x => {
                var item = new UserItemStackDifference {
                    Count = x.Count,
                    ItemId = x.ItemId,
                    AccountName = key.Name,
                    Difference = x.Difference
                };
                if(rawCurrentState.Items.Any(y => y.ItemId == x.ItemId)) {
                    item.ID = rawCurrentState.Items.Find(y => y.ItemId == x.ItemId).ID;
                }
                newState.Items.Add(item);
            });

            difference.Currencies.ForEach(x => {
                var currency = new UserCurrencyDifference {
                    Count = x.Count,
                    AccountName = key.Name,
                    Difference = x.Difference,
                    CurrencyId = x.CurrencyId
                };
                if (rawCurrentState.Currencies.Any(y => y.CurrencyId == x.CurrencyId)) {
                    currency.ID = rawCurrentState.Currencies.Find(y => y.CurrencyId == x.CurrencyId).ID;
                }
                newState.Currencies.Add(currency);
            });
            _db.ItemDifference.UpdateRange(newState.Items);
            _db.CurrencyDifference.UpdateRange(newState.Currencies);
            //await _db.SaveChangesAsync();
        }
    }
}
