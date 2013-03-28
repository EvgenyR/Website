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
 
                new Label { LabelID = 21, Name = "WPF", Description = "Windows Presentation Foundation"},
                new Label { LabelID = 22, Name = "scripting", Description = "Writing Scripts"},
                new Label { LabelID = 23, Name = "UnitTesting", Description = "Unit testing"},
                new Label { LabelID = 24, Name = "VMWare", Description = "Unit testing"},
                new Label { LabelID = 25, Name = "QML", Description = "Qt Modelling Language"},
                new Label { LabelID = 26, Name = "CPP", Description = "C++"},
                new Label { LabelID = 27, Name = "Alfresco", Description = "Alfresco CMS"},
                new Label { LabelID = 28, Name = "useless", Description = "useless"},
                new Label { LabelID = 29, Name = "TFS", Description = "Team Foundation Server"},
                new Label { LabelID = 30, Name = "SVN", Description = "Subversion"},
                new Label { LabelID = 31, Name = "SQL", Description = "Structured Query Language"},
                new Label { LabelID = 32, Name = "GitHub", Description = "GitHub"},
                new Label { LabelID = 33, Name = "MVVM", Description = "Model-View-View-Model"},
                new Label { LabelID = 34, Name = "smallthings", Description = "Small things learned"},
                new Label { LabelID = 35, Name = "XML", Description = "XML"},
                new Label { LabelID = 36, Name = "EventLog", Description = "Event Log"},
                new Label { LabelID = 37, Name = "CompactFramework", Description = "Compact Framework"},
                new Label { LabelID = 38, Name = "webOS", Description = "webOS"},
                new Label { LabelID = 39, Name = "SmartCards", Description = "Smart Cards"},
                new Label { LabelID = 40, Name = "dll", Description = "Dynamic link library"},
                new Label { LabelID = 41, Name = "embedded", Description = "embedded"},
                new Label { LabelID = 42, Name = "jobSearch", Description = "Searching for a job"},
                new Label { LabelID = 43, Name = "reading", Description = "books and articles"},
            };

            labels.ForEach(b => context.Labels.Add(b));
            context.SaveChanges();
        }
    }
}