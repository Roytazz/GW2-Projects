using GuildWars2.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Manager.InventoryService
{
    public static class InventoryManager
    {
        public async static Task<AccountInventory> GetAccountInventory(string apiKey) {
            return new AccountInventory {
                Account = await AccountAPI.Account(apiKey),
                Characters = await CharacterAPI.Characters(apiKey),
                Bank = await AccountAPI.Bank(apiKey),
                SharedInventory = await AccountAPI.SharedInventory(apiKey),
                Materials = await AccountAPI.MaterialStorage(apiKey),
                Wallet = await AccountAPI.Wallet(apiKey)
            };
        }
    }
}