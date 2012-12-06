using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HtmlHelpers;
using Recipes.Models;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class LeftMenuController : BaseController
    {
        //
        // GET: /LeftMenu/

        public PartialViewResult MenuResult()
        {
            LeftMenuViewModel viewModel = new LeftMenuViewModel();
            viewModel.elements = new List<MenuElement>();

            using (RecipesEntities db = new RecipesEntities())
            {
                List<Category> cats = db.Categories.ToList();
                foreach (var category in cats)
                {
                    MenuElement element = new MenuElement() {id = category.CategoryID, name = category.CategoryName, children = new List<MenuElement>()};

                    List<SubCategory> subcats =
                        db.SubCategories.Where(s => s.CategoryID == category.CategoryID).ToList();

                    foreach (var subcat in subcats)
                    {
                        element.children.Add(new MenuElement(){id = subcat.SubCategoryID, name = subcat.SubCategoryName} );
                    }
                    viewModel.elements.Add(element);
                }
            }

            return PartialView(viewModel);
        }

    }
}
