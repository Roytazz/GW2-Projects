using GuildWars2API.Model.Commerce;
using GuildWars2API.Model.Items;

namespace GuildWars2Guild.Model
{
    public class ItemEntry : DisplayLogEntry
    {
        public Item Item { get; set; }

        public ItemListing Listing { get; set; }

        public string ItemColor {
            get {
                var type = Item.Type;
                if(!string.IsNullOrEmpty(type)) {
                    if(type.Equals("Junk")) {
                        return "#FFA6A6A6";
                    }
                    else if(type.Equals("Basic")) {
                        return "#FFFFFF";
                    }
                    else if(type.Equals("Fine")) {
                        return "#4099ff";
                    }
                    else if(type.Equals("Masterwork")) {
                        return "#669900";
                    }
                    else if(type.Equals("Rare")) {
                        return "#FFFF00";
                    }
                    else if(type.Equals("Exotic")) {
                        return "#FF9933";
                    }
                    else if(type.Equals("Ascended")) {
                        return "#FF3399";
                    }
                    else if(type.Equals("Legendary")) {
                        return "#CC00CC";
                    }
                }
                return "#FFFFFF";
            }
        }
    }
}
