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
        
        public CategoryValueType Category { get; set; }

        [ForeignKey(nameof(AccountID)), JsonIgnore]
        public Account Account { get; set; }
    }

    public enum CategoryValueType
    {
        Default = 0,
        Characters = 1,
        Bank = 2,
        GuildBank = 3,
        MaterialStorage = 4,
        SharedInventory = 5,
        Skins = 6,
        Dyes = 7,
        Minis = 8,
        DeliveryBox = 9
    }
}