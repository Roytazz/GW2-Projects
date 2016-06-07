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
    abstract class MemberViewModel<T>  where T : DisplayLogEntry, new ()
    {
        public List<T> MainCollection { get; set; }

        public MemberViewModel(params string[] type) {
            MainCollection = GetMemberEntries(type).OrderByDescending(entry => entry.Time).ToList();
        }

        private List<T> GetMemberEntries(params string[] types) {
            var entries = LogDbManager.GetLogs(types).ToList();

            var results = new List<T>();
            entries.ForEach(entry => { results.Add(Reflection.CopyClass(new T(), entry)); });
            return results;
        }
    }
}
