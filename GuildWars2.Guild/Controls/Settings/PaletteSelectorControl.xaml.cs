using GuildWars2Guild.Classes.MVVM;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace GuildWars2Guild.Controls.Settings
{
    /// <summary>
    /// Interaction logic for PaletteSelector.xaml
    /// </summary>
    public partial class PaletteSelectorControl : UserControl
    {
        public IEnumerable<Swatch> Swatches => Classes.SwatchesProvider.GetSwatches();

        public PaletteSelectorControl() {
            InitializeComponent();
        }

        public ICommand ApplyBaseTheme { get; } = new PaletteCommandHandler(o => ApplyBase((bool)o));
        private static void ApplyBase(bool isDark) {
            new PaletteHelper().SetLightDark(isDark);
        }

        public ICommand ApplyPrimaryCommand { get; } = new PaletteCommandHandler(o => ApplyPrimary((Swatch)o));
        private static void ApplyPrimary(Swatch swatch) {
            new PaletteHelper().ReplacePrimaryColor(swatch);
        }

        public ICommand ApplyAccentCommand { get; } = new PaletteCommandHandler(o => ApplyAccent((Swatch)o));
        private static void ApplyAccent(Swatch swatch) {
            new PaletteHelper().ReplaceAccentColor(swatch);
        }
    }
}
