using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class GuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Personelleri Listeleme
        public async Task<IActionResult> Index() //await eklediğimiz için async Task kullandık.
        {
            var client = _httpClientFactory.CreateClient(); //bir tane istemci olustur
            var responseMessage = await client.GetAsync("http://localhost:5055/api/Guest"); //api'den verileri al (istek için kullanıyoruz)
            if (responseMessage.IsSuccessStatusCode) //istek başarılı ise
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi string'e çeviriyoruz.
                var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData); //json verisini deserialize ettik.
                return View(values); //verileri view'e gönderiyoruz.
            }
            return View();
        }
        //Yeni Personel Ekleme
        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDto createGuestDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createGuestDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5055/api/Guest", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            { 
                return View();
            }
        }
        //Personel Silme

        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5055/api/Guest/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //Personel Verilerini Güncellerken verileri otomatik olarak doldurma
        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)
        {
            var client = _httpClientFactory.CreateClient(); //istemciyi olusturduk.
            var responseMessage = await client.GetAsync($"http://localhost:5055/api/Guest/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGuestDto>(jsonData);
                return View(values);
            }
            return View();
        }
        //Personel Güncelleme
        [HttpPost]
        public async Task<IActionResult> UpdateGuest(UpdateGuestDto updateGuestDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient(); //istemciyi olusturduk.
                var jsonData = JsonConvert.SerializeObject(updateGuestDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5055/api/Guest/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            return View();
        }
    }
}
