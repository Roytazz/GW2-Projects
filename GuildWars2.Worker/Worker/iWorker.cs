using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker.Worker
{
    interface IWorker
    {
        Task Run(CancellationToken token, params string[] apiKeys);        
    }
}
