using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;

        public ProductController(IProductService ProductService, IMapper mapper)
        {
            _ProductService = ProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_ProductService.TGetListAll());
            return Ok(values);
        }




        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            return Ok(value);
        }


        [HttpGet("GetProductWithCategories")]
        public IActionResult GetProductWithCategories()
        {
           var value = _mapper.Map<List<ResultProductWithCategory>>(_ProductService.GetProductWithCategories());
            return Ok(value);


        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {

            _ProductService.TAdd(new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Status = createProductDto.Status,
                CategoryID= createProductDto.CategoryID


            });

            return Ok("Product kısmı başarıyla eklendi");

        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _ProductService.TGetById(id);
            _ProductService.TDelete(values);
            return Ok("Product alanı silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _ProductService.TUpdate(new Product()
            {
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Name = updateProductDto.Name,
                Price = updateProductDto.Price,
                Status = updateProductDto.Status,
                Id = updateProductDto.Id,
                CategoryID = updateProductDto.CategoryID
                
            });
            return Ok("Product alanı güncellendi");
        }



        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_ProductService.ProductCount());
        }

		[HttpGet("ProductCountByHamburger")]

		public IActionResult ProductCountByHamburger()
		{
			return Ok(_ProductService.ProductCountByCategoryNameHamburger());
		}

		[HttpGet("ProductCountByDrink")]

		public IActionResult ProductCountByDrink()
		{
			return Ok(_ProductService.ProductCountByCategoryNameDrink());
		}


		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
        {
            return Ok(_ProductService.TProductPriceAvg());
        }

		[HttpGet("ProductNameByMinPrice")]

		public IActionResult ProductNameByMinPrice()
        {
            return Ok(_ProductService.TProductNameByMinPrice());
        }

		[HttpGet("ProductNameByMaxPrice")]

		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_ProductService.TProductNameByMaxPrice());
		}


		[HttpGet("ProductPriceByHamburger")]
		public IActionResult ProductPriceByHamburger()
        {
            return Ok(_ProductService.ProductPriceByHamburger());
        }


	}
}
