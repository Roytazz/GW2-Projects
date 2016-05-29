using System;

namespace GuildWars2Guild.Classes.Logger
{
    static class LogManager
    {
        public static void LogMessage(string message, LogType messageType = LogType.Message, bool closeApp = false) {
#if DEBUG
            LogMessage<ConsoleLogger>(message, messageType, closeApp);
#endif
#if RELEASE
            LogMessage<FileLogger>(message, closeApp);
#endif
        }

        public static void LogException(Exception ex, string message, LogType messageType = LogType.Exception, bool closeApp = false) {
#if DEBUG
            LogException<ConsoleLogger>(ex, message, messageType, closeApp);
#endif
#if RELEASE
            LogException<FileLogger>(ex, message, closeApp);
#endif
        }

        public static void LogMessage<T>(string message, LogType messageType = LogType.Message, bool closeApp = false) where T : ILogger {
            var logger = (T)Activator.CreateInstance(typeof(T));
            logger.LogMessage(message, messageType);

            if(closeApp)
                CloseApplication();
        }

        public static void LogException<T>(Exception ex, string message, LogType messageType = LogType.Exception, bool closeApp = false) where T : ILogger {
            var logger = (T)Activator.CreateInstance(typeof(T));
            logger.LogException(ex, message, messageType);

            if(closeApp)
                CloseApplication();
        }

        private static void CloseApplication() {
            Environment.Exit(1);
        }
    }
}