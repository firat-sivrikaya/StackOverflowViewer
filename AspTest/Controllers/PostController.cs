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
    public class PostController : Controller
    {
        private readonly IPostDataService _dataService;
        //private readonly ITagPostDataService _dataService2;
        
        public PostController(IPostDataService dataService)
        {
            _dataService = dataService;
            //_dataService2 = dataService2;
            //Mapper.CreateMap<DomainModel.Post, Models.PostModel>();
            Mapper.Initialize( cfg => {
                //cfg.CreateMap<Source, Dest>();
                cfg.CreateMap<Post, PostListModel>();
                cfg.CreateMap<Post, PostModel>();
                cfg.CreateMap<Tag, TagModel>();
            });
        }

        const int maxPageSize = 20;

        [HttpGet(Name = nameof(GetPosts))]
        public IActionResult GetPosts(int pageNumber = 1, int pageSize = 5)
        {
            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;

            var data = _dataService.GetPosts(pageNumber, pageSize);

            var result = Mapper.Map<IEnumerable<PostListModel>>(data);

            foreach ( PostListModel p in result )
            {
                p.Url = Url.Link(nameof(GetPost), new{ p.Id });
            }
            
            var prevlink = pageNumber > 1
                ? Url.Link(nameof(GetPosts), new { pageNumber = pageNumber - 1, pageSize })
                : null;

            var total = _dataService.GetNumberOfPost();

            var totalPages = (int)System.Math.Ceiling(total / (double)pageSize);

            var nextlink = pageNumber < totalPages
                ? Url.Link(nameof(GetPosts), new { pageNumber = pageNumber + 1, pageSize })
                : null;

            var curlink = Url.Link(nameof(GetPosts), new { pageNumber, pageSize });

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

        [HttpGet("{id}", Name = nameof(GetPost))]
        public IActionResult GetPost(int id)
        {
            var post = _dataService.GetPost(id);
            //var tagDomain = _dataService2.GetTagOfPost(id);
            //var tag = Mapper.Map<TagModel>(tagDomain);

            if (post == null) return NotFound();

            var model = Mapper.Map<PostModel>(post);

            //model.Tag = tag;
            //model.TagUrl = Url.Link(nameof(TagController.GetTag), new { tag.Url });

            return Ok(model);
        }
        
        /* 
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostCreateOrUpdateModel model)
        {

            if (model == null) return BadRequest();

            var post = Mapper.Map<Post>(model);

            _dataService.CreatePost(post);

            return CreatedAtRoute(nameof(GetPost), new { id = post.Id }, Mapper.Map<PostModel>(post));
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] PostCreateOrUpdateModel model)
        {
            if (model == null) return BadRequest();

            var post = _dataService.GetPost(id);

            if (post == null) return NotFound();

            Mapper.Map(model, post);

            _dataService.UpdatePost(post);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _dataService.GetPost(id);

            if (post == null) return NotFound();

            _dataService.DeletePost(post);

            return NoContent();
        }

        */



    }
}
