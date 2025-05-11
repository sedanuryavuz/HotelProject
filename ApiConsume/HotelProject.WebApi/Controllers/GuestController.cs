using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }
        [HttpGet] //Direkt olarak verileri getirir.
        public IActionResult GuestList()
        {
            var values = _guestService.TGetList();
            return Ok(values);
        }
        [HttpPost] //Veri eklemek için kullanılır.
        public IActionResult AddGuest(Guest guest)
        {
            _guestService.TInsert(guest);
            return Ok();
        }
        [HttpDelete("{id}")] //Veri silmek için kullanılır.
        public IActionResult DeleteGuest(int id)
        {
            var value = _guestService.TGetById(id);
            _guestService.TDelete(value);
            return Ok();
        }
        [HttpPut] //Veri güncellemek için kullanılır.
        public IActionResult UpdateGuest(Guest guest)
        {
            _guestService.TUpdate(guest);
            return Ok();
        }
        [HttpGet("{id}")] //Belirli bir id'ye göre veri almak için kullanılır. {ID'yi dışarıdan alır.}
        public IActionResult GetGuest(int id)
        {
            var values = _guestService.TGetById(id);
            return Ok(values);
        }
    }
}
