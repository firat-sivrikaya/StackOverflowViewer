using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface IMyDataService
        {
            //IList<Category> GetCategories();
            IList<Post> GetPost(int pageNumber, int pageSize);
            Post GetPost(int id);
            void CreatePost(Post post);
            void UpdatePost(Post post);
            void DeletePost(Post post);
            int GetNumberOfPost();
    }
 }