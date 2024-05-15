using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;

		public MenuTableController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}

		[HttpGet("menutableCount")]
		public IActionResult menutableCount()
		{
			return Ok(_menuTableService.TmenutableCount());
		}
        [HttpGet("MenuTableList")]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {

            MenuTable MenuTable = new MenuTable()
            {
              Name = createMenuTableDto.Name,
              Status = false

            };



            _menuTableService.TAdd(MenuTable);
            return Ok("Hakkımda kısmı başarıyla eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var values = _menuTableService.TGetById(id);
            _menuTableService.TDelete(values);
            return Ok("Hakkımda alanı silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable MenuTable = new MenuTable()
            {
               Status = false,
               Name = updateMenuTableDto.Name,
               MenuTableID = updateMenuTableDto.MenuTableID
            };
            _menuTableService.TUpdate(MenuTable);
            return Ok("Hakkımda alanı güncellendi");
        }

    }
}
