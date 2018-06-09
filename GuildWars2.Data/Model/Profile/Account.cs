using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Data.Model
{
    public class Account
    {
        public int ID { get; set; }

        public string AccountGUID { get; set; }   //Not used atm

        public string Name { get; set; }
    }
}