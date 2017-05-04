using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface IUserDataService
        {
            //IList<Category> GetCategories();
            IList<User> GetUsers(int pageNumber, int pageSize);
            User GetUser(int id);
            //void CreatePost(Post post);
            //void UpdatePost(Post post);
            //void DeletePost(Post post);
            int GetNumberOfUsers();
    }
 }