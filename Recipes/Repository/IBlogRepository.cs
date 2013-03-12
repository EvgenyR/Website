using System.Collections.Generic;
using Recipes.Models;

namespace Recipes.Repository
{
    public interface IBlogRepository
    {
        #region BlogOperations

        Blog GetBlogByID(int id);
        List<Blog> GetAllBlogs();
        List<Blog> GetBlogsByBloggerId(int id);
        void AddNewBlog(Blog blog);
        void EditExistingBlog(Blog blog);
        void DeleteExistingBlog(int id);

        #endregion

        #region BloggerOperations

        Blogger GetBloggerByID(int id);
        Blogger GetFirstBlogger();
        List<Blogger> GetAllBloggers();
        void AddNewBlogger(Blogger blogger);
        void EditExistingBlogger(Blogger blogger);
        void DeleteExistingBlogger(int id);

        #endregion

        #region PostOperations

        List<Post> GetPostsByBlogID(int id);
        Post GetPostByID(int id);
        void AddNewPost(Post post);
        void EditExistingPost(Post post);
        void DeleteExistingPost(Post post);

        List<Post> GetPostPage(int pageNo, int pageSize, int blogId);
        int TotalPosts(int blogId);

        #endregion
    }
}