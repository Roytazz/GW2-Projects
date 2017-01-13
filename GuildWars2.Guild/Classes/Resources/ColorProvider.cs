using GuildWars2API;
using GuildWars2API.Model.Color;
using System.Collections.Generic;
using System.Linq;

namespace GuildWars2Guild.Classes.Resources
{
    class ColorProvider : IResourceProvider<Color>
    {
        private List<Color> _colors;

        public int Capacity { get; set; }

        private List<Color> Colors {
            get {
                if (_colors == null)
                    _colors = MiscellaneousAPI.Colors();

                return _colors;
            }
        }

        public Color Get(string identifier) {
            int id;
            if (int.TryParse(identifier, out id))
                return Get(id);

            return null;
        }

        public List<Color> Get(List<string> identifiers) {
            List<int> ids = new List<int>();
            foreach(string identifier in identifiers) {
                int id;
                if (int.TryParse(identifier, out id))
                    ids.Add(id);
            }
            return Get(ids);
        }

        public Color Get(int ID) {
            return Colors.Find(color => color.ID == ID);
        }

        public List<Color> Get(List<int> IDs) {
            return Colors.Where(color => IDs.Contains(color.ID)).ToList();
        }

        public void Reset() {
            return;
        }
    }
}
