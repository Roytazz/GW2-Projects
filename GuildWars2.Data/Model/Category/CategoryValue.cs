using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Data.Model
{
    public class CategoryValue : DateEntry
    {
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }
        
        public int CategoryID { get; set; }

        public int Value { get; set; }

        public int Delta { get; set; }
    }
}