using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker
{
    interface IUserWorker
    {
        Task Run(CancellationToken token, List<string> apiKeys);        
    }

    interface IDataWorker
    {
        Task Run(CancellationToken token);
    }
}
