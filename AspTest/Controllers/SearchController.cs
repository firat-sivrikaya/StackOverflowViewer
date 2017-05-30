using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DataAccessLayer;
using DomainModel;
//using MySqlDatabase;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;
using AutoMapper;



namespace WebService.Controllers
{
    [Route("api/search")]
    public class SearchController : Controller
    {

        private readonly ITFIDFDataService repository;
        private int rankedPosts = 0;

        public SearchController(ITFIDFDataService repository)
        {
            this.repository = repository;
        }

        public List<string> EditSearchStatement(string statement)
        {
            statement = statement.ToLower();
            if (Char.IsPunctuation(statement[statement.Length - 1]))
                statement = statement.Substring(0, statement.Length - 1);

            return statement.Split().ToList();
        }

        public List<Post> CalculateRankPoint(string word)
        {

            List<Post> ContainingPosts = new List<Post>();

            float rankPoint;

            Post post = new Post();
            WordIdf wordIdf = repository.GetIDFOfWord(word);
            List<WordTf> wordTfs = repository.GetTFsOfWord(wordIdf.WordId);

            foreach (var wordTf in wordTfs)
            {
                rankPoint = 0;
                if (!ContainingPosts.Any(p => p.Id == wordTf.Contentid))
                {
                    List<WordTf> words = wordTfs.Where(w => w.Contentid == wordTf.Contentid).ToList();

                    foreach (var wor in words)
                    {
                       
                            rankPoint += wor.Tf * wordIdf.TotalIdf;
                        
                    }

                    post = repository.GetPost(words.First().Contentid);
                    post.rankPoint = rankPoint;
                   
                    ContainingPosts.Add(post);
                }
            }

            return ContainingPosts;
        }

        public List<Post> RankPosts(string statement, int limit, int offset)
        {
            List<string> words = EditSearchStatement(statement);
            float rankPoint = 0;
            List<Post> repetitionPosts = new List<Post>();
            List<Post> innerPosts = new List<Post>();
            List<Post> posts = new List<Post>();

            foreach (var word in words)
            {
                foreach (var p in (CalculateRankPoint(word)))
                    repetitionPosts.Add(p);

            }

            foreach (var post in repetitionPosts)
            {

                if (!posts.Any(p => p.Id == post.Id))
                {
                    rankPoint = 0;

                    innerPosts = repetitionPosts.Where(w => w.Id == post.Id).ToList();

                    foreach (var innerPos in innerPosts)
                        rankPoint += innerPos.rankPoint;

                    post.rankPoint = rankPoint;
                    posts.Add(post);
                }
            }

            //posts = posts.OrderBy(p => p.rankPoint).ToList();
            rankedPosts = posts.Count;


            //posts.Reverse();
            return posts.OrderByDescending(p => p.rankPoint).Skip(offset)
                    .Take(limit)
                    .ToList();
        }

        public int GetNumberOfRankedPosts()
        {
            return rankedPosts;
        }

        [HttpGet("{id}", Name = nameof(Search))]       
         public IActionResult Search(string statement, int page = 0, int pagesize = 10)
        {
            statement = statement.Replace("%20", " ");
            var list = RankPosts(statement, pagesize, page * pagesize).Select(p => Mapper.Map(p, Url));
            //var result = GetResultWithPaging(list, pagesize, page, total, route);
            var result = GetResultWithPaging(
               list,
               pagesize,
               page,
               GetNumberOfRankedPosts(),
               "Search");

            if (result == null)
                return NotFound();
            
            //this.repository.AddToHistory(new History(statement));
             
            return Ok(result);
        }

        public object GetResultWithPaging<T>(IEnumerable<T> data, int pagesize, int page, int total, string route)
        {
            var lastpage = total / pagesize;

            var prev = page <= 0 ? null : Url.Link(route, new { page = page - 1, pagesize });
            var next = page >= lastpage ? null : Url.Link(route, new { page = page + 1, pagesize });

            //if (postId != 0)
            //{
            //    next = page >= lastpage ? null : Url.Link(route, new {  page = page + 1, pagesize });
            //    prev = page <= 0 ? null : Url.Link(route, new { page = page - 1, pagesize });
            //}

            //if (route == Util.Util.Config.SearchRoute)
            //{
            //    next = page >= lastpage ? null : Url.Link(route, new {PostId = postId, page = page + 1, pagesize});
            //    prev = page <= 0 ? null : Url.Link(route, new  {PostId =postId, page = page - 1, pagesize});
            //}



            var result = new
            {
                Total = total,
                Prev = prev,
                Next = next,
                Data = data
            };
            return result;
        }
    }
}