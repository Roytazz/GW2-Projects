using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Data.Model
{
    public class User {
        //[Key]
        public int ID { get; set; }

        //[Key]
        public string AccountName { get; set; }
    }
}