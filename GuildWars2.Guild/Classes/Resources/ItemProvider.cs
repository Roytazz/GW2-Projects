﻿using GuildWars2API.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildWars2Guild.Classes.Resources
{
    class ItemProvider : IResourceProvider<Item>
    {
        private List<Item> _items = new List<Item>();

        public Item Get(int ID) {
            var item = _items.Find(i => i.ID == ID);
            if(item == null) {
                _items.Add(GuildWars2API.ItemAPI.GetItem(ID));
                return Get(ID);
            }
            return _items.Single(i => i.ID == ID);
        }

        public List<Item> Get(List<int> IDs) {
            var newItems = IDs.Where(id => !_items.Any(item => item.ID == id));
            var result = GuildWars2API.ItemAPI.GetItem(new HashSet<int>(newItems));

            result.ForEach(item => { _items.Add(item); });

            return _items.Where(item => IDs.Any(id => item.ID == id)).ToList();
        }
    }
}
