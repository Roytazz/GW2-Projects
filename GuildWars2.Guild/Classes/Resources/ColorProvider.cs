using GuildWars2.API;
using GuildWars2.API.Model.Miscellaneous;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Guild.Classes.Resources
{
    class ColorProvider : IResourceProvider<Color>
    {
        private List<Color> _colors;

        public int Capacity { get; set; }

        private async Task<List<Color>> GetColors() {
            if (_colors == null)
                _colors = await MiscellaneousAPI.Colors();

            return _colors;
        }

        public Task<Color> Get(string identifier) {
            if (int.TryParse(identifier, out int id))
                return Get(id);

            return null;
        }

        public async Task<List<Color>> Get(List<string> identifiers) {
            List<int> ids = new List<int>();
            foreach(string identifier in identifiers) {
                int id;
                if (int.TryParse(identifier, out id))
                    ids.Add(id);
            }
            return await Get(ids);
        }

        public async Task<Color> Get(int ID) {
            var colors = await GetColors();
            return colors.Find(color => color.ID == ID);
        }

        public async Task<List<Color>> Get(List<int> IDs) {
            var colors = await GetColors();
            return colors.Where(color => IDs.Contains(color.ID)).ToList();
        }
    }
}
