using System;
using System.Collections.Generic;

using static GuildWars2Guild.Classes.IO.IOManager;

namespace GuildWars2Guild.Classes.Logger
{
    class FileLogger : BaseLogger, ILogger
    {

        public void LogMessage(string message, LogType messageType) {
            WriteToLog($"[{DateTimeString}][{GetMessageTypeName(messageType)}] {message}");
        }

        public void LogException(Exception ex, string message, LogType messageType) {
            List<Exception> exceptions = GetRealException(ex);
            if(exceptions.Count > 1) {
                WriteToLog($"[{DateTimeString}][{GetMessageTypeName(messageType)}] Multiple Exceptions found:");
            }

            WriteToLog($"[{DateTimeString}][{GetMessageTypeName(messageType)}] {message} | {ex.Message}");
            foreach(Exception singleEx in exceptions) {
                WriteToLog($"[{DateTimeString}][{GetMessageTypeName(messageType)}] {singleEx.ToString()}");
            }

            if(exceptions.Count > 1) {
                WriteToLog($"[{DateTimeString}][{GetMessageTypeName(messageType)}] End of Multiple Exceptions");
            }
        }
    }
}
