using DomainModel;
 using System;
 using System.Collections.Generic;
 
 namespace DataAccessLayer
 {
     public interface IDataService
     {
         IList<Category> GetCategories();
         Category GetCategory(int id);
     }
 }