using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface ITagPostDataService
        {
            //IList<Category> GetCategories();
            TagPost GetTagOfPost(int id);
            IList<TagPost> GetPostsByTag(int pageNumber, int pageSize);

            int GetNumberOfTagPosts();

    }
 }