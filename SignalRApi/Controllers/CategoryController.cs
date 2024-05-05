using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _CategoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_CategoryService.TGetListAll());
            return Ok(values);
        }




        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
          var value = _CategoryService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {

            _CategoryService.TAdd(new Category()
            {
                Name= createCategoryDto.Name,
                Status= true
            });
           
            return Ok("Category kısmı başarıyla eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var values = _CategoryService.TGetById(id);
            _CategoryService.TDelete(values);
            return Ok("Category alanı silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _CategoryService.TUpdate(new Category()
            {
                Name = updateCategoryDto.Name,
                Status = updateCategoryDto.Status,
                ID= updateCategoryDto.ID
            });
            return Ok("Category alanı güncellendi");
        }





        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
           return Ok(_CategoryService.TCategoryCount());
        }


		[HttpGet("ActiveCategoryCount")]

		public IActionResult ActiveCategoryCount()
        {
            return Ok(_CategoryService.ActiveCategoryCount());
        }
		[HttpGet("PassiveCategoryCount")]

		public IActionResult PassiveCategoryCount()
		{
			return Ok(_CategoryService.PassiveCategoryCount());

		}

	}
}
