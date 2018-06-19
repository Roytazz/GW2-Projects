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

    interface IResultUserWorker<T> : IWorker
    {
        Task<T> Run(CancellationToken token, string apiKey);
    }

    interface IWorker
    {
        event EventHandler<WorkerStartedEventArgs> WorkerStarted;
        event EventHandler<WorkerProgressEventArgs> ProgressChanged;
        event EventHandler<WorkerFinishedEventArgs> WorkerFinished;
    }

    public class WorkerStartedEventArgs
    {
        public Type WorkerType { get; set; }

        public override string ToString() {
            return $"Starting {WorkerType.Name}...";
        }
    }

    public class WorkerFinishedEventArgs
    {
        public Type WorkerType { get; set; }

        public TimeSpan Duration { get; set; }

        public override string ToString() {
            return $"{WorkerType.Name} done in {Math.Round(Duration.TotalSeconds, 1)} seconds!";
        }
    }

    public class WorkerProgressEventArgs
    {
        public string Message { get; set; }

        public int PartialProgress { get; set; }

        public int OverallProgress { get; set; } = -1;

        public override string ToString() {
            if(OverallProgress == -1)
                return $"\t{Message}...{PartialProgress}%";
            else
                return $"\t{Message}...{PartialProgress}% out of {OverallProgress}%";
        }
    }
}