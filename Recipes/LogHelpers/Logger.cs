using System;
using System.Web;
using Recipes.Models;

namespace Recipes.LogHelpers
{
    public static class Logger
    {
        public static void WriteEntry(Exception ex)
        {
            LogEntry entry = BuildExceptionLogEntry(ex);
            SaveLogEntry(entry);        
        }

        public static void WriteEntry(string mesage, string source, int logType)
        {
            LogEntry entry = BuildLogEntry(mesage, source, logType);
            SaveLogEntry(entry);
        }

        private static void SaveLogEntry(LogEntry entry)
        {
            using (RecipesEntities context = new RecipesEntities())
            {
                context.LogEntries.Add(entry);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// This methods creates a LogEntry object ready to be saved
        /// to the database from a string message, source and log type id
        /// </summary>
        /// <param name="message">String message to write</param>
        /// <param name="source">Where the message originated from</param>
        /// <param name="logType">id of the log type (1 for Info, 2 for Warning etc.</param>
        /// <returns>Log Entry ready to be saved to the database</returns>
        private static LogEntry BuildLogEntry(string message, string source, int logType)
        {
            LogEntry entry = BuildLogEntryTemplate();

            entry.Message = message;
            entry.Source = source;
            entry.LogType = GetLogEntryType((LogTypeNames)logType);
            entry.TypeId = logType;

            return entry;
        }

        /// <summary>
        /// This methods creates a LogEntry object ready to be saved
        /// to the database from an Exception object
        /// </summary>
        /// <param name="x">Exception</param>
        /// <returns>Log Entry ready to be saved to the database</returns>
        private static LogEntry BuildExceptionLogEntry(Exception x)
        {
            Exception logException = GetInnerExceptionIfExists(x);
            LogEntry entry = BuildLogEntryTemplate();

            entry.Message = logException.Message;
            entry.Source = logException.Source ?? string.Empty;
            entry.StackTrace = logException.StackTrace ?? string.Empty;
            entry.TargetSite = logException.TargetSite == null ? string.Empty : logException.TargetSite.ToString();
            entry.LogType = GetLogEntryType(LogTypeNames.Exception);
            entry.TypeId = (int) LogTypeNames.Exception;

            return entry;
        }

        /// <summary>
        /// Returns a "template" of the log entry with some values that are common for all log entries
        /// </summary>
        /// <returns>LogEntry entity template</returns>
        private static LogEntry BuildLogEntryTemplate()
        {
            return new LogEntry
                       {
                           Path = HttpContext.Current.Request.Path,
                           RawUrl = HttpContext.Current.Request.RawUrl,
                           TimeStamp = DateTime.Now,
                       };
        }

        /// <summary>
        /// This methods formats an error message so that it is 
        /// in a nice format for the event log or other places
        /// </summary>
        /// <param name="x">The exception</param>
        /// <returns>A formatted error message</returns>
        public static string BuildExceptionMessage(Exception x)
        {
            Exception logException = GetInnerExceptionIfExists(x);

            string strErrorMsg = Environment.NewLine + "Error in Path :" + HttpContext.Current.Request.Path;

            // Get the QueryString along with the Virtual Path
            strErrorMsg += Environment.NewLine + "Raw Url :" + HttpContext.Current.Request.RawUrl;

            // Get the error message
            strErrorMsg += Environment.NewLine + "Message :" + logException.Message;

            // Source of the message
            strErrorMsg += Environment.NewLine + "Source :" + logException.Source;

            // Stack Trace of the error
            strErrorMsg += Environment.NewLine + "Stack Trace :" + logException.StackTrace;

            // Method where the error occurred
            strErrorMsg += Environment.NewLine + "TargetSite :" + logException.TargetSite;
            return strErrorMsg;
        }

        /// <summary>
        /// Creates a LogType entity from an enum value
        /// </summary>
        /// <param name="name">LogTypeNames enum value</param>
        /// <returns>LogType entity</returns>
        private static LogType GetLogEntryType(LogTypeNames name)
        {
            return new LogType{LogTypeId = (int)name, Type = name.ToString()};
        }

        /// <summary>
        /// Returns an Inner Exception if it exists
        /// </summary>
        /// <param name="x">Exception</param>
        /// <returns>Inner exception if exists, otherwise exception</returns>
        private static Exception GetInnerExceptionIfExists(Exception x)
        {
            if (x.InnerException != null)
                return x.InnerException;
            return x;
        }
    }
}