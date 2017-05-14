using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface IUserDataService
        {
            IList<User> GetUsers(int pageNumber, int pageSize);
            User GetUser(int id);
            int GetNumberOfUsers();
    }
 }