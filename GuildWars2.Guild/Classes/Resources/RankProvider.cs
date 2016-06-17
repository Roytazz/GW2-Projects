using GuildWars2API.Model.Guild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2Guild.Classes.Resources
{
    class RankProvider : IResourceProvider<Rank>
    {
        private List<Rank> _ranks;

        public int Capacity { get; set; }

        private List<Rank> Ranks
        {
            get
            {
                if(_ranks == null)
                    _ranks = GuildWars2API.GuildAPI.GetGuildRanksByGuildName("Frostgorge Champ Train", "C16DC8F8-3888-8B46-8FE0-822491AF897AC0C9DB04-B655-4F80-962A-13255FABD616");     //TODO Setting

                return _ranks;
            }
        }

        public Rank Get(string identifier) {
            return Ranks.Find(rank => rank.ID.Equals(identifier));
        }

        public List<Rank> Get(List<string> identifiers) {
            return Ranks.Where(rank => identifiers.Contains(rank.ID)).ToList();
        }

        public List<Rank> Get(List<int> ids) {
            var identifiers = new List<string>();
            foreach(int id in ids) {
                identifiers.Add(id.ToString());
            }
            return Get(identifiers);
        }

        public Rank Get(int ID) {
            return Get(ID.ToString());
        }

        public void Reset() {
            if(_ranks != null)
                _ranks.Clear();
        }
    }
}
