using System;
using System.Collections.Generic;

namespace Utility.Network
{
    class HttpRequestHandler : IWebHandler
    {
        public T GetRequest<T>(string url, Dictionary<string, string> headers) {
            throw new NotImplementedException();
        }
    }
}
