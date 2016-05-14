using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2Guild.Classes.Resources
{
    internal interface IResourceProvider<T>
    {
        T Get(int ID);
        List<T> Get(List<int> ID);
    }
}
