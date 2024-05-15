using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}


		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{

			Notification Notification = new Notification()
			{
				Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
				Description = createNotificationDto.Description,
				Icon = createNotificationDto.Icon,
				Status = false,
				Type = createNotificationDto.Type

			};



			_notificationService.TAdd(Notification);
			return Ok("Hakkımda kısmı başarıyla eklendi");

		}

		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var values = _notificationService.TGetById(id);
			_notificationService.TDelete(values);
			return Ok("Hakkımda alanı silinmiştir.");
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification Notification = new Notification()
			{
				Date = updateNotificationDto.Date,
				Description = updateNotificationDto.Description,
				Icon = updateNotificationDto.Icon,
				Status = updateNotificationDto.Status,
				Type = updateNotificationDto.Type,
				NotificationID = updateNotificationDto.NotificationID
					

			};
			_notificationService.TUpdate(Notification);
			return Ok("Hakkımda alanı güncellendi");
		}








		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.NotificationStatusChangeToTrue(id);
			return Ok("GÜncelleme tamam!");
		}


		[HttpGet("NotificationStatusChangeToTFalse/{id}")]
		public IActionResult NotificationStatusChangeToTFalse(int id)
		{
			_notificationService.NotificationStatusChangeToTFalse(id);
			return Ok("GÜncelleme tamam!");
		}






		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_notificationService.TGetListAll());
		}


		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}


		[HttpGet("GetAllNotificationsByFalse")]
		public IActionResult GetAllNotificationsByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationsByFalse());
		}




	}
}
