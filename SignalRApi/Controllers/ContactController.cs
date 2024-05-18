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

			Contact contact = new Contact()
			{
				PhoneNumber = createContactDto.PhoneNumber,
				Mail = createContactDto.Mail,
				FooterDesctiption = createContactDto.FooterDesctiption,
				Location = createContactDto.Location,

				FooterTitle = createContactDto.FooterTitle,
				OpenDays = createContactDto.OpenDays,
				OpenDaysDescription = createContactDto.OpenDaysDescription,
				OpenDaysHour = createContactDto.OpenDaysHour
			};



			_ContactService.TAdd(contact);

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

            Contact contact = new Contact()
            {
				ID = updateContactDto.ID,
				PhoneNumber = updateContactDto.PhoneNumber,
				Mail = updateContactDto.Mail,
				FooterDesctiption = updateContactDto.FooterDesctiption,
				Location = updateContactDto.Location,

				FooterTitle = updateContactDto.FooterTitle,
				OpenDays = updateContactDto.OpenDays,
				OpenDaysDescription = updateContactDto.OpenDaysDescription,
				OpenDaysHour = updateContactDto.OpenDaysHour
			};



            _ContactService.TUpdate(contact);
		
            return Ok("Contact alanı güncellendi");
        }
    }
}
