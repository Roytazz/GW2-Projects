using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildWars2.REST.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GuildWars2.Manager.InventoryService;
using GuildWars2.REST.Model;

namespace GuildWars2.REST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        public AccountController(AppUserStore userManager) : base(userManager) { }

        public async Task<AccountDifference> InOut(int keyID) {
            var keys = await _userStore.GetKeysAsync(await CurrentUser());
            if (keys.Any(x => x.Id == keyID)) {
                var result = await _userStore.GetAccountDifference(keys.Find(x => x.Id == keyID));
                return ConvertDifference(result);
            }
            return null;
        }

        private AccountDifference ConvertDifference(UserAccountDifference difference) {
            return new AccountDifference {
                Items = difference.Items.Cast<ItemStackDifference>().ToList(),
                Currencies = difference.Currencies.Cast<CurrencyDifference>().ToList()
            };
        }
    }
}
