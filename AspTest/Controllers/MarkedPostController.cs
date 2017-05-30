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
    public class MarkedPostController : Controller
    {
        private readonly IMarkedPostDataService _dataService;
        private readonly IPostDataService _dataService2;
        public MarkedPostController(IMarkedPostDataService dataService, IPostDataService dataService2)
        {
            _dataService = dataService;
            _dataService2 = dataService2;
            //Mapper.CreateMap<DomainModel.Post, Models.PostModel>();
            Mapper.Initialize( cfg => {
                //cfg.CreateMap<Source, Dest>();
                cfg.CreateMap<MarkedPost, MarkedPostListModel>();
                cfg.CreateMap<MarkedPost, MarkedPostModel>();
                cfg.CreateMap<MarkedPostCreateOrUpdateModel, MarkedPost>(); 
            });
        }

        const int maxPageSize = 20;

        [HttpGet(Name = nameof(GetMarkedPosts))]
        public IActionResult GetMarkedPosts(int pageNumber = 1, int pageSize = 5)
        {
            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;

            var data = _dataService.GetMarkedPosts(pageNumber, pageSize);

            var result = Mapper.Map<IEnumerable<MarkedPostListModel>>(data);

            foreach ( MarkedPostListModel p in result )
            {
                p.Url = Url.Link(nameof(IPostDataService.GetPost), new{ p.Id });
                p.PostTitle = _dataService2.GetPost(p.Id).Title;
            }
            
            var prevlink = pageNumber > 1
                ? Url.Link(nameof(GetMarkedPosts), new { pageNumber = pageNumber - 1, pageSize })
                : null;

            var total = _dataService.GetNumberOfMarkedPost();

            var totalPages = (int)System.Math.Ceiling(total / (double)pageSize);

            var nextlink = pageNumber < totalPages
                ? Url.Link(nameof(GetMarkedPosts), new { pageNumber = pageNumber + 1, pageSize })
                : null;

            var curlink = Url.Link(nameof(GetMarkedPosts), new { pageNumber, pageSize });

            var linkedResult = new
            {
                Result = result,
                Links = new List<object>
                {
                    new { name = "prev", url = prevlink },
                    new { name = "next", url = nextlink },
                    new { name = "cur", url = curlink }
                },
                TotalMarked = total
            };

            return Ok(linkedResult);
        }

        [HttpGet("{id}", Name = nameof(GetMarkedPost))]
        public IActionResult GetMarkedPost(int id)
        {
            var post = _dataService.GetMarkedPost(id);

            if (post == null) return NotFound();

            var model = Mapper.Map<MarkedPostModel>(post);

            return Ok(model);
        }
        
         
        [HttpPost]
        public IActionResult CreateMarkedPost([FromBody] MarkedPostCreateOrUpdateModel model)
        {

            if (model == null) return BadRequest();

            var post = Mapper.Map<MarkedPost>(model);

            _dataService.CreateMarkedPost(post);

            return CreatedAtRoute(nameof(GetMarkedPost), new { id = post.Id, notes = post.Notes }, Mapper.Map<MarkedPostModel>(post));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMarkedPost(int id, [FromBody] MarkedPostCreateOrUpdateModel model)
        {
            if (model == null) return BadRequest();

            var post = _dataService.GetMarkedPost(id);

            if (post == null) return NotFound();

            Mapper.Map(model, post);

            _dataService.UpdateMarkedPost(post);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMarkedPost(int id)
        {
            var post = _dataService.GetMarkedPost(id);

            if (post == null) return NotFound();

            _dataService.DeleteMarkedPost(post);

            return NoContent();
        }

        



    }
}
