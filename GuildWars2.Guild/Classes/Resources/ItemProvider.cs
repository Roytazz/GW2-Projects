using GuildWars2API.Model.Items;
using System.Collections.Generic;
using System.Linq;

namespace GuildWars2Guild.Classes.Resources
{
    class ItemProvider : IResourceProvider<Item>
    {
        private List<Item> _items = new List<Item>();

        public int Capacity { get; set; }

        public Item Get(int ID) {
            var item = _items.Find(i => i.ID == ID);
            if(item == null) {
                var itemFound = GuildWars2API.ItemAPI.GetItem(ID);
                if(itemFound == null)
                    return null;

                Add(itemFound);
                return Get(ID);
            }
            return _items.Find(i => i.ID == ID);
        }

        public List<Item> Get(List<int> IDs) {
            var newItems = IDs.Where(id => !_items.Any(item => item.ID == id));
            var result = GuildWars2API.ItemAPI.GetItem(new HashSet<int>(newItems));

            foreach(var item in result) {
                if(item != null)
                    Add(item);
            }
            return _items.Where(item => IDs.Any(id => item.ID == id)).ToList();
        }

        public Item Get(string identifier) {
            int id;
            if(int.TryParse(identifier, out id))
                return Get(id);

            return null;
        }

        public List<Item> Get(List<string> identifiers) {
            List<int> ids = new List<int>();
            foreach(string identifier in identifiers) {
                int id;
                if(int.TryParse(identifier, out id))
                    ids.Add(id);
            }
            return Get(ids);
        }

        private void Add(Item item) {

            if(_items.Count >= Capacity)
                _items.RemoveAt(0);

            _items.Add(item);
        }

        public void Reset() {
            return;
        }
    }
}
