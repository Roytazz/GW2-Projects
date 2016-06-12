using GuildWars2API.Model.Color;
using GuildWars2API.Model.Guild;
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
                    var colorObj = JsonConvert.DeserializeObject(color.First.ToString(), typeof(Color)) as Color;
                    colorObj.ID = int.Parse((color as JProperty).Name);
                    colorCollection.Add(colorObj);
                }
            }
            return colorCollection;
        }

        public static List<string> GetEmblemBackgroundLayers(int id) {
            var result = UnauthorizedRequest<List<Emblem>>(URLBuilder.GetEmblemBackgroundLayers(id));
            return result[0].Layers;
        }

        public static List<string> GetEmblemForegroundLayers(int id) {
            var result = UnauthorizedRequest<List<Emblem>>(URLBuilder.GetEmblemForegroundLayers(id));
            return result[0].Layers;
        }
    }
}
