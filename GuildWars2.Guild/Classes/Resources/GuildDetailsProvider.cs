using GuildWars2.API;
using GuildWars2.API.Model.Guild;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.Guild.Classes.Resources
{
    class GuildDetailsProvider : IResourceProvider<GuildDetails>
    {
        private Dictionary<string, GuildDetails> _guildDetails = new Dictionary<string, GuildDetails>();

        public int Capacity { get; set; }

        public async Task<GuildDetails> Get(string identifier) {
            if(!_guildDetails.ContainsKey(identifier)) {
                var details = await GuildAPI.DetailsByName(identifier);
                if(details != null) {
                    _guildDetails.Add(identifier, details);
                }
                else {
                    return null;
                }
            }
            return _guildDetails[identifier];
        }

        public async Task<List<GuildDetails>> Get(List<string> identifiers) {
            var detailsList = new List<GuildDetails>();
            foreach(var identifier in identifiers) {
                var details = await Get(identifier);
                if(details != null)
                    detailsList.Add(details);
            }
            return detailsList;
        }

        public async Task<List<GuildDetails>> Get(List<int> IDs) {
            var identifiers = new List<string>();
            foreach(var id in IDs) {
                identifiers.Add(id.ToString());
            }
            return await Get(identifiers);
        }

        public async Task<GuildDetails> Get(int ID) {
            return await Get(ID.ToString());
        }
    }
}
