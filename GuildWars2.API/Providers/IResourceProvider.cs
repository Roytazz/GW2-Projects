using System;
using System.Collections.Generic;

namespace GuildWars2.API.Providers
{
    [Obsolete]
    public interface IResourceProvider<T>
    {
        int Capacity { get; set; }

        T Get(int ID);

        List<T> Get(List<int> IDs);

        T Get(string identifier);

        List<T> Get(List<string> identifiers);
    }
}