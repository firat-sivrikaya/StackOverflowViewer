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
    public class UserController : Controller
    {
        private readonly IUserDataService _dataService;
        public UserController(IUserDataService dataService)
        {
            _dataService = dataService;
            //Mapper.CreateMap<DomainModel.Post, Models.PostModel>();
            Mapper.Initialize( cfg => {
                //cfg.CreateMap<Source, Dest>();
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<User, UserListModel>();
            });
        }

        const int maxPageSize = 20;

        [HttpGetAttribute(Name = nameof(GetUsers))]
        public IActionResult GetUsers(int pageNumber = 1, int pageSize = 5)
        {
            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;
            var data = _dataService.GetUsers(pageNumber, pageSize);
            var result = Mapper.Map<IEnumerable<UserListModel>>(data);

            foreach ( UserListModel p in result )
            {
                p.Url = Url.Link(nameof(GetUser), new{ p.Id });
            }

            var prevlink = pageNumber > 1
                ? Url.Link(nameof(GetUsers), new { pageNumber = pageNumber - 1, pageSize })
                : null;

            var total = _dataService.GetNumberOfUsers();

            var totalPages = (int)System.Math.Ceiling(total / (double)pageSize);

            var nextlink = pageNumber < totalPages
                ? Url.Link(nameof(GetUsers), new { pageNumber = pageNumber + 1, pageSize })
                : null;

            var curlink = Url.Link(nameof(GetUsers), new { pageNumber, pageSize });

            

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

        [HttpGet("{id}", Name = nameof(GetUser))]
        public IActionResult GetUser(int id)
        {
            var user = _dataService.GetUser(id);

            if (user == null) return NotFound();

            var model = Mapper.Map<UserModel>(user);
            
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
        }*/





    }
}
