using System.Collections.Generic;
using Recipes.Models;

namespace Recipes.SeedData
{
    public static class AddBlogEngineBlogData
    {
        public static void PopulateBlogs(RecipesEntities context)
        {
            var blogs = new List<Blog> {
                new Blog { BlogID = 1, BloggerID = 1, Title = "Programming Blog" },
                new Blog { BlogID = 2, BloggerID = 1, Title = "Digital Biology Blog" },
            };

            blogs.ForEach(b => context.Blogs.Add(b));
            context.SaveChanges();

            var labels = new List<Label> {
                new Label { LabelID = 1, Name = "C#", Description = "C# programming language" },
                new Label { LabelID = 2, Name = "myWork", Description = "Things I do at work" },
                new Label { LabelID = 3, Name = "programming", Description = "Same as software development" },
                new Label { LabelID = 4, Name = "PostgreSQL", Description = "PostgreSQL database management system" },
                new Label { LabelID = 5, Name = "CSS", Description = "Cascading Style Sheets" },
                new Label { LabelID = 6, Name = "jQuery", Description = "jQuery" },
                new Label { LabelID = 7, Name = "MVC", Description = "ASP.NET MVC" },
                new Label { LabelID = 8, Name = "SEO", Description = "Search Engine Optimisation" },
                new Label { LabelID = 9, Name = "Windows7", Description = "Windows 7"},
                new Label { LabelID = 10, Name = "VisualStudio", Description = "Visual Studio"},

                new Label { LabelID = 11, Name = "assignments", Description = "Uni of Manchester assignments"},
                new Label { LabelID = 12, Name = "Bioinformatics", Description = "Bioinformatics"},
                new Label { LabelID = 13, Name = "modelling", Description = "Modelling of biological processes"},
                new Label { LabelID = 14, Name = "compSysBio", Description = "Computing Systems Biology"},
                new Label { LabelID = 15, Name = "network", Description = "Biological networks"},
                new Label { LabelID = 16, Name = "COPASI", Description = "COPASI"},
                new Label { LabelID = 17, Name = "statistics", Description = "statistics"},
                new Label { LabelID = 18, Name = "EnzymeKinetics", Description = "Enzyme Kinetics"},
                new Label { LabelID = 19, Name = "BiNGO", Description = "BiNGO - a Cytoscape plugin"},
                new Label { LabelID = 20, Name = "Cytoscape", Description = "Cytoscape"},
            };

            labels.ForEach(b => context.Labels.Add(b));
            context.SaveChanges();
        }
    }
}