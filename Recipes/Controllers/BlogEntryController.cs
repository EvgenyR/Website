using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HtmlHelpers;
using Recipes.Models;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class BlogEntryController : BaseController
    {
        //
        // GET: /BlogEntry/

        readonly RecipesEntities db = new RecipesEntities();
        readonly List<BlogEntry> entries = new List<BlogEntry>();

        public PartialViewResult BlogResult()
        {
            IEnumerable<Post> posts = db.Posts.OrderBy(p => p.DateCreated);

            int curYear = posts.First().DateCreated.Year;
            int curMonth = posts.First().DateCreated.Month;

            //create first "year-level" item
            var topYear = new BlogEntry { Name = posts.First().DateCreated.Year.ToString().ToLink(string.Empty) };
            entries.Add(topYear);
            var currentYear = topYear;

            var topMonth = new BlogEntry { Name = posts.First().DateCreated.ToString("MMMM").ToLink(string.Empty), Parent = currentYear };
            currentYear.Children.Add(topMonth);
            var currentMonth = topMonth;

            foreach (var post in posts)
            {
                if(post.DateCreated.Year == curYear)
                {
                    if (post.DateCreated.Month != curMonth)
                    {
                        //create "month-level" item
                        var month = new BlogEntry { Name = post.DateCreated.ToString("MMMM").ToLink(string.Empty), Parent = currentYear };
                        currentYear.Children.Add(month);
                        currentMonth = month;

                        curMonth = post.DateCreated.Month;
                    }

                    //create "blog entry level" item
                    var blogEntry = new BlogEntry { Name = post.Title.ToLink("/Post/" + post.PostID + "/" + post.Title.ToSeoUrl() ), Parent = currentMonth };
                    currentMonth.Children.Add(blogEntry);
                }
                else
                {
                    //create "year-level" item
                    var year = new BlogEntry { Name = post.DateCreated.Year.ToString().ToLink(string.Empty) };
                    entries.Add(year);
                    currentYear = year;

                    curMonth = post.DateCreated.Month;
                    curYear = post.DateCreated.Year;
                }
            }

            BlogEntryViewModel model = new BlogEntryViewModel(entries);

            return PartialView(model);
        }
    }
}
