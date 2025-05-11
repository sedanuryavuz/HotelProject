using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;
        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }
        [HttpGet] //Direkt olarak verileri getirir.
        public IActionResult SendMessageList()
        {
            var values = _sendMessageService.TGetList();
            return Ok(values);
        }
        [HttpPost] //Veri eklemek için kullanılır.
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TInsert(sendMessage);
            return Ok();
        }
        [HttpDelete("{id}")] //Veri silmek için kullanılır.
        public IActionResult DeleteSendMessage(int id)
        {
            var value = _sendMessageService.TGetById(id);
            _sendMessageService.TDelete(value);
            return Ok();
        }
        [HttpPut] //Veri güncellemek için kullanılır.
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TUpdate(sendMessage);
            return Ok();
        }
        [HttpGet("{id}")] //Belirli bir id'ye göre veri almak için kullanılır. {ID'yi dışarıdan alır.}
        public IActionResult GetSendMessage(int id)
        {
            var values = _sendMessageService.TGetById(id);
            return Ok(values);
        }
        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            return Ok(_sendMessageService.TSendMessageCount());
        }
    }
}
