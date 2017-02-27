using GuildWars2API;
using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes.MVVM;
using System.Windows.Input;
using System.Windows.Media;
using Utility.Providers;

namespace GuildWars2Guild.Model.ViewModel
{
    class GuildVM
    {
        private GuildDetails _guildDetails;

        public GuildDetails GuildDetails {
            get {
                if(_guildDetails == null) {
                    _guildDetails = ResourceProvider.Instance.GetResource<GuildDetails>(Properties.Settings.Default.GuildName);
                }
                return _guildDetails;
            }
        }

        public string GuildName
        {
            get {
                if(GuildDetails != null) 
                    return string.Format("{0} [{1}]", GuildDetails.Name, GuildDetails.Tag);

                return string.Empty;
            }
        }

        public string BackgroundSource {
            get {
                if (GuildDetails?.Emblem?.Background != null) {
                    var background = GuildAPI.EmblemBackgrounds(GuildDetails.Emblem.Background.ID);
                    return background.Layers[0];
                }

                return string.Empty;
            }
        }

        public SolidColorBrush BackgroundColor
        {
            get {
                if (GuildDetails?.Emblem?.Background != null) {
                    var color = ResourceProvider.Instance.GetResource<GuildWars2API.Model.Miscellaneous.Color>(GuildDetails.Emblem.Background.Colors)[0];
                    return new SolidColorBrush(Color.FromArgb(255, (byte)color.BaseRGB[0], (byte)color.BaseRGB[1], (byte)color.BaseRGB[2]));
                }

                return null;
            }
        }

        public string ForegroundSource
        {
            get {
                if (GuildDetails?.Emblem?.Foreground != null) {
                    var foreground = GuildAPI.EmblemForegrounds(GuildDetails.Emblem.Foreground.ID);
                    return foreground.Layers[0];
                }

                return string.Empty;
            }
        }

        public SolidColorBrush ForegroundColorPrimary
        {
            get {
                if (GuildDetails?.Emblem?.Foreground != null) {
                    var color = ResourceProvider.Instance.GetResource<GuildWars2API.Model.Miscellaneous.Color>(GuildDetails.Emblem.Foreground.Colors)[0];
                    return new SolidColorBrush(Color.FromArgb(255, (byte)color.BaseRGB[0], (byte)color.BaseRGB[1], (byte)color.BaseRGB[2]));
                }

                return null;
            }
        }

        public SolidColorBrush ForegroundColorSecondary
        {
            get {
                if (GuildDetails?.Emblem?.Foreground != null) {
                    var color = ResourceProvider.Instance.GetResource<GuildWars2API.Model.Miscellaneous.Color>(GuildDetails.Emblem.Foreground.Colors)[1];
                    return new SolidColorBrush(Color.FromArgb(255, (byte)color.BaseRGB[0], (byte)color.BaseRGB[1], (byte)color.BaseRGB[2]));
                }

                return null;
            }
        }

        public virtual ICommand GoToSource => new CommandHandler(() => {
            System.Diagnostics.Process.Start("https://github.com/Roytazz/GuildWars2.Projects");
        });
    }
}
