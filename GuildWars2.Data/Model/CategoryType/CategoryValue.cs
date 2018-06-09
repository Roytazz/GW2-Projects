using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class CategoryValue : DateEntry
    {
        [Key, JsonIgnore]
        public int ID { get; set; }

        [JsonIgnore]
        public int AccountID { get; set; }

        public int Value { get; set; }

        public int Delta { get; set; }
        
        public CategoryType Category { get; set; }

        [ForeignKey(nameof(AccountID)), JsonIgnore]
        public Account Account { get; set; }
    }

    public enum CategoryType
    {
        Characters = 0,
        Bank = 1,
        GuildBank = 2,
        MaterialStorage = 3,
        SharedInventory = 4,
        Skins = 5,
        Dyes = 6,
        Minis = 7,
        DeliveryBox = 8
    }
}