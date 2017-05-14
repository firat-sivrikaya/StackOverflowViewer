using System.Linq;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;
using System.Collections.Generic;
using AutoMapper;
using DomainModel;
namespace WebService.Controllers
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        private readonly ITagDataService _dataService;
        //private readonly ITagPostDataService _dataService2;
        public TagController(ITagDataService dataService)
        {
            _dataService = dataService;
            //_dataService2 = dataService2;
            //Mapper.CreateMap<DomainModel.Post, Models.PostModel>();
            Mapper.Initialize( cfg => {
                //cfg.CreateMap<Source, Dest>();
                cfg.CreateMap<Tag, TagModel>();
                cfg.CreateMap<Tag, TagListModel>();
                cfg.CreateMap<TagPost, TagPostModel>();
                cfg.CreateMap<TagPost, TagPostListModel>();
            });
        }

        const int maxPageSize = 20;

        [HttpGetAttribute(Name = nameof(GetTags))]
        public IActionResult GetTags(int pageNumber = 1, int pageSize = 5)
        {
            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;
            var data = _dataService.GetTags(pageNumber, pageSize);
            var result = Mapper.Map<IEnumerable<TagListModel>>(data);

            foreach ( TagListModel p in result )
            {
                p.Url = Url.Link(nameof(GetTag), new{ p.Id });
            }

            var prevlink = pageNumber > 1
                ? Url.Link(nameof(GetTags), new { pageNumber = pageNumber - 1, pageSize })
                : null;

            var total = _dataService.GetNumberOfTags();

            var totalPages = (int)System.Math.Ceiling(total / (double)pageSize);

            var nextlink = pageNumber < totalPages
                ? Url.Link(nameof(GetTags), new { pageNumber = pageNumber + 1, pageSize })
                : null;

            var curlink = Url.Link(nameof(GetTags), new { pageNumber, pageSize });

            

            var linkedResult = new
            {
                Result = result,
                Links = new List<object>
                {
                    new { name = "prev", url = prevlink },
                    new { name = "next", url = nextlink },
                    new { name = "cur", url = curlink }
                }
            };

            return Ok(linkedResult);

        }

        [HttpGet("{id}", Name = nameof(GetTag))]
        public IActionResult GetTag(int id)
        {
            var user = _dataService.GetTag(id);

            if (user == null) return NotFound();

            var model = Mapper.Map<TagModel>(user);
            
            return Ok(model);
        }    

        // mindfuck: return posts under each tag
        /* 
        public IActionResult GetPostsByTag(int pageNumber = 1, int pageSize = 5)
        {
            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;
            var data = _dataService.GetTags(pageNumber, pageSize);
            var result = Mapper.Map<IEnumerable<TagPostListModel>>(data);

            foreach ( TagPostListModel p in result )
            {
                p.Url = Url.Link(nameof(GetTag), new{ p.PostId });
            }

            var prevlink = pageNumber > 1
                ? Url.Link(nameof(GetTags), new { pageNumber = pageNumber - 1, pageSize })
                : null;

            //var total = _dataService2.GetNumberOfTagPosts();

            var totalPages = (int)System.Math.Ceiling(total / (double)pageSize);

            var nextlink = pageNumber < totalPages
                ? Url.Link(nameof(GetTags), new { pageNumber = pageNumber + 1, pageSize })
                : null;

            var curlink = Url.Link(nameof(GetTags), new { pageNumber, pageSize });

            

            var linkedResult = new
            {
                Result = result,
                Links = new List<object>
                {
                    new { name = "prev", url = prevlink },
                    new { name = "next", url = nextlink },
                    new { name = "cur", url = curlink }
                }
            };

            return Ok(linkedResult);

        }*/

    }
}
