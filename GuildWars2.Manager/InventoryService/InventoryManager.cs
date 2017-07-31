using GuildWars2.API;
using GuildWars2.API.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Manager.InventoryService
{
    public static class InventoryManager {
        public static async Task<AccountDifference> GetAccountDifference(string apiKey, AccountDifference oldState) {
            var currentState = await AccountInventory.GetAccountInventory(apiKey);
            var newState = new AccountDifference { Items = new List<ItemStackDifference>(), Currencies = new List<CurrencyDifference>() };

            //Comparing Items and Currencies in both Old and Current state
            foreach (var x in oldState.Items) {
                if (currentState.GetAllItems().Any(y => y.ID == x.ItemID)) {
                    var newItem = currentState.GetAllItems().Find(y => y.ID == x.ItemID);
                    newState.Items.Add(new ItemStackDifference {
                        ItemID = x.ItemID,
                        SkinID = x.SkinID,
                        Count = newItem.Count,
                        Difference = newItem.Count - x.Count
                    });
                }
                else {
                    newState.Items.Add(new ItemStackDifference {
                        ItemID = x.ItemID,
                        SkinID = x.SkinID,
                        Count = 0,
                        Difference = x.Count * -1
                    });
                }
            }
            foreach (var x in oldState.Currencies) {
                if (currentState.GetAllCurrencies().Any(y => y.ID == x.CurrencyID)) {
                    var newItem = currentState.GetAllCurrencies().Find(y => y.ID == x.CurrencyID);
                    newState.Currencies.Add(new CurrencyDifference {
                        CurrencyID = x.CurrencyID,
                        Count = newItem.Value,
                        Difference = newItem.Value - x.Count
                    });
                }
                else {
                    newState.Currencies.Add(new CurrencyDifference {
                        CurrencyID = x.CurrencyID,
                        Count = 0,
                        Difference = x.Count * -1
                    });
                }
            }
            

            //Completly new Items and Currencies
            currentState.GetAllItems().ForEach(x => {
                if (!oldState.Items.Any(y => y.ItemID == x.ID)) {
                    newState.Items.Add(new ItemStackDifference {
                        ItemID = x.ID,
                        SkinID = x.SkinID,
                        Count = x.Count,
                        Difference = x.Count
                    });
                }
            });
            currentState.GetAllCurrencies().ForEach(x => {
                if (!oldState.Currencies.Any(y => y.CurrencyID == x.ID)) {
                    newState.Currencies.Add(new CurrencyDifference {
                        CurrencyID = x.ID,
                        Count = x.Value,
                        Difference = x.Value
                    });
                }
            });
            
            return newState;
        }

        internal static async Task<AccountInventory> GetAccountInventory(string apiKey) {
            return new AccountInventory(apiKey) {
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