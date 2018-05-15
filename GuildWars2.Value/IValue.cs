using GuildWars2.API.Model.Commerce;
using System;

namespace GuildWars2.Value
{
    public interface IValue<T> : IComparable<IValue<T>>
    {
        ItemPrice Value();

        T SourceItem { get; set; }
    }

    public interface ISellable<T> : IValue<T>
    {
        ItemPrice VendorValue();
    }

    public interface ICraftable<T> : IValue<T>
    {
        ItemPrice CraftingValue();
    }

    public class ValueResult<T>
    {
        public T Item { get; set; }

        public ItemPrice Value { get; set; }
    }
}