using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Character
{
    public class Bag
    {
        public int ID { get; set; }
        public int Size { get; set; }
        public List<BagItem> Inventory { get; set; }
    }
}
