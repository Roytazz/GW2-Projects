using GuildWars2APIPlaceHolder.Model.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Account
{
    public class Material : ItemStack
    {
        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("binding")]
        public EntityBinding Binding { get; set; }
    }
}
