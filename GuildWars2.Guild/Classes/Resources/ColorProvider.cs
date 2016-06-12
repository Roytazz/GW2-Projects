using GuildWars2API.Model.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2Guild.Classes.Resources
{
    class ColorProvider : IResourceProvider<Color>
    {
        private List<Color> _colors;

        public int Capacity { get; set; }

        private List<Color> Colors {
            get {
                if(_colors == null)
                    _colors = GuildWars2API.MiscAPI.GetColors();

                return _colors;
            }
        }

        public Color Get(int ID) {
            return Colors.Find(color => color.ID == ID);
        }

        public List<Color> Get(List<int> ID) {
            return Colors.Where(color => ID.Contains(color.ID)).ToList();
        }
    }
}
