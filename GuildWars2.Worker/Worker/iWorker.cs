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
        event EventHandler<WorkerStartedEventArgs> WorkerStarted;
        event EventHandler<WorkerProgressEventArgs> ProgressChanged;
        event EventHandler<WorkerFinishedEventArgs> WorkerFinished;
    }

    public class WorkerStartedEventArgs
    {
        public Type WorkerType { get; set; }

        public int KeyAmount { get; set; } = -1;

        public override string ToString() {
            if(KeyAmount == -1)
                return $"Starting {WorkerType.Name}...";
            else
                return $"Starting {WorkerType.Name} with {KeyAmount} API-Keys...";
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
                return $"\r{Message}...{PartialProgress}%";
            else
                return $"\r{Message}...{PartialProgress}% out of {OverallProgress}%";
        }
    }
}