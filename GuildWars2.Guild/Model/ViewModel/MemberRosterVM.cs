using GuildWars2.API.Model.Guild;
using GuildWars2.Guild.Model.ViewModel.Bases;
using System.Collections.Generic;
using System.Windows.Data;
using GuildWars2.Guild.Classes;
using GuildWars2.Guild.Classes.Resources;
using GuildWars2.API;
using System.Threading.Tasks;

namespace GuildWars2.Guild.Model.ViewModel
{
    class MemberRosterVM : BaseVM
    {
        public List<OrderEntry> MainCollection { get; set; }

        public MemberRosterVM() {
            var guildDetails = ResourceProvider.Instance.GetResource<GuildDetails>(Properties.Settings.Default.GuildName).GetAwaiter().GetResult();
            var members = GuildAPI.Members(guildDetails?.ID, Properties.Settings.Default.ApiKey).GetAwaiter().GetResult();
            if (members != null) {
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
