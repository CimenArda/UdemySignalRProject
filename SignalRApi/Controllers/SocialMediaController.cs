using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _SocialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService SocialMediaService, IMapper mapper)
        {
            _SocialMediaService = SocialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_SocialMediaService.TGetListAll());
            return Ok(values);
        }




        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {

            _SocialMediaService.TAdd(new SocialMedia()
            {
                Title = createSocialMediaDto.Title,
                Icon =createSocialMediaDto.Icon,
                Url = createSocialMediaDto.Url


            });

            return Ok("SocialMedia kısmı başarıyla eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _SocialMediaService.TGetById(id);
            _SocialMediaService.TDelete(values);
            return Ok("SocialMedia alanı silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _SocialMediaService.TUpdate(new SocialMedia()
            {
                Title = updateSocialMediaDto.Title,
                Icon = updateSocialMediaDto.Icon,
                Url = updateSocialMediaDto.Url,
                ID=updateSocialMediaDto.ID

            });
            return Ok("SocialMedia alanı güncellendi");
        }
    }
}
