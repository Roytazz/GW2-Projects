using GuildWars2.API.Model.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Manager
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

    public interface IValueService
    {
        IValue CalculateValue<TItem>(TItem item);
    }

    public abstract class BaseValueService : IValueService
    {
        public abstract IValue CalculateValue<TItem>(TItem item);

        public abstract override int GetHashCode();
        public abstract override bool Equals(object obj);
    }
}