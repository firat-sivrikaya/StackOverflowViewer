using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface IHistoryDataService
    {
            IList<History> GetHistory(int pageNumber, int pageSize);
            History GetHistory(int id);
            void CreateHistory(History post);
            void DeleteHistory(History post);
            int GetNumberOfHistory();
    }
 }