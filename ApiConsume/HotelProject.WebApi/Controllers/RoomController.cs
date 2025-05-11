using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet] //Direkt olarak verileri getirir.
        public IActionResult RoomList()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }
        [HttpPost] //Veri eklemek için kullanılır.
        public IActionResult AddRoom(Room room)
        {
            _roomService.TInsert(room);
            return Ok();
        }
        [HttpDelete("{id}")] //Veri silmek için kullanılır.
        public IActionResult DeleteRoom(int id)
        {
            var value = _roomService.TGetById(id);
            _roomService.TDelete(value);
            return Ok();
        }
        [HttpPut] //Veri güncellemek için kullanılır.
        public IActionResult UpdateRoom(Room room)
        {
            _roomService.TUpdate(room);
            return Ok();
        }
        [HttpGet("{id}")] //Belirli bir id'ye göre veri almak için kullanılır. {ID'yi dışarıdan alır.}
        public IActionResult GetRoom(int id)
        {
            var values = _roomService.TGetById(id);
            return Ok(values);
        }
    }
}
