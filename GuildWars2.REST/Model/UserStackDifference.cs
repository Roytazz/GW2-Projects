using GuildWars2.Manager.InventoryService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.REST.Model
{
    public class UserItemStackDifference : ItemStackDifference
    {
        [Key]
        public int ID { get; set; }

        public string AccountName { get; set; }
    }

    public class UserCurrencyDifference : CurrencyDifference
    {
        [Key]
        public int ID { get; set; }

        public string AccountName { get; set; }
    }

    public class UserAccountDifference
    {
        public List<UserItemStackDifference> Items { get; set; }

        public List<UserCurrencyDifference> Currencies { get; set; }
    }
}