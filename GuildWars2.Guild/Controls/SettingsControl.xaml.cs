using GuildWars2.Guild.Classes;
using GuildWars2.Guild.Controls.Palettes;
using System.Windows.Controls;

namespace GuildWars2.Guild.Controls
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl() {
            InitializeComponent();
            SwatchesManager.PrimaryChanged += SwatchesManager_PrimaryChanged;
            SwatchesManager.AccentChanged += SwatchesManager_AccentChanged;
        }

        private void SwatchesManager_PrimaryChanged(object sender, SwatchEvent e) {
            SwatchesHelper.ApplyPrimary(e.Swatch);
        }

        private void SwatchesManager_AccentChanged(object sender, SwatchEvent e) {
            SwatchesHelper.ApplyAccent(e.Swatch);
        }
    }
}
