using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker
{
    interface IAccountWorker
    {
        Task Run(CancellationToken token, List<string> apiKeys);        
    }

    interface IWorker
    {
        Task Run(CancellationToken token);
    }
}
