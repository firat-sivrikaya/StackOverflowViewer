using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface ITagDataService
        {
            //IList<Category> GetCategories();
            IList<Tag> GetTags(int pageNumber, int pageSize);
            
            Tag GetTag(int id);

            int GetNumberOfTags();
            // todo : get number of posts under each tag
    }
 }