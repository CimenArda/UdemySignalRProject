using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _MessageService;

		public MessageController(IMessageService MessageService)
		{
			_MessageService = MessageService;
		}



		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _MessageService.TGetListAll();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _MessageService.TGetById(id);
			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{

			Message Message = new Message()
			{
				Mail = createMessageDto.Mail,
				MessageContent = createMessageDto.MessageContent,
				NameSurname = createMessageDto.NameSurname,
				Phone = createMessageDto.Phone,
				Date = DateTime.Now,
				Status = false,
				Subject = createMessageDto.Subject,

			};



			_MessageService.TAdd(Message);
			return Ok("Hakkımda kısmı başarıyla eklendi");

		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var values = _MessageService.TGetById(id);
			_MessageService.TDelete(values);
			return Ok("Hakkımda alanı silinmiştir.");
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			Message Message = new Message()
			{
				Mail=updateMessageDto.Mail,
				MessageContent=updateMessageDto.MessageContent,
				MessageID=updateMessageDto.MessageID,
				NameSurname=updateMessageDto.NameSurname,
				Phone=updateMessageDto.Phone,
				Date=DateTime.Now,
				Status=false,
				Subject=updateMessageDto.Subject,

			};
			_MessageService.TUpdate(Message);
			return Ok("Hakkımda alanı güncellendi");
		}
	}
}
