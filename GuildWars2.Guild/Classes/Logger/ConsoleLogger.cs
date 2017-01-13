using System;
using System.Collections.Generic;

namespace GuildWars2Guild.Classes.Logger
{
    class ConsoleLogger : BaseLogger, ILogger
    {
        public void LogMessage(string message, LogMessageType messageType) {
            Console.WriteLine($"[{GetMessageTypeName(messageType)}] {message}");
        }

        public void LogException(Exception ex, string message, LogMessageType messageType) {
            List<Exception> exceptions = GetRealException(ex);
            if(exceptions.Count > 1) {
                Console.WriteLine($"[{GetMessageTypeName(messageType)}] Multiple Exceptions found:");
            }

            Console.WriteLine($"[{GetMessageTypeName(messageType)}] {message} | {ex.Message}");
            foreach(Exception singleEx in exceptions) {
                Console.WriteLine($"[{GetMessageTypeName(messageType)}] {singleEx.ToString()}");
            }

            if(exceptions.Count > 1) {
                Console.WriteLine($"[{GetMessageTypeName(messageType)}] End of Multiple Exceptions");
            }
        }
    }
}
