using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _TestimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService TestimonialService, IMapper mapper)
        {
            _TestimonialService = TestimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_TestimonialService.TGetListAll());
            return Ok(values);
        }




        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _TestimonialService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {

            _TestimonialService.TAdd(new Testimonial()
            {
               ImageUrl =createTestimonialDto.ImageUrl,
               Comment =createTestimonialDto.Comment,
               Name =createTestimonialDto.Name,
               Status = createTestimonialDto.Status,
               Title = createTestimonialDto.Title

               

            });

            return Ok("Testimonial kısmı başarıyla eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _TestimonialService.TGetById(id);
            _TestimonialService.TDelete(values);
            return Ok("Testimonial alanı silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _TestimonialService.TUpdate(new Testimonial()
            {
                ImageUrl = updateTestimonialDto.ImageUrl,
                Comment = updateTestimonialDto.Comment,
                Name = updateTestimonialDto.Name,
                Status = updateTestimonialDto.Status,
                Title = updateTestimonialDto.Title,
                ID = updateTestimonialDto.ID

            });
            return Ok("Testimonial alanı güncellendi");
        }


    }
}
