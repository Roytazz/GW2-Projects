using System;

namespace GuildWars2.Data.Model
{
    public class Skin : DateEntry
    {
        //[Key]
        public int UserID { get; set; }

        //[Key]
        public int SkinID { get; set; }
    }
}