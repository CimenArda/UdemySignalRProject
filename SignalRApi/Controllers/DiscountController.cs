using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {

        private readonly IDiscountService _DiscountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService DiscountService, IMapper mapper)
        {
            _DiscountService = DiscountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_DiscountService.TGetListAll());
            return Ok(values);
        }




        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _DiscountService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {

            _DiscountService.TAdd(new Discount()
            {
               Amount = createDiscountDto.Amount,
               Description = createDiscountDto.Description,
               ImageUrl = createDiscountDto.ImageUrl,
               Title = createDiscountDto.Title

            });

            return Ok("Discount kısmı başarıyla eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var values = _DiscountService.TGetById(id);
            _DiscountService.TDelete(values);
            return Ok("Discount alanı silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _DiscountService.TUpdate(new Discount()
            {
              Title = updateDiscountDto.Title,
              Description = updateDiscountDto.Description,
              ImageUrl= updateDiscountDto.ImageUrl,
              Amount = updateDiscountDto.Amount,
              ID= updateDiscountDto.ID
            });
            return Ok("Discount alanı güncellendi");
        }
    }
}
