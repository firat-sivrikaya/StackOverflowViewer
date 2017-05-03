using System.Linq;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;
using AutoMapper;
using System.Collections.Generic;
using DomainModel;
/* 
namespace AspTest.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly IDataService _dataService;

        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }

        const int maxPageSize = 20;

        [HttpGet(Name = nameof(GetCategories))]
        public IActionResult GetCategories(int pageNumber = 1, int pageSize = 5)
        {
            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;

            var data = _dataService.GetCategories(pageNumber, pageSize);

            var result = Mapper.Map<IEnumerable<CategoryListModel>>(data);

            var prevlink = pageNumber > 1
                ? Url.Link(nameof(GetCategories), new { pageNumber = pageNumber - 1, pageSize })
                : null;

            var total = _dataService.GetNumberOfCategories();

            var totalPages = (int)System.Math.Ceiling(total / (double)pageSize);

            var nextlink = pageNumber < totalPages
                ? Url.Link(nameof(GetCategories), new { pageNumber = pageNumber + 1, pageSize })
                : null;

            var curlink = Url.Link(nameof(GetCategories), new { pageNumber, pageSize });

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

        [HttpGet("{id}", Name = nameof(GetCategory))]
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);

            if (category == null) return NotFound();

            var model = Mapper.Map<CategoryModel>(category);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryCreateOrUpdateModel model)
        {
            
            if (model == null) return BadRequest();

            var category = Mapper.Map<Category>(model);

            _dataService.CreateCategory(category);

            return CreatedAtRoute(nameof(GetCategory), new { id = category.Id }, Mapper.Map<CategoryModel>(category));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryCreateOrUpdateModel model)
        {
            if (model == null) return BadRequest();

            var category = _dataService.GetCategory(id);

            if (category == null) return NotFound();

            Mapper.Map(model, category);

            _dataService.UpdateCategory(category);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _dataService.GetCategory(id);

            if (category == null) return NotFound();

            _dataService.DeleteCategory(category);

            return NoContent();
        }





    }
}
*/