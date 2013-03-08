using System;

namespace Recipes.Models
{
    /// <summary>
    /// An Entity to save an exception logged using NLog
    /// </summary>
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Path { get; set; }
        public string RawUrl { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string TargetSite { get; set; }

        public int TypeId { get; set; }
        public virtual LogType LogType { get; set; }
    }

    public class LogType
    {
        public int LogTypeId { get; set; }
        public string Type { get; set; }
    }

    public enum LogTypeNames
    {
        All = 0,
        Info = 1,
        Warn = 2,
        Debug = 3,
        Error = 4,
        Fatal = 5,
        Exception = 6
    }
}
