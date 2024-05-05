using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _ContactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService ContactService, IMapper mapper)
        {
            _ContactService = ContactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_ContactService.TGetListAll());
            return Ok(values);
        }




        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _ContactService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {

            _ContactService.TAdd(new Contact()
            {
               Location = createContactDto.Location,
               FooterDesctiption = createContactDto.FooterDesctiption,
               Mail = createContactDto.Mail,
               PhoneNumber = createContactDto.PhoneNumber
            });

            return Ok("Contact kısmı başarıyla eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var values = _ContactService.TGetById(id);
            _ContactService.TDelete(values);
            return Ok("Contact alanı silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _ContactService.TUpdate(new Contact()
            {
               PhoneNumber = updateContactDto.PhoneNumber,
               Mail = updateContactDto.Mail,
               FooterDesctiption= updateContactDto.FooterDesctiption,
               Location = updateContactDto.Location,
               ID = updateContactDto.ID
            });
            return Ok("Contact alanı güncellendi");
        }
    }
}
