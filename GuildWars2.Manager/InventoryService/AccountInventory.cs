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
    public class AccountInventory { 
        private List<ExtendedItemStack> _allItems;
        private List<WalletEntry> _fullWallet;

        public Account Account { private get; set; }

        public List<Character> Characters { private get; set; }

        public List<InventoryEntity> Bank { private get; set; }

        public List<InventoryEntity> SharedInventory { private get; set; }

        public DeliveryBox DeliveryBox { private get; set; }

        public List<Material> Materials { private get; set; }

        public List<WalletEntry> Wallet { private get; set; }

        private List<ItemStack> GuildBank { get; set; }

        private string ApiKey { get; set; }

        public AccountInventory(string apikey) {
            ApiKey = apikey;
        }

        // Methods //

        public List<ExtendedItemStack> GetAllItems() {
            if (_allItems != null)
                return _allItems;

            var items = new List<ItemStack>();

            Characters.ForEach(x => {
                x.Bags.ForEach(y => {
                    if (y != null) {
                        items.Add(new ItemStack { ID = y.ID, Count = 1 });
                        items.AddRange(GetItems(y.Inventory));
                    }
                });
                items.AddRange(GetItems(x.Equipment));
            });
            items.AddRange(GetItems(Bank));
            items.AddRange(GetItems(SharedInventory));
            if(DeliveryBox?.Items != null)
                items.AddRange(DeliveryBox.Items);
            items.AddRange(Materials);
            items.AddRange(GuildBank);

            //Combine identical items into 1 Stack
            var result = new List<ExtendedItemStack>();
            items.ForEach(x => {
                if (!result.Any(y => y.ID == x.ID)) {
                    var count = items.Where(y => y.ID == x.ID).Sum(z => z.Count);
                    if (count > 0)
                        result.Add(new ExtendedItemStack { ID = x.ID, SkinID = GetSkinId(x), Count = count });
                }
            });
            _allItems = result;
            return result;
        }

        public List<WalletEntry> GetAllCurrencies() {
            if (_fullWallet != null)
                return _fullWallet;

            var wallet = Wallet;
            wallet.ForEach(x => {
                if (x.ID == 1 && DeliveryBox != null)   //ID = 1 is Gold
                    x.Value += DeliveryBox.Coins;       //Add DeliveryBox gold to total Gold
            });
            _fullWallet = wallet;
            return wallet;
        }
        
        private List<ItemStack> GetItems(List<InventoryEntity> entities) {
            var items = new List<ItemStack>();
            entities?.ForEach(x => {
                items.AddRange(GetItems(x));
            });
            return items;
        }

        private List<ItemStack> GetItems(List<Equipment> equipment) {
            var items = new List<ItemStack>();
            equipment?.ForEach(x => {
                items.AddRange(GetItems(x));
            });
            return items;
        }

        private List<ExtendedItemStack> GetItems(Equipment entity) {
            var items = new List<ExtendedItemStack>();
            if (entity == null)
                return items;

            if (entity.Infusions?.Count > 0) {                                  //All Infusions
                foreach (var infusion in entity.Infusions) {
                    items.Add(new ExtendedItemStack { ID = infusion, Count = 1 });
                }
            }

            if (entity.Upgrades?.Count > 0) {                                  //All sigil/runes/jewels
                foreach (var upgrade in entity.Upgrades) {
                    items.Add(new ExtendedItemStack { ID = upgrade, Count = 1 });
                }
            }

            if (entity is InventoryEntity) {                                    //Item itself
                items.Add(new ExtendedItemStack { ID = entity.ID, SkinID = entity.Skin, Count = (entity as InventoryEntity).Count > 0 ? (entity as InventoryEntity).Count : (entity as InventoryEntity).Charges }); 
            }
            else {
                items.Add(new ExtendedItemStack { ID = entity.ID, SkinID = entity.Skin, Count = entity.Charges > 0 ? entity.Charges : 1 });  
            }
            return items;
        }

        private static int GetSkinId(ItemStack entity) {
            if (entity is ExtendedItemStack)
                return (entity as ExtendedItemStack).SkinID;
            else
                return 0;
        }

        private async Task SetGuildBank() {
            GuildBank = new List<ItemStack>();
            foreach (var guild in Account.Guilds) {
                var members = await GuildAPI.Members(guild, ApiKey);        //Check if you are the leader and Member count. This determines if its a personal BANK GUILD
                if (members.Count > 0 && members.Count <= 5) {
                    var stash = await GuildAPI.Stash(guild, ApiKey);
                    stash.ForEach(x => {
                        Wallet.Find(y => y.ID == 1).Value += x.Coins;           
                        x.Inventory.ForEach(z => {
                            if (z != null)
                                GuildBank.Add(z);
                        });
                    });
                }
            }
        }

        public static async Task<AccountInventory> GetAccountInventory(string apiKey) {
            var accountInv = new AccountInventory(apiKey) {
                Account = await AccountAPI.Account(apiKey),
                Characters = await CharacterAPI.Characters(apiKey),
                Bank = await AccountAPI.Bank(apiKey),
                SharedInventory = await AccountAPI.SharedInventory(apiKey),
                Materials = await AccountAPI.MaterialStorage(apiKey),
                Wallet = await AccountAPI.Wallet(apiKey)
            };
            await accountInv.SetGuildBank();
            return accountInv;
        }
    }
}