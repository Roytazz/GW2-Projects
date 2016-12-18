using GuildWars2API.Model.Commerce;
using GuildWars2API.Model.Items;
using GuildWars2API.Model.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2API.Model.Value
{
    interface IValue
    {
        ItemPrice GetValue();
    }

    interface IItemValue : IValue
    {
        ItemPrice GetHighestValue();
    }

    interface ICraftableItemValue : IItemValue
    {
        ItemPrice GetCraftValue();
    }

    interface ISellableItemValue : IItemValue
    {
        ItemPrice GetSellValue();
        ItemPrice GetBuyValue();
    }
}
