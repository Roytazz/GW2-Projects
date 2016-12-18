using GuildWars2API.Model.Commerce;
using GuildWars2API.Model.Items;
using GuildWars2API.Model.Recipes;
using System;

namespace GuildWars2API.Model.Value
{
    abstract class BaseValue : IValue
    {
        private ItemPrice _value;

        public virtual ItemPrice GetValue() {
            return _value;
        }
    }

    class ItemValue : BaseValue, IItemValue
    {
        private Item Item { get; set; }

        public override ItemPrice GetValue() {
            return new ItemPrice(Item.VendorValue);
        }

        public virtual ItemPrice GetHighestValue() {
            return GetValue();
        }
    }

    class CraftItemValue : ItemValue, ICraftableItemValue
    {
        private RecipeTreeNode Recipe { get; set; }

        public ItemPrice GetCraftValue() {
            return null; //TODO
        }

        public override ItemPrice GetHighestValue() {
            return GetCraftValue() > GetValue() ? GetCraftValue() : GetValue();
        }
    }

    class SellableItemValue : ItemValue, ISellableItemValue
    {
        private ItemListing Listing { get; set; }

        public ItemPrice GetSellValue() {
            return new ItemPrice(Listing.Sells.UnitPrice);
        }

        public ItemPrice GetBuyValue() {
            return new ItemPrice(Listing.Buys.UnitPrice);
        }

        public override ItemPrice GetHighestValue() {
            return GetSellValue() > GetValue() ? GetSellValue() : GetValue();
        }
    }

    class UnboundItemValue : ItemValue, ICraftableItemValue, ISellableItemValue
    {
        private ItemListing Listing { get; set; }
        private RecipeTreeNode Recipe { get; set; }

        public ItemPrice GetCraftValue() {
            throw new NotImplementedException();
        }

        public ItemPrice GetBuyValue() {
            throw new NotImplementedException();
        }

        public ItemPrice GetSellValue() {
            throw new NotImplementedException();
        }

        public override ItemPrice GetHighestValue() {
            return null; //TODO
        }
    }
}
