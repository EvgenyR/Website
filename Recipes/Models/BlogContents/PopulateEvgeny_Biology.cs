using System;
using System.Collections.Generic;

namespace Recipes.Models.BlogContents
{
    public static class PopulateEvgeny_Biology
    {
        public static void AddPosts(RecipesEntities context)
        {
            var posts = new List<Post> {
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_27112011_b, RestOfContent = BlogPostsBiology.content_27112011_r, Keywords = BlogPostsBiology.content_27112011_k, Description = BlogPostsBiology.content_27112011_d, DateCreated = new DateTime(2011, 11, 27), PostID = 3, Title = "Models in Biology" },
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_07122011_b, RestOfContent = BlogPostsBiology.content_07122011_r, Keywords = BlogPostsBiology.content_07122011_k, Description = BlogPostsBiology.content_07122011_d, DateCreated = new DateTime(2011, 12, 7), PostID = 4, Title = "Starting with Cytoscape" },
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_25122011_b, RestOfContent = BlogPostsBiology.content_25122011_r, Keywords = BlogPostsBiology.content_25122011_k, Description = BlogPostsBiology.content_25122011_d, DateCreated = new DateTime(2011, 12, 25), PostID = 5, Title = "Network Topology" },
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_25022012_b, RestOfContent = BlogPostsBiology.content_25022012_r, Keywords = BlogPostsBiology.content_25022012_k, Description = BlogPostsBiology.content_25022012_d, DateCreated = new DateTime(2012, 2, 25), PostID = 6, Title = "Adding Expression Data to the Network" },
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_09012012_b, RestOfContent = BlogPostsBiology.content_09012012_r, Keywords = BlogPostsBiology.content_09012012_k, Description = BlogPostsBiology.content_09012012_d, DateCreated = new DateTime(2012, 1, 9), PostID = 7, Title = "Validating Active Modules with BiNGO" },
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_23022012_b, RestOfContent = BlogPostsBiology.content_23022012_r, Keywords = BlogPostsBiology.content_23022012_k, Description = BlogPostsBiology.content_23022012_d, DateCreated = new DateTime(2012, 2, 23), PostID = 8, Title = "Building a model for the mouse response to Trypanosoma Congolense using jActiveModules and BiNGO" },
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_15052012_b, RestOfContent = BlogPostsBiology.content_15052012_r, Keywords = BlogPostsBiology.content_15052012_k, Description = BlogPostsBiology.content_15052012_d, DateCreated = new DateTime(2012, 5, 15), PostID = 9, Title = "Estimating Michaelis-Menten Parameters" },
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_01082012_b, RestOfContent = BlogPostsBiology.content_01082012_r, DateCreated = new DateTime(2011, 8, 1), PostID = 10, Title = "A Tutorial on Probability and Exponential Distribution" },
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_04082012_b, RestOfContent = BlogPostsBiology.content_04082012_r, DateCreated = new DateTime(2011, 11, 27), PostID = 11, Title = "Statistical Inference" },
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_13092012_b, RestOfContent = BlogPostsBiology.content_13092012_r, DateCreated = new DateTime(2012, 9, 13), PostID = 12, Title = "Markov Chains Monte Carlo Bayesian Inference" },
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_27112012_b, RestOfContent = BlogPostsBiology.content_27112012_r, Keywords = BlogPostsBiology.content_27112012_k, Description = BlogPostsBiology.content_27112012_d, DateCreated = new DateTime(2012, 11, 27), PostID = 13, Title = "COPASI and CellDesigner: Comparison"},
                new Post { BlogID = 2, BriefContent = BlogPostsBiology.content_29102012_b, RestOfContent = BlogPostsBiology.content_29102012_r, Keywords = BlogPostsBiology.content_29102012_k, Description = BlogPostsBiology.content_29102012_d, DateCreated = new DateTime(2012, 10, 29), PostID = 14, Title = "Calculation of Phase Space Models with COPASI"},
            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();
        }
    }
}