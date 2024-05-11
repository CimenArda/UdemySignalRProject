using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

      







        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok(" Seçilen Ürünün Silme İşlemi Başarılı");
        }

        [HttpGet]
        public IActionResult GetWithTableNumber(int id)
        {
            return Ok(_basketService.GetBasketByTableNumber(id));
        }



        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketWithProducts
            {
                MenuTableID = z.MenuTableID,
                BasketID = z.BasketID,
                Count  = z.Count,
                Price = z.Price,
                ProductID = z.ProductID,
                ProductName = z.Product.Name,
                TotalPrice = z.TotalPrice
            }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();


            _basketService.TAdd(new Basket
            {
                Count = 1,
                MenuTableID = 4,
                Price = context.Products.Where(x => x.Id == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice =0,
                ProductID = createBasketDto.ProductID

            }); 
            return Ok();

        }

    }
}

