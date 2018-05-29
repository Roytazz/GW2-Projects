using GuildWars2.API;
using GuildWars2.API.Model.Account;
using GuildWars2.API.Model.Character;
using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Model.Items;
using GuildWars2.Data;
using GuildWars2.Value;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker
{
    public class ItemWorker : IUserWorker
    {
        public async Task Run(CancellationToken token, params string[] apiKeys) {
            await Run(token, apiKeys.ToList());
        }

        public async Task Run(CancellationToken token, List<string> apiKeys) {
            foreach (string apiKey in apiKeys) {
                var account = new AccountInventory();
                await account.Populate(apiKey);

                await UserAPI.AddAccountItems(account.Total(), apiKey);
                await UserAPI.AddWalletEntries(account.Wallet, apiKey);

                var bankValue = await ValueFactory.CalculateValue(ConvertToSimpleAPIItem(account.Bank));
                await UserAPI.AddCategoryEntry(Data.Model.CategoryType.Bank, MultiplyAmounts(account.Bank, bankValue), apiKey);

                var characterValues = await ValueFactory.CalculateValue(ConvertToSimpleAPIItem(account.Characters));
                await UserAPI.AddCategoryEntry(Data.Model.CategoryType.Characters, MultiplyAmounts(account.Characters, characterValues), apiKey);

                var guildBankValues = await ValueFactory.CalculateValue(ConvertToSimpleAPIItem(account.GuildBank));
                await UserAPI.AddCategoryEntry(Data.Model.CategoryType.GuildBank, MultiplyAmounts(account.GuildBank, guildBankValues), apiKey);

                var materialValues = await ValueFactory.CalculateValue(ConvertToSimpleAPIItem(account.MaterialStorage));
                await UserAPI.AddCategoryEntry(Data.Model.CategoryType.MaterialStorage, MultiplyAmounts(account.MaterialStorage, materialValues), apiKey);

                var sharedInventoryValues = await ValueFactory.CalculateValue(ConvertToSimpleAPIItem(account.SharedInventory));
                await UserAPI.AddCategoryEntry(Data.Model.CategoryType.SharedInventory, MultiplyAmounts(account.SharedInventory, sharedInventoryValues), apiKey);

                var deliveryBoxValues = await ValueFactory.CalculateValue(ConvertToSimpleAPIItem(account.DeliveryBox));
                await UserAPI.AddCategoryEntry(Data.Model.CategoryType.DeliveryBox, MultiplyAmounts(account.DeliveryBox, deliveryBoxValues), apiKey);
            }
        }

        private List<Item> ConvertToSimpleAPIItem(List<Data.Model.Item> items) {
            return items.Select(x => new Item { ID = x.ItemID }).ToList();
        }

        private int MultiplyAmounts(List<Data.Model.Item> items, List<ValueResult<Item>> values) {
            values = values.Where(x => x.Value != null).ToList();
            var totalValue = 0;

            foreach (var item in items) {
                if(values.Any(x=>x.Item.ID == item.ItemID)) {
                    var valueResult = values.FirstOrDefault(x => x.Item.ID == item.ItemID);
                    totalValue += valueResult.Value.Coins * item.Amount;
                }
            }

            return totalValue;
        }
    }

    class AccountInventory
    {
        public List<Data.Model.Item> Characters { get; set; }

        public List<Data.Model.Item> Bank { get; set; }

        public List<Data.Model.Item> SharedInventory { get; set; }

        public List<Data.Model.Item> DeliveryBox { get; set; }

        public List<Data.Model.Item> MaterialStorage { get; set; }

        public List<WalletEntry> Wallet { get; set; }

        public List<Data.Model.Item> GuildBank { get; set; }

        private static readonly int MIN_AMOUNT_MEMBER_FOR_GUILD_BANK = 5;

        internal async Task Populate(string apiKey) {
            Wallet = await AccountAPI.Wallet(apiKey);

            var characterResult = await CharacterAPI.Characters(apiKey);
            Characters = GroupItems(CharacterItems(characterResult));

            var bankResult = await AccountAPI.Bank(apiKey);
            Bank = GroupItems(GetItems(bankResult.Cast<Equipment>().ToList()));

            var sharedResult = await AccountAPI.SharedInventory(apiKey);
            SharedInventory = GroupItems(GetItems(sharedResult.Cast<Equipment>().ToList()));
            
            MaterialStorage = GroupItems(GetItems(await AccountAPI.MaterialStorage(apiKey)));
            DeliveryBox = GroupItems(GetItems(GetDeliveryBox(await CommerceAPI.DeliveryBox(apiKey))));
            GuildBank = GroupItems(GetItems(await GetGuildInventory(await AccountAPI.Account(apiKey), apiKey)));
        }

        public List<Data.Model.Item> Total() {
            List<Data.Model.Item> items = new List<Data.Model.Item>();

            items.AddRange(Characters);
            items.AddRange(Bank);
            items.AddRange(SharedInventory);
            items.AddRange(DeliveryBox);
            items.AddRange(MaterialStorage);
            items.AddRange(GuildBank);
            return GroupItems(items);
        }

        private List<Data.Model.Item> GroupItems(List<Data.Model.Item> items) {
            return items.GroupBy(x => new { x.ItemID, x.StatID, x.SkinID })
                .Select(x => new Data.Model.Item {
                    ItemID = x.Key.ItemID,
                    StatID = x.Key.StatID,
                    SkinID = x.Key.SkinID,
                    Amount = x.Sum(y => y.Amount)
                }).ToList();
        }

        #region GetItems

        private List<Data.Model.Item> CharacterItems(List<Character> Characters) {
            List<Data.Model.Item> items = new List<Data.Model.Item>();

            foreach (var character in Characters) {
                items.AddRange(GetItems(character.Equipment));
                foreach (var bag in character.Bags) {
                    if(bag != null)
                        items.AddRange(GetItems(bag.Inventory.Cast<Equipment>().ToList()));
                }
            }
            return items;
        }

        private List<Data.Model.Item> GetItems(List<Equipment> equipment) {
            List<Data.Model.Item> result = new List<Data.Model.Item>();
            foreach (var equipmentPiece in equipment) {
                if (equipmentPiece == null)
                    continue;

                result.Add(new Data.Model.Item {
                    Amount = GetAmount(equipmentPiece),
                    ItemID = equipmentPiece.ID,
                    SkinID = equipmentPiece.Skin,
                    StatID = equipmentPiece.Stats != null ? equipmentPiece.Stats.ID : 0
                });
                if (equipmentPiece.Infusions != null) {
                    foreach (var infusion in equipmentPiece.Infusions) {
                        result.Add(new Data.Model.Item {
                            Amount = 1,
                            ItemID = infusion
                        });
                    }
                }

                if (equipmentPiece.Upgrades != null) {
                    foreach (var upgrades in equipmentPiece.Upgrades) {
                        result.Add(new Data.Model.Item {
                            Amount = 1,
                            ItemID = upgrades
                        });
                    }
                }
            }
            return result;
        }

        private List<Data.Model.Item> GetItems(List<Material> materials) {
            List<Data.Model.Item> result = new List<Data.Model.Item>();
            foreach (var material in materials) {
                if (material == null || material.Count == 0)
                    continue;

                result.Add(new Data.Model.Item {
                    Amount = material.Count,
                    ItemID = material.ID
                });
            }
            return result;
        }

        private List<Data.Model.Item> GetItems(List<ItemStack> items) {
            List<Data.Model.Item> result = new List<Data.Model.Item>();
            foreach (var item in items) {
                if (item == null)
                    continue;

                result.Add(new Data.Model.Item {
                    Amount = item.Count,
                    ItemID = item.ID
                });
            }
            return result;
        }

        private int GetAmount(Equipment equipmentPiece) {
            if(equipmentPiece is InventoryEntity) {
                var entity = equipmentPiece as InventoryEntity;
                return entity.Charges != 0 ? entity.Charges : entity.Count != 0 ? entity.Count : 1;
            }
            else { 
                return equipmentPiece.Charges != 0 ? equipmentPiece.Charges : 1;
            }
        }

        private List<ItemStack> GetDeliveryBox(DeliveryBox deliveryBox) {
            if (Wallet == null || !Wallet.Any(x=>x.ID == 1))
                return new List<ItemStack>();

            Wallet.FirstOrDefault(y => y.ID == 1).Value += deliveryBox.Coins;         //Add Gold from the Stash to the total Gold in the wallet
            return deliveryBox.Items;
        }

        private async Task<List<ItemStack>> GetGuildInventory(Account account, string apiKey) {
            List<ItemStack> result = new List<ItemStack>();
            foreach (var guild in account.Guilds) {

                var members = await GuildAPI.Members(guild, apiKey);       //Check if you are the leader and Member count. This determines if its a personal Bank Guild
                if (members != null && members.Count <= MIN_AMOUNT_MEMBER_FOR_GUILD_BANK) {

                    var stashes = await GuildAPI.Stash(guild, apiKey);
                    foreach (var stash in stashes) {
                        if (Wallet != null || Wallet.Any(x => x.ID == 1)) {
                            Wallet.FirstOrDefault(y => y.ID == 1).Value += stash.Coins;   //Add Gold from the Stash to the total Gold in the wallet
                        }

                        foreach (var inventorySlot in stash.Inventory) {
                            if (inventorySlot != null)
                                result.Add(inventorySlot);
                        }
                    }
                }
            }
            return result;
        }
        #endregion GetItems
    }
}
