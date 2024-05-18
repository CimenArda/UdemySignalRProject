using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class BookingController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7191/api/Booking");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);


				return View(value);

			}


			return View();
		}

		[HttpGet]
		public IActionResult AddBooking()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBookingDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("https://localhost:7191/api/Booking", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();


		}


		public async Task<IActionResult> DeleteBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7191/api/Booking/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}




		[HttpGet]
		public async Task<IActionResult> UpdateBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7191/api/Booking/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
				return View(value);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateBookingDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("https://localhost:7191/api/Booking", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();


		}


		
		public async Task<IActionResult> StatusApproved(int id)
		{
			var client = _httpClientFactory.CreateClient();
		 await client.GetAsync($"https://localhost:7191/api/Booking/TBookingStatusApproved/{id}");


			return RedirectToAction("Index");




		}


		public async Task<IActionResult> StatusCancelled(int id)
		{
			var client = _httpClientFactory.CreateClient();
			 await client.GetAsync($"https://localhost:7191/api/Booking/TBookingStatusCancelled/{id}");

			

			return RedirectToAction("Index");
		}
	}
}
