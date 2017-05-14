using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface IPostDataService
    {
            IList<Post> GetPosts(int pageNumber, int pageSize);
            Post GetPost(int id);
            int GetNumberOfPost();
    }
 }