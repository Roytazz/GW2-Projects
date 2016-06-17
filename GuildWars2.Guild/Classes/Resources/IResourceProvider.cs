using System.Collections.Generic;

namespace GuildWars2Guild.Classes.Resources
{
    internal interface IResourceProvider<T>
    {
        T Get(int ID);
        List<T> Get(List<int> ID);

        T Get(string identifier);
        List<T> Get(List<string> identifiers);

        void Reset();

        int Capacity { get; set; }
    }
}
