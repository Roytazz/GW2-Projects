using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuildWars2.Data.Model.Data
{
    public class ItemSellable
    {
        [Key]
        public int ID { get; set; }

        public int ItemID { get; set; }

        public bool Sellable { get; set; }

        public bool Blacklisted { get; set; }
    }
}
