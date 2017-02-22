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

        /*public List<string> ForegroundLayers
        {
            get
            {
                if(_foregroundLayers == null && GuildDetails?.Emblem?.ForegroundID != null)
                    _foregroundLayers = GuildAPI.EmblemForegrounds(GuildDetails.Emblem.ForegroundID).Layers;

                return _foregroundLayers;
            }
        }

        public string ForegroundSource1
        {
            get {
                if(ForegroundLayers?.Count >= 1) 
                    return ForegroundLayers[0];

                return string.Empty;
            }
        }

        public string ForegroundSource2
        {
            get {
                if(ForegroundLayers?.Count >= 2)
                    return ForegroundLayers[1];

                return string.Empty;
            }
        }

        public string ForegroundSource3
        {
            get {
                if(ForegroundLayers?.Count >= 3)
                    return ForegroundLayers[2];

                return string.Empty;
            }
        }*/

        public virtual ICommand GoToSource => new CommandHandler(() => {
            System.Diagnostics.Process.Start("https://github.com/Roytazz/GuildWars2.Projects");
        });
    }
}
