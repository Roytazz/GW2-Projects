using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Data.Model
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
