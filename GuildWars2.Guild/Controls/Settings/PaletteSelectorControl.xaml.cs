using GuildWars2Guild.Classes.MVVM;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace GuildWars2Guild.Controls.Settings
{
    /// <summary>
    /// Interaction logic for PaletteSelector.xaml
    /// </summary>
    public partial class PaletteSelectorControl : UserControl
    {
        private IEnumerable<Swatch> _swatches;

        public IEnumerable<Swatch> Swatches
        {
            get {
                if(_swatches == null)
                    _swatches = Classes.SwatchesProvider.GetSwatches();

                return _swatches;
            }
        }
            

        public PaletteSelectorControl() {
            InitializeComponent();

            LoadTheme();
        }

        /*public ICommand ApplyBaseTheme { get; } = new PaletteCommandHandler(o => ApplyBase((bool)o));
        private static void ApplyBase(bool isDark) {
            new PaletteHelper().SetLightDark(isDark);
        }*/

        public ICommand ApplyPrimaryCommand { get; } = new PaletteCommandHandler(o => ApplyPrimary((Swatch)o));
        private static void ApplyPrimary(Swatch swatch) {
            new PaletteHelper().ReplacePrimaryColor(swatch);
            Properties.Settings.Default.ThemePrimary = swatch.Name;
            Properties.Settings.Default.Save();
        }

        public ICommand ApplyAccentCommand { get; } = new PaletteCommandHandler(o => ApplyAccent((Swatch)o));
        private static void ApplyAccent(Swatch swatch) {
            new PaletteHelper().ReplaceAccentColor(swatch);
            Properties.Settings.Default.ThemeAccent = swatch.Name;
            Properties.Settings.Default.Save();
        }

        private void LoadTheme() {
            var baseTheme = Properties.Settings.Default.ThemePrimary;
            if(!string.IsNullOrEmpty(baseTheme)) {
                if(Swatches.Any(swatch => swatch.Name.Equals(baseTheme))) {
                    var primarySwatch = Swatches.ToList().Find(swatchEntry => swatchEntry.Name.Equals(baseTheme));
                    ApplyPrimary(primarySwatch);
                }
            }

            var accentTheme = Properties.Settings.Default.ThemeAccent;
            if(!string.IsNullOrEmpty(accentTheme)) {
                if(Swatches.Any(swatch => swatch.Name.Equals(accentTheme))) {
                    var accentSwatch = Swatches.ToList().Find(swatchEntry => swatchEntry.Name.Equals(accentTheme));
                    ApplyAccent(accentSwatch);
                }
            }
        }
    }
}
