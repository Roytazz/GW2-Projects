using System;

namespace Utility.Logger
{
    interface ILogger
    {
        void LogMessage(string message);
        void LogException(Exception ex, string message);
    }
}
