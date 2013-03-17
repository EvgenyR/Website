using System.Collections.Generic;
using HtmlHelpers;
using Recipes.Models;

namespace Recipes.ViewModels
{
    public class LeftMenuViewModel
    {
        public List<MenuElement> elements { get; set; }
        public List<Post> posts { get; set; }
    }

    public class MenuElement
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<MenuElement> children { get; set; }
    }
}