using GuildWars2.Value;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using GuildWars2.API.Items;
using GuildWars2.API;
using GuildWars2.API.Model.Commerce;

namespace GuildWars2.Worker.ValueService
{
    public class RecipeValueService : IValueService<ItemRecipeTreeNode>
    {
        public async Task<ValueResult<ItemRecipeTreeNode>> CalculateValue(ItemRecipeTreeNode item, bool takeHighestValue) {
            var result = await CalculateValue(new List<ItemRecipeTreeNode> { item }, takeHighestValue);
            return result.FirstOrDefault();
        }

        public async Task<List<ValueResult<ItemRecipeTreeNode>>> CalculateValue(List<ItemRecipeTreeNode> items, bool takeHighestValue) {
            var result = new List<ValueResult<ItemRecipeTreeNode>>();
            foreach (var item in items) {
                var itemIDs = GetItemIDs(item).Select(x=>x.ItemID).Distinct().ToList();
                var listings = await CommerceAPI.ListingsAggregated(itemIDs);

                var itemPrice = new ItemPrice();
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
                    itemPrice = listings.Find(x => x.ItemID == node.ItemID).Sells.Price;
                else
                    itemPrice = listings.Find(x => x.ItemID == node.ItemID).Buys.Price;
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