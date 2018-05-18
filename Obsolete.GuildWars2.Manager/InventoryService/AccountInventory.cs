using GuildWars2.API;
using GuildWars2.API.Model.Account;
using GuildWars2.API.Model.Character;
using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Manager.InventoryService
{
    public class AccountInventory 
    {
        private List<WalletEntry> _fullWallet;
        private List<ExtendedItemStack> _allItems;

        public List<ExtendedItemStack> Items { get {
            if (_allItems != null)
                return _allItems;

            var items = new List<ExtendedItemStack>();

            Characters.ForEach(x => {
                x.Bags.ForEach(y => {
                    if (y != null) {
                        items.Add(new ExtendedItemStack { ID = y.ID, Count = 1 });
                        items.AddRange(GetItems(y.Inventory));
                    }
                });
                x.Equipment.ForEach(z => {
                    items.AddRange(GetItems(z));
                });
            });
            items.AddRange(GetItems(Bank));
            items.AddRange(GetItems(SharedInventory));
            if (DeliveryBox?.Items != null) {
                items.AddRange(GetItems(DeliveryBox.Items));
            }
            items.AddRange(GetItems(Materials.Cast<ItemStack>().ToList()));
            items.AddRange(GuildBank);

            //Combine identical items into 1 Stack
            var result = new List<ExtendedItemStack>();
            items.ForEach(x => {                                                    
                if (!result.Any(y => y.Equals(x))) {
                    var count = items.Where(y => y.Equals(x)).Sum(z => z.Count);
                    if (count > 0)
                        result.Add(new ExtendedItemStack { ID = x.ID, SkinID = GetSkinId(x), StatID = x.StatID, Count = count });
                }
            });

            _allItems = result;
            return result;
        }}

        public List<WalletEntry> Currencies {
            get {
                if (_fullWallet != null)
                    return _fullWallet;

                var wallet = Wallet;
                wallet.ForEach(x => {
                    if (x.ID == 1 && DeliveryBox != null)   //ID = 1 is Gold
                        x.Value += DeliveryBox.Coins;       //Add DeliveryBox gold to total Gold
                });

                _fullWallet = wallet;
                return wallet;
        }}

        private Account Account { get; set; }

        private List<Character> Characters { get; set; }

        private List<InventoryEntity> Bank { get; set; }

        private List<InventoryEntity> SharedInventory { get; set; }

        private DeliveryBox DeliveryBox { get; set; }

        private List<Material> Materials { get; set; }

        private List<WalletEntry> Wallet { get; set; }

        private List<ExtendedItemStack> GuildBank { get; set; }

        public static async Task<AccountInventory> GetAccountInventory(string apiKey) {
            var accountInv = new AccountInventory() {
                Account = await AccountAPI.Account(apiKey),
                Characters = await CharacterAPI.Characters(apiKey),
                Bank = await AccountAPI.Bank(apiKey),
                SharedInventory = await AccountAPI.SharedInventory(apiKey),
                Materials = await AccountAPI.MaterialStorage(apiKey),
                Wallet = await AccountAPI.Wallet(apiKey)
            };
            await accountInv.SetGuildBank(apiKey);
            return accountInv;
        }

        #region Private methods

        private List<ExtendedItemStack> GetItems(List<ItemStack> entities) {
            var items = new List<ExtendedItemStack>();
            entities?.ForEach(x => {
                items.Add(new ExtendedItemStack { ID = x.ID, Count = x.Count });
            });
            return items;
        }

        private List<ExtendedItemStack> GetItems(List<InventoryEntity> entities) {
            var items = new List<ExtendedItemStack>();
            entities?.ForEach(x => {
                items.AddRange(GetItems(x));
            });
            return items;
        }

        private List<ExtendedItemStack> GetItems(Equipment entity) {
            var items = new List<ExtendedItemStack>();
            if (entity == null)
                return items;

            if (entity.Infusions?.Count > 0) {                                  //All Infusions
                entity.Infusions.ForEach(x => {
                    items.Add(new ExtendedItemStack { ID = x, Count = 1 });
                });
            }

            if (entity.Upgrades?.Count > 0) {                                  //All sigil/runes/jewels
                entity.Upgrades.ForEach(x => {
                    items.Add(new ExtendedItemStack { ID = x, Count = 1 });
                });
            }

            if (entity is InventoryEntity) {                                    //Item itself
                items.Add(new ExtendedItemStack {
                    ID = entity.ID,
                    SkinID = entity.Skin,
                    StatID = entity.Stats != null ? entity.Stats.ID : 0,
                    Count = (entity as InventoryEntity).Count > 0 ?
                                    (entity as InventoryEntity).Count :
                                    (entity as InventoryEntity).Charges
                });
            }
            else {
                items.Add(new ExtendedItemStack {
                    ID = entity.ID,
                    SkinID = entity.Skin,
                    StatID = entity.Stats != null ? entity.Stats.ID : 0,
                    Count = entity.Charges > 0 ? entity.Charges : 1
                });
            }
            return items;
        }

        private static int GetSkinId(ItemStack entity) {
            if (entity is ExtendedItemStack)
                return (entity as ExtendedItemStack).SkinID;
            else
                return 0;
        }

        private async Task SetGuildBank(string apiKey) {
            GuildBank = new List<ExtendedItemStack>();
            foreach (var guild in Account.Guilds) {
                var members = await GuildAPI.Members(guild, apiKey);        //Check if you are the leader and Member count. This determines if its a personal BANK GUILD
                if (members.Count > 0 && members.Count <= 5) {
                    var stash = await GuildAPI.Stash(guild, apiKey);
                    stash.ForEach(x => {
                        Wallet.Find(y => y.ID == 1).Value += x.Coins;
                        x.Inventory.ForEach(z => {
                            if (z != null)
                                GuildBank.Add(new ExtendedItemStack { ID = z.ID, Count = z.Count });
                        });
                    });
                }
            }
        }

        #endregion Private methods
    }
}