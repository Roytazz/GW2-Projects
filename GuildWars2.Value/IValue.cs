using GuildWars2API.Model.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2Value
{
    public interface IValue
    {
        ItemPrice Value();
    }

    public interface ISellable : IValue
    {
        ItemPrice VendorValue();
    }

    public interface ICraftable : IValue
    {
        ItemPrice CraftingValue();
    }

    public class BoundItem : IValue
    {
        public ItemPrice CraftingValue() {
            throw new NotImplementedException();
        }

        public ItemPrice Value() {
            throw new NotImplementedException();
        }
    }

    public class CraftableItem : ICraftable
    {
        public ItemPrice CraftingValue() {
            throw new NotImplementedException();
        }

        public ItemPrice Value() {
            throw new NotImplementedException();
        }
    }

    public class SellableItem : ISellable
    {
        public ItemPrice Value() {
            throw new NotImplementedException();
        }

        public ItemPrice VendorValue() {
            throw new NotImplementedException();
        }
    }

    public class UnboundItem : ICraftable, ISellable
    {
        public ItemPrice CraftingValue() {
            throw new NotImplementedException();
        }

        public ItemPrice Value() {
            throw new NotImplementedException();
        }

        public ItemPrice VendorValue() {
            throw new NotImplementedException();
        }
    }
}