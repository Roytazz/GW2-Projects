using GuildWars2.Manager.InventoryService;
using Newtonsoft.Json;
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
        [JsonIgnore]
        public int ID { get; set; }

        [JsonIgnore]
        public string AccountName { get; set; }

        [JsonIgnore]
        public DateTime Date { get; set; }

        [JsonIgnore]
        public bool ManualEntry { get; set; }

        public UserItemStackDifference() { }

        public UserItemStackDifference(ItemStackDifference diff, ApiKey key) {
            Count = diff.Count;
            ItemID = diff.ItemID;
            SkinID = diff.SkinID;
            StatID = diff.StatID;
            Difference = diff.Difference;
            AccountName = key.Name;
            ManualEntry = true;
            Date = DateTime.Now;
        }
    }

    public class UserCurrencyDifference : CurrencyDifference
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }

        [JsonIgnore]
        public string AccountName { get; set; }

        [JsonIgnore]
        public DateTime Date { get; set; }

        [JsonIgnore]
        public bool ManualEntry { get; set; }

        public UserCurrencyDifference() { }

        public UserCurrencyDifference(CurrencyDifference diff, ApiKey key) {
            Count = diff.Count;
            CurrencyID = diff.CurrencyID;
            Difference = diff.Difference;
            AccountName = key.Name;
            ManualEntry = true;
            Date = DateTime.Now;
        }
    }

    public class UserAccountDifference
    {
        public List<UserItemStackDifference> Items { get; set; }

        public List<UserCurrencyDifference> Currencies { get; set; }
    }
}