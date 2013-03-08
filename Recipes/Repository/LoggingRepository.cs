using System;
using System.Linq;
using Recipes.Paging;
using Recipes.Models;

namespace Recipes.Repository
{
    public class LoggingRepository
    {
        /// <summary>
        /// Gets a filtered list of log events
        /// </summary>
        /// <param name="pageIndex">0 based page index</param>
        /// <param name="pageSize">max number of records to return</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="logLevel">The level of the log messages</param>
        /// <returns>A filtered list of log events</returns>
        public IPagedList<LogEntry> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logLevel)
        {
            RecipesEntities db = new RecipesEntities();

            IQueryable<LogEntry> list =
                db.LogEntries.Where(
                    e =>
                    (e.TimeStamp >= start && e.TimeStamp <= end));

            if(logLevel != LogTypeNames.All.ToString())
            {
                list = list.Where(e => e.LogType.Type.ToLower() == logLevel.ToLower());
            }

            list = list.OrderByDescending(e => e.TimeStamp);

            return new PagedList<LogEntry>(list, pageIndex, pageSize);
        }

        /// <summary>
        /// Returns a single Log event
        /// </summary>
        /// <param name="id">Id of the log event as a string</param>
        /// <returns>A single Log event</returns>
        public LogEntry GetById(string id)
        {
            RecipesEntities db = new RecipesEntities();
            int iId;
            if(Int32.TryParse(id, out iId))
                return db.LogEntries.Find(iId);
            return null;
        }
    }
}