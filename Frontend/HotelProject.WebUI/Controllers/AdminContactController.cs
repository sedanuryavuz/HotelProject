using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox() //await eklediğimiz için async Task kullandık.
        {
            var client = _httpClientFactory.CreateClient(); //bir tane istemci olustur
            var responseMessage = await client.GetAsync("http://localhost:5055/api/Contact"); //api'den verileri al (istek için kullanıyoruz)

            var client2 = _httpClientFactory.CreateClient(); //bir tane istemci olustur
            var responseMessage2 = await client2.GetAsync("http://localhost:5055/api/Contact/GetContactCount"); //api'den verileri al (istek için kullanıyoruz)

            var client3 = _httpClientFactory.CreateClient(); //bir tane istemci olustur
            var responseMessage3 = await client3.GetAsync("http://localhost:5055/api/Contact/GetSendMessageCount"); //api'den verileri al (istek için kullanıyoruz)

            if (responseMessage.IsSuccessStatusCode) //istek başarılı ise
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi string'e çeviriyoruz.
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData); //json verisini deserialize ettik.
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync(); //gelen veriyi string'e çeviriyoruz.
                ViewBag.contactCount = jsonData2;

                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync(); //gelen veriyi string'e çeviriyoruz.
                ViewBag.sendMessageCount = jsonData3;
                return View(values); //verileri view'e gönderiyoruz.
            }
            return View();
        }

        public async Task<IActionResult> Sendbox() //await eklediğimiz için async Task kullandık.
        {
            var client = _httpClientFactory.CreateClient(); //bir tane istemci olustur
            var responseMessage = await client.GetAsync("http://localhost:5055/api/SendMessage"); //api'den verileri al (istek için kullanıyoruz)
            if (responseMessage.IsSuccessStatusCode) //istek başarılı ise
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi string'e çeviriyoruz.
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData); //json verisini deserialize ettik.
                return View(values); //verileri view'e gönderiyoruz.
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessage createSendMessage)
        {
            createSendMessage.SenderMail= "admin@gmail.com";
            createSendMessage.SenderName= "admin";
            createSendMessage.Date= DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5055/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }
        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        public async Task <IActionResult> MessageDetailsBySendbox(int id) 
        {
            var client = _httpClientFactory.CreateClient(); //istemciyi olusturduk.
            var responseMessage = await client.GetAsync($"http://localhost:5055/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task <IActionResult> MessageDetailsByInbox(int id) 
        {
            var client = _httpClientFactory.CreateClient(); //istemciyi olusturduk.
            var responseMessage = await client.GetAsync($"http://localhost:5055/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }
            return View();
        }
   

    }
}
