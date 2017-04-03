using GuildWars2.API;
using GuildWars2.API.Model.Guild;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Guild.Classes.Resources
{
    class RankProvider : IResourceProvider<Rank>
    {
        private List<Rank> _ranks;

        public int Capacity { get; set; }

        private async Task<List<Rank>> GetRanks()
        {
                if(_ranks == null) {
                    var guildDetails = await ResourceProvider.Instance.GetResource<GuildDetails>(Properties.Settings.Default.GuildName);
                    var result = await GuildAPI.Ranks(guildDetails?.ID, Properties.Settings.Default.ApiKey);
                    if(result != null)
                        _ranks = result;
                    else
                        return new List<Rank>();

                }
                return _ranks;
        }

        public async Task<Rank> Get(string identifier) {
            var ranks = await GetRanks();
            return ranks.Find(rank => rank.ID.Equals(identifier));
        }

        public async Task<List<Rank>> Get(List<string> identifiers) {
            var ranks = await GetRanks();
            return ranks.Where(rank => identifiers.Contains(rank.ID)).ToList();
        }

        public async Task<List<Rank>> Get(List<int> ids) {
            var identifiers = new List<string>();
            foreach(int id in ids) {
                identifiers.Add(id.ToString());
            }
            return await Get(identifiers);
        }

        public async Task<Rank> Get(int ID) {
            return await Get(ID.ToString());
        }
    }
}
