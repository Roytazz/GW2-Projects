using GuildWars2API.Model.Color;
using GuildWars2API.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using static GuildWars2API.Network.NetworkManager;

namespace GuildWars2API
{
    public static class MiscAPI     //TODO Document and double check API from GitHub
    {
        public static List<Color> GetColors() {
            JObject result = UnauthorizedRequest<object>(URLBuilder.GetColors()) as JObject;

            var colorCollection = new List<Color>();
            if(result.Last != null && result.Last.Last != null) {
                foreach(var color in result.Last.Last) {
                    colorCollection.Add(JsonConvert.DeserializeObject(color.First.ToString(), typeof(Color)) as Color);
                }
            }
            return colorCollection;
        }
    }
}
