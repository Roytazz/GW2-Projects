using GuildWars2API.Model.Guild;
using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GuildWars2Guild.Model.ViewModel
{
    abstract class MemberViewModel<T> : FilterViewModel<T>  where T : DisplayLogEntry, new ()
    {
        public List<T> MainCollection { get; set; }

        public MemberViewModel(params string[] type) {
            MainCollection = GetMemberEntries(type).OrderByDescending(entry => entry.Time).ToList();
            MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
            MainCollectionView.Filter = OnFilter;
        }

        private List<T> GetMemberEntries(params string[] types) {
            var entries = LogDbManager.GetLogEntriesByType(types).ToList();

            var results = new List<T>();
            entries.ForEach(entry => { results.Add(Reflection.CopyFrom(new T(), entry)); });
            return results;
        }

        protected override bool OnFilter(object value) {
            throw new NotImplementedException();
        }
    }
}
