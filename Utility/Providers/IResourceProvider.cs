using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Providers
{
    public interface IResourceProvider<T>
    {
        T Get(int ID);

        List<T> Get(List<int> IDs);

        T Get(string identifier);

        List<T> Get(List<string> identifiers);

        void Reset();

        int Capacity { get; set; }
    }
}
