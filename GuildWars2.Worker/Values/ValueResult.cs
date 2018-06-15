using GuildWars2.API.Model.Commerce;
using System;

namespace GuildWars2.Worker.Values
{
    public class ValueResult<T>
    {
        public T Item { get; set; }

        public ItemPrice Value { get; set; }
    }
}