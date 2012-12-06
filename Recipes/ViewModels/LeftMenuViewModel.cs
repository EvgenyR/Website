using System.Collections.Generic;
using HtmlHelpers;

namespace Recipes.ViewModels
{
    public class LeftMenuViewModel
    {
        public List<MenuElement> elements { get; set; }
    }

    public class MenuElement
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<MenuElement> children { get; set; }
    }
}