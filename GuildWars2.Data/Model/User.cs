using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuildWars2.Data.Model
{
    public class User
    {
        [Key]
        public string Key { get; set; }
    }
}
