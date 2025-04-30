using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet] //Direkt olarak verileri getirir.
        public IActionResult aboutList()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }
        [HttpPost] //Veri eklemek için kullanılır.
        public IActionResult Addabout(About about)
        {
            _aboutService.TInsert(about);
            return Ok();
        }
        [HttpDelete] //Veri silmek için kullanılır.
        public IActionResult Deleteabout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok();
        }
        [HttpPut] //Veri güncellemek için kullanılır.
        public IActionResult Updateabout(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }
        [HttpGet("{id}")] //Belirli bir id'ye göre veri almak için kullanılır. {ID'yi dışarıdan alır.}
        public IActionResult Getabout(int id)
        {
            var values = _aboutService.TGetById(id);
            return Ok(values);
        }
    }
}
