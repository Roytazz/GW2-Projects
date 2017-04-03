using GuildWars2.API;
using GuildWars2.API.Model.Account;
using GuildWars2.API.Model.Character;
using System.Collections.Generic;

namespace GuildWars2.Manager.InventoryService
{
    public class AccountInventory {

        public AccountInventory() { }

        public AccountInventory(string apiKey) {
            Account = AccountAPI.Account(apiKey).GetAwaiter().GetResult();
            Characters = CharacterAPI.Characters(apiKey).GetAwaiter().GetResult();
            Bank = AccountAPI.Bank(apiKey).GetAwaiter().GetResult();
            SharedInventory = AccountAPI.SharedInventory(apiKey).GetAwaiter().GetResult();
            Materials = AccountAPI.MaterialStorage(apiKey).GetAwaiter().GetResult();
            Wallet = AccountAPI.Wallet(apiKey).GetAwaiter().GetResult();
        }

        public Account Account { get; set; }

        public List<Character> Characters { get; set; }

        public List<BankEntity> Bank { get; set; }

        public List<Inventory> SharedInventory { get; set; }

        public List<Material> Materials { get; set; }

        public List<WalletEntry> Wallet { get; set; }
    }
}