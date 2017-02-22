using GuildWars2API.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2Value
{
    class ValueFactory
    {
        public IValue Generate(Item item) {
            return Generate(new List<Item> { item });
        }

        public IValue Generate(List<Item> items) {
            return null;    //TODO
        }
    }
}