using System.Web.Mvc;
using Recipes.Repository;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBlogRepository repository;

        //constructor chaining
        //avoid "no parameterless constructor defined for this object"
        public HomeController()
            : this(new BlogRepository())
        { }

        public HomeController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /Home/
        [MetaKeywords(Constants.Constants.MainMetaKeywords)]
        [MetaDescription(Constants.Constants.MainMetaDescription)]
        public ActionResult Index()
        {
            //Exception ex = new Exception("test");
            //Logger.WriteEntry(ex);

            var posts = repository.GetPostPage(0, 5, 1);
            var totalPosts = repository.TotalPosts(1);

            BlogViewModel model = new BlogViewModel
            {
                BlogId = 1,
                Blog = repository.GetBlogByID(1),
                Posts = posts,
                Blogs = repository.GetAllBlogs(),
                Bloggers = repository.GetAllBloggers(),
                TotalPosts = totalPosts,
            };

            return View(model);
        }

        [MetaKeywords(Constants.Constants.MainMetaKeywords)]
        [MetaDescription(Constants.Constants.MainMetaDescription)]
        public ActionResult Todo()
        {
            return View();
        }
    }
}
