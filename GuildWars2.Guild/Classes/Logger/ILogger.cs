using System;

namespace GuildWars2.Guild.Classes.Logger
{
    interface ILogger
    {
        void LogMessage(string message, LogMessageType messageType);
        void LogException(Exception ex, string message, LogMessageType messageType);
    }

    public enum LogMessageType
    {
        Info,       //Used for general info about processes starting or finishing
        Message,    //Used for weird or unusual situations that aren't error worthy
        Exception   //Used for exceptions
    }
}
