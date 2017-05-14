using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface IMarkedPostDataService
    {
            IList<Post> GetMarkedPosts(int pageNumber, int pageSize);
            MarkedPost GetMarkedPost(int id);
            void CreatePost(MarkedPost post);
            void UpdatePost(MarkedPost post);
            void DeletePost(MarkedPost post);
            int GetNumberOfMarkedPost();
    }
 }