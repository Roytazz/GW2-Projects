using GuildWars2.API.Model.Commerce;
using System;

namespace GuildWars2.Value
{
    public class ValueResult<T>
    {
        public T Item { get; set; }

        public ItemPrice Value { get; set; }
    }
}