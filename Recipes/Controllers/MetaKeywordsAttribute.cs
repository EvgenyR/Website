using System;

namespace Recipes.Controllers
{
    public class MetaKeywordsAttribute : Attribute
    {
        private readonly string _parameter;

        public MetaKeywordsAttribute(string parameter)
        {
            _parameter = parameter;
        }

        public string Parameter { get { return _parameter; } }
    }
}
