using GuildWars2Guild.Classes;
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
            get
            {
                if(_swatches == null)
                    _swatches = SwatchesManager.GetSwatches();

                return _swatches;
            }
        }

        public PaletteSelectorControl() {
            InitializeComponent();
        }

        /*public ICommand ApplyBaseTheme { get; } = new PaletteCommandHandler(o => ApplyBase((bool)o));
        private static void ApplyBase(bool isDark) {
            new PaletteHelper().SetLightDark(isDark);
        }*/

        public ICommand ApplyPrimaryCommand { get; } = new PaletteCommandHandler(o => SwatchesManager.ApplyPrimary((Swatch)o));

        public ICommand ApplyAccentCommand { get; } = new PaletteCommandHandler(o => SwatchesManager.ApplyAccent((Swatch)o));
    }
}
