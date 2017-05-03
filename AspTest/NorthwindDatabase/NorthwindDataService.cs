using System;
using System.Collections.Generic;
using DomainModel;
using DataAccessLayer;

using System.Linq;

namespace NorthwindDatabase
{
    public class NorthwindDataService : IDataService
    {
        public IList<Category> GetCategories()
        {
            using (var context = new NorthwindContex() )
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategory(int id)
        {
            using (var context = new NorthwindContex() )
            {
                return context.Categories.Find(id);
            }
        }
    }
}