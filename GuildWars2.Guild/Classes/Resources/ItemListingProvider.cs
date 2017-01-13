using GuildWars2API.Model.Commerce;
using System.Collections.Generic;
using System.Linq;

namespace GuildWars2Guild.Classes.Resources
{
    class ItemListingProvider : IResourceProvider<ItemListing>
    {
        private List<ItemListing> _listings = new List<ItemListing>();

        public int Capacity { get; set; }

        public ItemListing Get(int ID) {
            var item = _listings.Find(i => i.ItemID == ID);
            if(item == null) {
                var listingFound = GuildWars2API.CommerceAPI.Listings(ID);
                if(listingFound == null)
                    return null;

                Add(listingFound);
                return Get(ID);
            }
            return _listings.Find(i => i.ItemID == ID);
        }

        public List<ItemListing> Get(List<int> IDs) {
            var newListings = IDs.Where(id => !_listings.Any(listing => listing.ItemID == id));
            var result = GuildWars2API.CommerceAPI.Listings(new List<int>(newListings));

            foreach(var listing in result) {
                if(listing != null)
                    Add(listing);
            }
            return _listings.Where(item => IDs.Any(id => item.ItemID == id)).ToList();
        }

        public ItemListing Get(string identifier) {
            int id;
            if(int.TryParse(identifier, out id))
                return Get(id);

            return null;
        }

        public List<ItemListing> Get(List<string> identifiers) {
            List<int> ids = new List<int>();
            foreach(string identifier in identifiers) {
                int id;
                if(int.TryParse(identifier, out id))
                    ids.Add(id);
            }
            return Get(ids);
        }

        private void Add(ItemListing listing) {
            if(_listings.Count >= Capacity)
                _listings.RemoveAt(0);

            _listings.Add(listing);
        }

        public void Reset() {
            return;
        }
    }
}
