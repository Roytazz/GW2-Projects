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

        [HttpGet]
        [Route("InOut/Currencies")]
        public async Task<List<UserCurrencyDifference>> InOutCurrencies() {
            var key = await ActiveKey();
            if (key != null) {
                return await _userStore.GetAccountDifferenceCurrencies(key);
            }
            return null;
        }

        [HttpGet]
        [Route("InOut/Items")]
        public async Task<List<UserItemStackDifference>> InOutItems() {
            var key = await ActiveKey();
            if (key != null) {
                return await _userStore.GetAccountDifferenceItems(key);
            }
            return null;
        }

        [HttpPost]
        [Route("InOut")]
        public async Task<bool> SaveInOut() {
            var key = await ActiveKey();
            if (key != null) {
                await _userStore.SetAccountDifference(key);
                return true;
            }
            return false;
        }

        [HttpGet]
        [Route("Trend")]
        public async Task<UserAccountTrend> Trend() {
            var key = await ActiveKey();
            if (key != null) {
                return await _userStore.GetAccountTrend(key);
            }
            return null;
        }

        [HttpGet]
        [Route("Trend/Item/{id}")]
        public async Task<List<UserItemTrend>> TrendItem(int id) {
            var key = await ActiveKey();
            if (key != null) {
                return await _userStore.GetItemTrend(key, id);
            }
            return null;
        }

        [HttpGet]
        [Route("Trend/Currency/{id}")]
        public async Task<List<UserCurrencyTrend>> TrendCurrency(int id) {
            var key = await ActiveKey();
            if (key != null) {
                return await _userStore.GetCurrencyTrend(key, id);
            }
            return null;
        }
    }
}