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

        public PartialViewResult BlogResult()
        {
            //var results = from allPosts in db.Posts.OrderBy(p => p.DateCreated)
            //              group allPosts by allPosts.DateCreated.Year into postsByYear

            //              select new
            //              {
            //                  postsByYear.Key,
            //                  SubGroups = from yearLevelPosts in postsByYear
            //                              group yearLevelPosts by yearLevelPosts.DateCreated.Month into postsByMonth
            //                              select new
            //                              {
            //                                  postsByMonth.Key,
            //                                  SubGroups = from monthLevelPosts in postsByMonth
            //                                              group monthLevelPosts by monthLevelPosts.Title into post
            //                                              select post
            //                              }
            //              };

            //foreach (var yearPosts in results)
            //{
            //    //create "year-level" item
            //    var year = new BlogEntry { Name = yearPosts.Key.ToString().ToLink(string.Empty) };
            //    entries.Add(year);
            //    foreach (var monthPosts in yearPosts.SubGroups)
            //    {
            //        var month = new BlogEntry { Name = new DateTime(2000, (int)monthPosts.Key, 1).ToString("MMMM").ToLink(string.Empty), Parent = year };
            //        year.Children.Add(month);
            //        foreach (var postEntry in monthPosts.SubGroups)
            //        {
            //            //create "blog entry level" item
            //            var post = postEntry.First() as Post;
            //            var blogEntry = new BlogEntry { Name = post.Title.ToLink("/Post/" + post.PostID + "/" + post.Title.ToSeoUrl()), Parent = month };
            //            month.Children.Add(blogEntry);
            //        }
            //    }
            //}

            var results = db.Posts.OrderBy(p => p.DateCreated).GroupByMany(p => p.DateCreated.Year, p => p.DateCreated.Month);

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

            BlogEntryViewModel model = new BlogEntryViewModel(entries);

            return PartialView(model);
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
