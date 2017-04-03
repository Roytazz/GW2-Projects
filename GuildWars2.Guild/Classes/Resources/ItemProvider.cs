using GuildWars2.API;
using GuildWars2.API.Model.Items;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Guild.Classes.Resources
{
    class ItemProvider : IResourceProvider<Item>
    {
        private List<Item> _items = new List<Item>();

        public int Capacity { get; set; }

        public async Task<Item> Get(int ID) {
            var item = _items.Find(i => i.ID == ID);
            if(item == null) {
                var itemFound = await ItemAPI.Items(ID);
                if(itemFound == null)
                    return null;

                Add(itemFound);
                return await Get(ID);
            }
            return _items.Find(i => i.ID == ID);
        }

        public async Task<List<Item>> Get(List<int> IDs) {
            var newItems = IDs.Where(id => !_items.Any(item => item.ID == id));
            var result = await ItemAPI.Items(new List<int>(newItems));

            if (result == null)
                return null;

            foreach (var item in result) {
                if (item != null)
                    Add(item);
            }
            return _items.Where(item => IDs.Any(id => item.ID == id)).ToList();
        }

        public async Task<Item> Get(string identifier) {
            if(int.TryParse(identifier, out int id))
                return await Get(id);

            return null;
        }

        public async Task<List<Item>> Get(List<string> identifiers) {
            List<int> ids = new List<int>();
            foreach(string identifier in identifiers) {
                if(int.TryParse(identifier, out int id))
                    ids.Add(id);
            }
            return await Get(ids);
        }

        private void Add(Item item) {

            if(_items.Count >= Capacity)
                _items.RemoveAt(0);

            _items.Add(item);
        }
    }
}
