using GuildWars2API.Model.Commerce;
using System.Collections.Generic;
using System.Linq;

namespace GuildWars2Guild.Classes.Resources
{
    class ItemListingProvider : IResourceProvider<ItemListing>
    {
        private List<ItemListing> _listings = new List<ItemListing>();

        public ItemListing Get(int ID) {
            var item = _listings.Find(i => i.ID == ID);
            if(item == null) {
                _listings.Add(GuildWars2API.ItemAPI.GetItemListing(ID));
                return Get(ID);
            }
            return _listings.Single(i => i.ID == ID);
        }

        public List<ItemListing> Get(List<int> IDs) {
            var newListings = IDs.Where(id => !_listings.Any(listing => listing.ID == id));
            var result = GuildWars2API.ItemAPI.GetItemListing(new HashSet<int>(newListings));

            result.ForEach(listing => { _listings.Add(listing); });

            return _listings.Where(item => IDs.Any(id => item.ID == id)).ToList();
        }
    }
}
