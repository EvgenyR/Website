using System.Collections.Generic;
using System.Web.Mvc;
using Recipes.Models;
using Recipes.Repository;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class LeftMenuController : BaseController
    {
        //
        // GET: /LeftMenu/

        private readonly IRecipesRepository repository;

        //constructor chaining
        //avoid "no parameterless constructor defined for this object"
        public LeftMenuController()
            : this(new RecipesRepository())
        { }

        public LeftMenuController(IRecipesRepository repository)
        {
            this.repository = repository;
        }


        public PartialViewResult MenuResult()
        {
            BlogRepository blogRepository = new BlogRepository();
            List<Post> menuPosts = blogRepository.GetPostPage(0, 5, 1);

            LeftMenuViewModel viewModel = new LeftMenuViewModel();
            viewModel.elements = new List<MenuElement>();

            List<Category> cats = repository.GetAllCategories();
            foreach (var category in cats)
            {
                MenuElement element = new MenuElement() {id = category.CategoryID, name = category.CategoryName, children = new List<MenuElement>()};

                List<SubCategory> subcats = repository.GetSubCategoriesByCategoryId(category.CategoryID);

                foreach (var subcat in subcats)
                {
                    element.children.Add(new MenuElement(){id = subcat.SubCategoryID, name = subcat.SubCategoryName} );
                }
                viewModel.elements.Add(element);
            }

            viewModel.posts = menuPosts;

            return PartialView(viewModel);
        }

    }
}
