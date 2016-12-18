using System.Collections.Generic;

namespace Utility.Network
{
    public interface IWebHandler
    {
        T GetRequest<T>(string url, Dictionary<string, string> headers);
    }
}
