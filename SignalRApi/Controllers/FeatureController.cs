using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _FeatureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService FeatureService, IMapper mapper)
        {
            _FeatureService = FeatureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_FeatureService.TGetListAll());
            return Ok(values);
        }




        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _FeatureService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {

            _FeatureService.TAdd(new Feature()
            {
               Title1=createFeatureDto.Title1,
               Title2 =createFeatureDto.Title2,
               Title3 =createFeatureDto.Title3,
               Description1 =createFeatureDto.Description1,
               Description2 =createFeatureDto.Description2,
               Description3 = createFeatureDto.Description3


            });

            return Ok("Feature kısmı başarıyla eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var values = _FeatureService.TGetById(id);
            _FeatureService.TDelete(values);
            return Ok("Feature alanı silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _FeatureService.TUpdate(new Feature()
            {
                Title1 = updateFeatureDto.Title1,
                Title2 = updateFeatureDto.Title2,
                Title3 = updateFeatureDto.Title3,
                Description1 = updateFeatureDto.Description1,
                Description2 = updateFeatureDto.Description2,
                Description3 = updateFeatureDto.Description3,

                ID = updateFeatureDto.ID

            });
            return Ok("Feature alanı güncellendi");
        }
    }
}
