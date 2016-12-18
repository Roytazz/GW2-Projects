using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildWars2API.Model.Event
{
    public class WorldBoss : Event
    {
        public List<TimeSpan> Times { get; set; }

        public int DragoniteLootMinimum { get; set; }

        public int DragoniteLootMaximum { get; set; }

        public int ItemLoot { get; set; }

        public int BoxesLoot { get; set; }
    }
}