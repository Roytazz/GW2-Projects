using System;

namespace GuildWars2API.Logger
{
    interface ILogger
    {
        void LogMessage(string message);
        void LogException(Exception ex, string message);
    }
}
