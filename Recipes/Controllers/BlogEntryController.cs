using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HtmlHelpers;
using Recipes.Models;
using Recipes.ViewModels;
using System;
using System.Collections;

namespace Recipes.Controllers
{
    public class BlogEntryController : BaseController
    {
        //
        // GET: /BlogEntry/

        readonly RecipesEntities db = new RecipesEntities();
        List<BlogEntry> entries = new List<BlogEntry>();

        public PartialViewResult BioBlogResult()
        {
            BlogEntryViewModel model = new BlogEntryViewModel(GetBlogEntries(2));
            return PartialView(model);
        }

        public PartialViewResult ProgBlogResult()
        {
            BlogEntryViewModel model = new BlogEntryViewModel(GetBlogEntries(1));
            return PartialView(model);
        }

        private List<BlogEntry> GetBlogEntries(int blogID)
        {
            var results = db.Posts.Where(p => p.BlogID == blogID).OrderBy(p => p.DateCreated).GroupByMany(p => p.DateCreated.Year, p => p.DateCreated.Month);

            entries = new List<BlogEntry>();

            //years
            foreach (var yearPosts in results)
            {
                //create "year-level" item
                var year = new BlogEntry { Name = yearPosts.Key.ToString().ToLink(string.Empty) };
                entries.Add(year);

                //months
                foreach (var monthPosts in yearPosts.SubGroups)
                {
                    var month = new BlogEntry { Name = new DateTime(2000, (int)monthPosts.Key, 1).ToString("MMMM").ToLink(string.Empty), Parent = year };
                    year.Children.Add(month);

                    foreach (var postEntry in monthPosts.Items)
                    {
                        //create "blog entry level" item
                        var post = postEntry as Post;
                        var blogEntry = new BlogEntry { Name = post.Title.ToLink("/Post/" + post.PostID + "/" + post.Title.ToSeoUrl()), Parent = month };
                        month.Children.Add(blogEntry);
                    }
                }
            }
            return entries;
        }
    }

    public static class MyEnumerableExtensions
    {
        public static IEnumerable<GroupResult> GroupByMany<TElement>(
            this IEnumerable<TElement> elements,
            params Func<TElement, object>[] groupSelectors)
        {
            if (groupSelectors.Length > 0)
            {
                var selector = groupSelectors.First();

                //reduce the list recursively until zero
                var nextSelectors = groupSelectors.Skip(1).ToArray();
                return
                    elements.GroupBy(selector).Select(
                        g => new GroupResult
                        {
                            Key = g.Key,
                            Items = g,
                            SubGroups = g.GroupByMany(nextSelectors)
                        });
            }
            else
                return null;
        }
    }

    public class GroupResult
    {
        public object Key { get; set; }
        public IEnumerable Items { get; set; }
        public IEnumerable<GroupResult> SubGroups { get; set; }
    }
}
