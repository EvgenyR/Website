
using System.Collections.Generic;
using HtmlHelpers;
namespace Recipes.ViewModels
{
    public class BlogEntryViewModel
    {
        public List<BlogEntry> BlogEntries { get; set; }

        public BlogEntryViewModel(List<BlogEntry> blogEntries)
        {
            BlogEntries = blogEntries;
        }

        public BlogEntryViewModel()
        {

        }
    }
}