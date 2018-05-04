using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Manager.InventoryService
{
    public static class InventoryManager {
        public static async Task<AccountDifference> GetAccountDifference(string apiKey, AccountDifference oldState) {
            var currentState = await AccountInventory.GetAccountInventory(apiKey);
            var newState = new AccountDifference { Items = new List<ItemStackDifference>(), Currencies = new List<CurrencyDifference>() };

            //Comparing Items and Currencies in both Old and Current state
            oldState.Items.ForEach(x => {
                if (currentState.Items.Any(y => y.Equals(x))) {        
                    var newItem = currentState.Items.Find(y => y.Equals(x));
                    newState.Items.Add(new ItemStackDifference {
                        ItemID = x.ItemID,
                        SkinID = x.SkinID,
                        StatID = x.StatID,
                        Count = newItem.Count,
                        Difference = newItem.Count - x.Count
                    });
                }
                else {
                    newState.Items.Add(new ItemStackDifference {
                        ItemID = x.ItemID,
                        SkinID = x.SkinID,
                        StatID = x.StatID,
                        Count = 0,
                        Difference = x.Count * -1
                    });
                }
            });
            oldState.Currencies.ForEach(x => {
                if (currentState.Currencies.Any(y => y.ID == x.CurrencyID)) {
                    var newItem = currentState.Currencies.Find(y => y.ID == x.CurrencyID);
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
            });

            //Completly new Items and Currencies
            currentState.Items.ForEach(x => {
                if (!oldState.Items.Any(y => y.Equals(x))) {
                    newState.Items.Add(new ItemStackDifference {
                        ItemID = x.ID,
                        SkinID = x.SkinID,
                        StatID = x.StatID,
                        Count = x.Count,
                        Difference = x.Count
                    });
                }
            });
            currentState.Currencies.ForEach(x => {
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
    }
}