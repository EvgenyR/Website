using System.Collections.Generic;

namespace Recipes.Models.BlogContents
{
    public static class PopulateSomeoneElse
    {
        public static void AddPosts(RecipesEntities context)
        {
            List<Post> posts = new List<Post> {
                new Post { BlogID = 2, BriefContent = BlogPosts2.content_27112011_b, RestOfContent = BlogPosts2.content_27112011_r, DateCreated = new System.DateTime(2011, 11, 27), PostID = 3, Title = "Models in Biology" },
                new Post { BlogID = 2, BriefContent = BlogPosts2.content_07122011_b, RestOfContent = BlogPosts2.content_07122011_r, DateCreated = new System.DateTime(2012, 12, 7), PostID = 4, Title = "Starting with Cytoscape" },
                new Post { BlogID = 2, BriefContent = BlogPosts2.content_25122011_b, RestOfContent = BlogPosts2.content_25122011_r, DateCreated = new System.DateTime(2011, 11, 27), PostID = 5, Title = "Network Topology" },
                new Post { BlogID = 2, BriefContent = BlogPosts2.content_25022012_b, RestOfContent = BlogPosts2.content_25022012_r, DateCreated = new System.DateTime(2011, 11, 27), PostID = 6, Title = "Adding Expression Data to the Network" },
                new Post { BlogID = 2, BriefContent = BlogPosts2.content_09012012_b, RestOfContent = BlogPosts2.content_09012012_r, DateCreated = new System.DateTime(2011, 11, 27), PostID = 7, Title = "Validating Active Modules with BiNGO" },
                new Post { BlogID = 2, BriefContent = BlogPosts2.content_23022012_b, RestOfContent = BlogPosts2.content_23022012_r, DateCreated = new System.DateTime(2011, 11, 27), PostID = 8, Title = "Building a model for the mouse response to Trypanosoma Congolense using jActiveModules and BiNGO" },
                new Post { BlogID = 2, BriefContent = BlogPosts2.content_15052012_b, RestOfContent = BlogPosts2.content_15052012_r, DateCreated = new System.DateTime(2011, 11, 27), PostID = 9, Title = "Estimating Michaelis-Menten Parameters" },
                new Post { BlogID = 2, BriefContent = BlogPosts2.content_01082012_b, RestOfContent = BlogPosts2.content_01082012_r, DateCreated = new System.DateTime(2011, 11, 27), PostID = 10, Title = "A Tutorial on Probability and Exponential Distribution" },
                new Post { BlogID = 2, BriefContent = BlogPosts2.content_04082012_b, RestOfContent = BlogPosts2.content_04082012_r, DateCreated = new System.DateTime(2011, 11, 27), PostID = 11, Title = "Statistical Inference" },
                new Post { BlogID = 2, BriefContent = BlogPosts2.content_13092012_b, RestOfContent = BlogPosts2.content_13092012_r, DateCreated = new System.DateTime(2012, 9, 13), PostID = 12, Title = "Markov Chains Monte Carlo Bayesian Inference" }
            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();
        }
    }
}