using System;

namespace Recipes.Controllers
{
    public class MetaDescriptionAttribute : Attribute
    {
        private readonly string _parameter;

        public MetaDescriptionAttribute(string parameter)
        {
            _parameter = parameter;
        }

        public string Parameter { get { return _parameter; } }
    }
}
