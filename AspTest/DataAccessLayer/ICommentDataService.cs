using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface ICommentDataService
    {
            IList<Comment> GetComments(int pageNumber, int pageSize);
            Comment GetComment(int id);
            int GetNumberOfComment();
    }
 }