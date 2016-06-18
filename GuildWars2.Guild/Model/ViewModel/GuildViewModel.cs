using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes.Resources;
using System.Collections.Generic;

namespace GuildWars2Guild.Model.ViewModel
{
    class GuildViewModel
    {
        private List<string> _foregroundLayers;

        public GuildDetails GuildDetails { get; set; }

        public string GuildName
        {
            get {
                if(GuildDetails != null) 
                    return string.Format("{0} [{1}]", GuildDetails.GuildName, GuildDetails.Tag);

                return string.Empty;
            }
        }

        public string BackgroundSource {
            get {
                if(GuildDetails?.Emblem?.BackgroundID != null)
                    return GuildWars2API.MiscAPI.GetEmblemBackgroundLayers(GuildDetails.Emblem.BackgroundID)[0];

                return string.Empty;
            }
        }

        public List<string> ForegroundLayers
        {
            get
            {
                if(_foregroundLayers == null && GuildDetails?.Emblem?.ForegroundID != null)
                    _foregroundLayers = GuildWars2API.MiscAPI.GetEmblemForegroundLayers(GuildDetails.Emblem.ForegroundID);

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
        }

        public GuildViewModel() {
            GuildDetails = ResourceManager.Instance.GetResource<GuildDetails>(Properties.Settings.Default.GuildName);
        }
    }
}
