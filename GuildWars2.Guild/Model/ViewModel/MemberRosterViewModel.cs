using GuildWars2API.Model.Guild;
using GuildWars2Guild.Model.ViewModel.Bases;
using System.Collections.Generic;
using System.Windows.Data;

namespace GuildWars2Guild.Model.ViewModel
{
    class MemberRosterViewModel : BaseViewModel
    {
        public List<Member> MainCollection { get; set; }

        public MemberRosterViewModel() {
            MainCollection = GuildWars2API.GuildAPI.GetMembersByGuildName(Properties.Settings.Default.ApiKey, "Frostgorge Champ Train");
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
        }
    }
}
