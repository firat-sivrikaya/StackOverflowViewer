using DomainModel;
using System;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public interface ITFIDFDataService
    {
        WordIdf GetIDFOfWord(string word);
        List<WordTf> GetTFsOfWord(int wordId);
        Post GetPost(int id);
        object GetResultWithPaging<T>(IEnumerable<T> data, int pagesize, int page, int total, string route);
    }
}