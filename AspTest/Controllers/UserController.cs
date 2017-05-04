using System.Linq;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;
using System.Collections.Generic;
using AutoMapper;
using DomainModel;
// to do 
namespace WebService.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMyDataService _dataService;
        public UserController(IMyDataService dataService)
        {
            _dataService = dataService;
            //Mapper.CreateMap<DomainModel.Post, Models.PostModel>();
            Mapper.Initialize( cfg => {
                //cfg.CreateMap<Source, Dest>();
                cfg.CreateMap<Post, PostListModel>();
                cfg.CreateMap<Post, PostModel>();
            });
        }

        const int maxPageSize = 20;

        [HttpGet(Name = nameof(GetPosts))]
        public IActionResult GetPosts(int pageNumber = 1, int pageSize = 5)
        {
            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;

            var data = _dataService.GetPost(pageNumber, pageSize);

            var result = Mapper.Map<IEnumerable<PostListModel>>(data);

            var prevlink = pageNumber > 1
                ? Url.Link(nameof(GetPost), new { pageNumber = pageNumber - 1, pageSize })
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

            if (post == null) return NotFound();

            var model = Mapper.Map<PostModel>(post);

            return Ok(model);
        }

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





    }
}
