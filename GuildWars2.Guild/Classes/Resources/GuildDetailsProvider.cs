using GuildWars2API.Model.Guild;
using System.Collections.Generic;

namespace GuildWars2Guild.Classes.Resources
{
    class GuildDetailsProvider : IResourceProvider<GuildDetails>
    {
        private Dictionary<string, GuildDetails> _guildDetails = new Dictionary<string, GuildDetails>();

        public int Capacity { get; set; }

        public GuildDetails Get(string identifier) {
            if(!_guildDetails.ContainsKey(identifier)) {
                var details = GuildWars2API.GuildAPI.GetGuildDetails(identifier);
                if(details != null) {
                    _guildDetails.Add(identifier, details);
                }
                else {
                    return null;
                }
            }
            return _guildDetails[identifier];
        }

        public List<GuildDetails> Get(List<string> identifiers) {
            var detailsList = new List<GuildDetails>();
            foreach(var identifier in identifiers) {
                var details = Get(identifier);
                if(details != null)
                    detailsList.Add(details);
            }
            return detailsList;
        }

        public List<GuildDetails> Get(List<int> IDs) {
            var identifiers = new List<string>();
            foreach(var id in IDs) {
                identifiers.Add(id.ToString());
            }
            return Get(identifiers);
        }

        public GuildDetails Get(int ID) {
            return Get(ID.ToString());
        }

        public void Reset() {
            return;
        }
    }
}
