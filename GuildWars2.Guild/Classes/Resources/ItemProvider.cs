using GuildWars2API.Model.Items;
using System;
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
            return _items.Single(i => i.ID == ID);
        }

        public List<Item> Get(List<int> IDs) {
            var newItems = IDs.Where(id => !_items.Any(item => item.ID == id));
            var result = GuildWars2API.ItemAPI.GetItem(new HashSet<int>(newItems));

            result.ForEach(item => {
                if(item != null)
                    Add(item);
            });

            return _items.Where(item => IDs.Any(id => item.ID == id)).ToList();
        }

        private void Add(Item item) {

            if(_items.Count >= Capacity)
                _items.RemoveAt(0);

            _items.Add(item);
        }
    }
}
