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

        readonly RecipesEntities _db = new RecipesEntities();
        List<BlogEntry> _entries = new List<BlogEntry>();

        /// <summary>
        /// Returns entries from the digital biology blog
        /// </summary>
        /// <returns>Partial view of the blog contents</returns>
        public PartialViewResult BioBlogResult()
        {
            BlogEntryViewModel model = new BlogEntryViewModel(GetBlogEntries(2));
            return PartialView(model);
        }

        /// <summary>
        /// Returns entries from the programming blog
        /// </summary>
        /// <returns>Partial view of the blog contents</returns>
        public PartialViewResult ProgBlogResult()
        {
            BlogEntryViewModel model = new BlogEntryViewModel(GetBlogEntries(1));
            return PartialView(model);
        }

        /// <summary>
        /// Selects all posts that belong to a blog. Groups the posts to create a hierarchical structure by year and month of publication
        /// The structure is then used to generate html which will be rendered in the form of an expandable tree
        /// </summary>
        /// <param name="blogID">Id of the blog to get posts from</param>
        /// <returns>A hierarchical structure of blog posts, organised by year and month</returns>
        private List<BlogEntry> GetBlogEntries(int blogID)
        {
            var results = _db.Posts.Where(p => p.BlogID == blogID).OrderBy(p => p.DateCreated).GroupByMany(p => p.DateCreated.Year, p => p.DateCreated.Month);

            _entries = new List<BlogEntry>();

            //years
            foreach (var yearPosts in results)
            {
                //create "year-level" item
                var year = new BlogEntry { Name = yearPosts.Key.ToString().ToLink(string.Empty) };
                _entries.Add(year);

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
            return _entries;
        }
    }

    public static class MyEnumerableExtensions
    {
        /// <summary>
        /// Applies grouping to the collection of elements using the selectors specified
        /// </summary>
        /// <typeparam name="TElement">Type of the element</typeparam>
        /// <param name="elements">Elements to be grouped</param>
        /// <param name="groupSelectors">Selectors, or properties to be grouped on</param>
        /// <returns></returns>
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
