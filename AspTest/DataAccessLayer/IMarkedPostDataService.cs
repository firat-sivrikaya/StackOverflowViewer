using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface IMarkedPostDataService
    {
            IList<MarkedPost> GetMarkedPosts(int pageNumber, int pageSize);
            MarkedPost GetMarkedPost(int id);
            void CreateMarkedPost(MarkedPost post);
            void UpdateMarkedPost(MarkedPost post);
            void DeleteMarkedPost(MarkedPost post);
            int GetNumberOfMarkedPost();
    }
 }