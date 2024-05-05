using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {


        private readonly IBookingService _BookingService;

        public BookingController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }



        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _BookingService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _BookingService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {

            Booking Booking = new Booking()
            {
                  Mail = createBookingDto.Mail,
                  Name=createBookingDto.Name,
                  Date = createBookingDto.Date,
                  PersonCount = createBookingDto.PersonCount,
                  Phone = createBookingDto.Phone
            };
            _BookingService.TAdd(Booking);
            return Ok("Booking kısmı başarıyla eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _BookingService.TGetById(id);
            _BookingService.TDelete(values);
            return Ok("Booking alanı silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking Booking = new Booking()
            {
              ID = updateBookingDto.ID,
              Name = updateBookingDto.Name,
              Date = updateBookingDto.Date,
              PersonCount = updateBookingDto.PersonCount,
              Phone = updateBookingDto.Phone,
              Mail= updateBookingDto.Mail




            };
            _BookingService.TUpdate(Booking);
            return Ok("Booking alanı güncellendi");
        }

    }
}
