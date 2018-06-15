using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GuildWars2.API.Items;
using GuildWars2.API;
using GuildWars2.API.Model.Commerce;

namespace GuildWars2.Worker.Values.Services
{
    public class RecipeValueService : IValueService<ItemRecipeTreeNode>
    {
        public async Task<List<ValueResult<ItemRecipeTreeNode>>> CalculateValue(List<ItemRecipeTreeNode> items, bool takeHighestValue) {
            var result = new List<ValueResult<ItemRecipeTreeNode>>();
            foreach (var item in items) {
                var itemIDs = GetItemIDs(item).Select(x=>x.ItemID).Distinct().ToList();
                var listings = new List<ItemListingAggregated>();
                if(itemIDs.Count > 0)
                    listings = await CommerceAPI.ListingsAggregated(itemIDs);
                
                result.Add(new ValueResult<ItemRecipeTreeNode> { Item = item, Value = GetValue(item, takeHighestValue, listings) });
            }
            return result;    
        }

        public bool IsApplicable(ItemRecipeTreeNode item) {
            return true;
        }

        private List<ItemAmountHelper> GetItemIDs(ItemRecipeTreeNode node) {
            var itemIDs = new List<ItemAmountHelper> {
                new ItemAmountHelper { ItemID = node.ItemID, Amount = node.ItemCount }
            };
            foreach (var childNode in node.Children) {
                itemIDs.AddRange(GetItemIDs(childNode));
            }
            return itemIDs;
        }

        private ItemPrice GetValue(ItemRecipeTreeNode node, bool takeHighestValue, List<ItemListingAggregated> listings) {      //Math is slighty off compared to the Wiki.
            ItemPrice itemPrice = null;                                                                                         //Might be bcs the wiki uses vendor prices and we only use TP prices.
            if (listings.Any(x => x.ItemID == node.ItemID)) {                                                                   //Will improve further with visual representation eventually.
                if(takeHighestValue)
                    itemPrice = listings.FirstOrDefault(x => x.ItemID == node.ItemID).Sells.Price;
                else
                    itemPrice = listings.FirstOrDefault(x => x.ItemID == node.ItemID).Buys.Price;
            }

            ItemPrice allChildrenValue = null;
            foreach (var child in node.Children) {
                var childValue = GetValue(child, takeHighestValue, listings);
                if (allChildrenValue == null && childValue != null)
                    allChildrenValue = childValue;
                else if (allChildrenValue != null && childValue != null)
                    allChildrenValue = new ItemPrice(allChildrenValue.Coins + childValue.Coins);
            }

            if (itemPrice == null && allChildrenValue != null)
                itemPrice = allChildrenValue;
            else if (itemPrice == null && allChildrenValue == null)
                return null;
            else if (allChildrenValue != null && itemPrice > allChildrenValue && !takeHighestValue)
                itemPrice = allChildrenValue;


            return itemPrice != null ? new ItemPrice(itemPrice.Coins * node.ItemCount) : null;
        }
    }
    
    class ItemAmountHelper
    {
        public int ItemID { get; set; }
        public int Amount { get; set; }
    }
}