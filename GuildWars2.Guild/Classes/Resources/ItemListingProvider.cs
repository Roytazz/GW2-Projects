using GuildWars2.API;
using GuildWars2.API.Model.Commerce;
using GuildWars2.API.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Guild.Classes.Resources
{
    class ItemListingProvider : IResourceProvider<ItemListing>
    {
        private List<ItemListing> _listings = new List<ItemListing>();

        public int Capacity { get; set; }

        public async Task<ItemListing> Get(int ID) {
            var item = _listings.Find(i => i.ItemID == ID);
            if(item == null) {
                var listingFound = await CommerceAPI.Listings(ID);
                if(listingFound == null)
                    return null;

                Add(listingFound);
                return await Get(ID);
            }
            return _listings.Find(i => i.ItemID == ID);
        }

        public async Task<List<ItemListing>> Get(List<int> IDs) {
            var newListings = IDs.Where(id => !_listings.Any(listing => listing.ItemID == id));
            var result = await CommerceAPI.Listings(new List<int>(newListings));

            if (result == null)
                return null;

            foreach(var listing in result) {
                if(listing != null)
                    Add(listing);
            }
            return _listings.Where(item => IDs.Any(id => item.ItemID == id)).ToList();
        }

        public async Task<ItemListing> Get(string identifier) {
            if(int.TryParse(identifier, out int id))
                return await Get(id);

            return null;
        }

        public async Task<List<ItemListing>> Get(List<string> identifiers) {
            List<int> ids = new List<int>();
            foreach(string identifier in identifiers) {
                if(int.TryParse(identifier, out int id))
                    ids.Add(id);
            }
            return await Get(ids);
        }

        private void Add(ItemListing listing) {
            if(_listings.Count >= Capacity)
                _listings.RemoveAt(0);

            _listings.Add(listing);
        }
    }
}
