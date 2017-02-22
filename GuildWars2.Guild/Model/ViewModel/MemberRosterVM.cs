using GuildWars2API.Model.Guild;
using GuildWars2Guild.Model.ViewModel.Bases;
using System.Collections.Generic;
using System.Windows.Data;
using GuildWars2Guild.Classes;
using Utility.Providers;

namespace GuildWars2Guild.Model.ViewModel
{
    class MemberRosterVM : BaseVM
    {
        public List<OrderEntry> MainCollection { get; set; }

        public MemberRosterVM() {
            var guildDetails = ResourceProvider.Instance.GetResource<GuildDetails>(Properties.Settings.Default.GuildName);
            var members = GuildWars2API.GuildAPI.Members(guildDetails?.ID, Properties.Settings.Default.ApiKey);
            if(members != null) {
                MainCollection = ConvertMembers(members);
                MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
            }
        }

        private List<OrderEntry> ConvertMembers(List<Member> members) {
            var memberEntries = new List<OrderEntry>();
            foreach(Member member in members) {
                memberEntries.Add(Reflection.CopyClass<OrderEntry, Member>(member));
            }
            return memberEntries;
        }
    }
}
