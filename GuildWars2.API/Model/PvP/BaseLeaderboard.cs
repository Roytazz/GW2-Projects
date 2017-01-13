using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2API.Model.PvP
{
    public class BaseLeaderboard
    {
        public string Name { get; set; }

        public int Rank { get; set; }

        public DateTime Date { get; set; }

        public List<LeaderboardEntry> Scores { get; set; }
    }
}
