using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Recipes.Models;

namespace Recipes.SeedData
{
    public class AddLogRelevantData
    {
        public static void Execute(RecipesEntities context)
        {
            try
            {
                var logType1 = new LogType { LogTypeId = 1, Type = "INFO" };
                var logType2 = new LogType { LogTypeId = 2, Type = "WARN" };
                var logType3 = new LogType { LogTypeId = 3, Type = "DEBUG" };
                var logType4 = new LogType { LogTypeId = 4, Type = "ERROR" };
                var logType5 = new LogType { LogTypeId = 5, Type = "FATAL" };
                var logType6 = new LogType { LogTypeId = 6, Type = "EXCEPTION"};

                var logTypes = new List<LogType> { logType1, logType2, logType3, logType4, logType5, logType6 };
                logTypes.ForEach(m => context.LogTypes.Add(m));
                context.SaveChanges();

                var sampleLog1 = new LogEntry
                {
                    Id = 1,
                    LogType = logType1,
                    Message = "Test Message",
                    Path = "www.example.com",
                    RawUrl = "http://www.example.com/message",
                    Source = "Test Source",
                    StackTrace = "index.cs line 1",
                    TargetSite = "Test Target Site",
                    TimeStamp = new DateTime(2013, 1, 31),
                    TypeId = logType1.LogTypeId
                };

                var sampleLog2 = new LogEntry
                {
                    Id = 1,
                    LogType = logType6,
                    Message = "Test Message",
                    Path = "www.example.com",
                    RawUrl = "http://www.example.com/message",
                    Source = "Test Source",
                    StackTrace = "index.cs line 1",
                    TargetSite = "Test Target Site",
                    TimeStamp = new DateTime(2013, 1, 31),
                    TypeId = logType6.LogTypeId
                };

                context.LogEntries.Add(sampleLog1);
                context.LogEntries.Add(sampleLog2);
                context.SaveChanges();
            }
            catch (DbEntityValidationException vex)
            {
                foreach (var err in vex.EntityValidationErrors)
                {
                    foreach (var err2 in err.ValidationErrors)
                    {
                        string msg = err2.ErrorMessage;
                    }
                }
            }
        }
    }
}