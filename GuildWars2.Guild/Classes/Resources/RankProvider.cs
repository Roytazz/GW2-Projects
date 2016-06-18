using GuildWars2API.Model.Guild;
using System.Collections.Generic;
using System.Linq;

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
                if(_ranks == null) {
                    var result = GuildWars2API.GuildAPI.GetGuildRanksByGuildName("Frostgorge Champ Train", Properties.Settings.Default.ApiKey);
                    if(result == null)
                        return new List<Rank>();
                }
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
