using GuildWars2.Guild.Controls.Palettes;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Linq;

namespace GuildWars2.Guild.Classes
{
    public static class SwatchesHelper
    {
        public static void LoadTheme() {
            var swatches = SwatchesManager.GetSwatches();
            var baseTheme = Properties.Settings.Default.ThemePrimary;
            if(!string.IsNullOrEmpty(baseTheme)) {
                if(swatches.Any(swatch => swatch.Name.Equals(baseTheme))) {
                    var primarySwatch = swatches.ToList().Find(swatchEntry => swatchEntry.Name.Equals(baseTheme));
                    new PaletteHelper().ReplacePrimaryColor(primarySwatch);
                }
            }

            var accentTheme = Properties.Settings.Default.ThemeAccent;
            if(!string.IsNullOrEmpty(accentTheme)) {
                if(swatches.Any(swatch => swatch.Name.Equals(accentTheme))) {
                    var accentSwatch = swatches.ToList().Find(swatchEntry => swatchEntry.Name.Equals(accentTheme));
                    new PaletteHelper().ReplaceAccentColor(accentSwatch);
                }
            }
        }

        public static void ApplyPrimary(Swatch swatch) {
            Properties.Settings.Default.ThemePrimary = swatch.Name;
            Properties.Settings.Default.Save();
        }

        public static void ApplyAccent(Swatch swatch) {
            Properties.Settings.Default.ThemeAccent = swatch.Name;
            Properties.Settings.Default.Save();
        }
    }
}