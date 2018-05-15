using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Data.Model
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        public CategoryType Type { get; set; }
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
        Minis = 7
    }
}
