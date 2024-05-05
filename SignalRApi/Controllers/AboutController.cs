using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }



        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
           var value =  _aboutService.TGetById(id);
        return Ok(value);   
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {

            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,

            };



            _aboutService.TAdd(about);
            return Ok("Hakkımda kısmı başarıyla eklendi");
          
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values =_aboutService.TGetById(id);
            _aboutService.TDelete(values);
            return Ok("Hakkımda alanı silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                ID=updateAboutDto.ID,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl,

            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda alanı güncellendi");
        }











    }
}
