using Recipes.Models;
using Recipes.Paging;

namespace Recipes.ViewModels
{
    public class LoggingIndexModel
    {
        public IPagedList<LogEntry> LogEvents { get; set; }

        public string LogLevel { get; set; }
        public string Period { get; set; }

        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }

        public LoggingIndexModel()
        {
            CurrentPageIndex = 0;
            PageSize = 20;
        }
    }
}