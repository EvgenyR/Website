using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Recipes.Models;
using System;

namespace HtmlHelpers
{
    public class FormsHelper
    {
        public static string[] timeperiods = new [] { "All", "Today", "Yesterday", "This Week", "Last Week", "This Month", "Last Month", "Last 30 days", "Last 60 days", "Last 90 days" };
        public static string[] paging_page_sizes = new [] { "10", "15", "20", "25", "30", "50", "100" };
        public static string[] log_levels = Enum.GetNames(typeof (LogTypeNames));

        /// <summary>
        /// Returns a list of supported time periods
        /// </summary>
        public static IEnumerable<SelectListItem> CommonTimePeriods
        {
            get
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string item in timeperiods) { dict.Add(item, item); }
                List<SelectListItem> list = dict.Select(o => new SelectListItem { Text = o.Value, Value = o.Key }).ToList();
                return list;
            }
        }

        /// <summary>
        /// Returns the list of supported log levels
        /// </summary>
        public static IEnumerable<SelectListItem> LogLevels
        {
            get
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string item in log_levels) { dict.Add(item, item); }
                List<SelectListItem> list = dict.Select(o => new SelectListItem { Text = o.Value, Value = o.Key }).ToList();
                return list;
            }
        }

        /// <summary>
        /// Returns the list of supported page sizes
        /// </summary>
        public static IEnumerable<SelectListItem> PagingPageSizes
        {
            get
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string item in paging_page_sizes) { dict.Add(item, item); }
                List<SelectListItem> list = dict.Select(o => new SelectListItem { Text = o.Value, Value = o.Key }).ToList();
                return list;
            }
        }
    }
}