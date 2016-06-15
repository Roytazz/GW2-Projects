using System;
using System.Collections.Generic;

namespace GuildWars2Guild.Classes.Logger
{
    internal abstract class BaseLogger
    {
        protected string DateTimeString
        {
            get {
                return DateTime.Now.ToString("");
            }
        }

        protected string GetMessageTypeName(LogType messageType) {
            return Enum.GetName(typeof(LogType), messageType).ToUpper();
        }

        protected List<Exception> GetRealException(Exception ex) {
            List<Exception> exceptions = new List<Exception>();
            if(ex != null) {
                if(ex is AggregateException) {

                    foreach(Exception singleEx in (ex as AggregateException).InnerExceptions) {
                        exceptions.Add(singleEx);
                    }
                }
                else {
                    while(ex.InnerException != null)
                        ex = ex.InnerException;

                    exceptions.Add(ex);
                }
            }
            return exceptions;
        }
    }
}
