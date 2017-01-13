using System.Collections.Generic;

namespace GuildWars2API.Model.Items
{
    public class Infusion
    {
        public List<InfusionUpgradeFlag> Flags { get; set; }

        public int ItemID { get; set; }
    }
}