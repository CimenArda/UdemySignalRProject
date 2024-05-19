using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDto;

namespace SignalRWebUI.Controllers
{
	public class SettingsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public SettingsController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{

			var value = await _userManager.FindByNameAsync(User.Identity.Name);

			UserEditDto userEditDto = new UserEditDto();
			userEditDto.SurName = value.Surname;
			userEditDto.Name = value.Name;
			userEditDto.UserName = value.UserName;
			userEditDto.Mail = value.Email;


			return View(userEditDto);
		}
	}
}
