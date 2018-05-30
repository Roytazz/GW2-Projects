using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker
{
    interface IUserWorker : IWorker
    {
        Task Run(CancellationToken token, List<string> apiKeys);        
    }

    interface IDataWorker : IWorker
    {
        Task Run(CancellationToken token);
    }

    interface IWorker
    {
        event EventHandler<ProgressChangedEventArgs> ProgressChanged;
    }

    public class ProgressChangedEventArgs
    {
        public string Message { get; set; }
        public int PartialProgress { get; set; }
        public int OverallProgress { get; set; }
    }
}
