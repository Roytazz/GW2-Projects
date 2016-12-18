using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Items
{
    public class Equipment
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("slot")]
        public EquipmentType Slot { get; set; }

        [JsonProperty("infusions")]
        public List<int> Infusions { get; set; }

        [JsonProperty("upgrades")]
        public List<int> Upgrades { get; set; }

        [JsonProperty("skin")]
        public int Skin { get; set; }

        [JsonProperty("stats")]
        public ItemStats Stats { get; set; }

        [JsonProperty("binding")]
        public EntityBinding Binding { get; set; }

        [JsonProperty("bound_to")]
        public string BoundTo { get; set; }
    }

    public enum EquipmentType {
        HelmAquatic,
        Backpack,
        Coat,
        Boots,
        Gloves,
        Helm,
        Leggings,
        Shoulders,
        Accessory1,
        Accessory2,
        Ring1,
        Ring2,
        Amulet,
        WeaponAquaticA,
        WeaponAquaticB,
        WeaponA1,
        WeaponA2,
        WeaponB1,
        WeaponB2,
        Sickle,
        Axe,
        Pick
    }
}
