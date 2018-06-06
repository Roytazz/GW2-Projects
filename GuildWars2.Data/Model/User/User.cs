using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Data.Model
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        
        public string AccountName { get; set; }

        public List<Key> Keys { get; set; }
    }
}