using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

       //Personelleri Listeleme
        public async Task <IActionResult> Index() //await eklediğimiz için async Task kullandık.
        {
            var client = _httpClientFactory.CreateClient(); //bir tane istemci olustur
            var responseMessage = await client.GetAsync("http://localhost:5055/api/Staff"); //api'den verileri al (istek için kullanıyoruz)
            if (responseMessage.IsSuccessStatusCode) //istek başarılı ise
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi string'e çeviriyoruz.
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData); //json verisini deserialize ettik.
                return View(values); //verileri view'e gönderiyoruz.
            }
            return View();
        }
        //Yeni Personel Ekleme
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient(); 
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5055/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index"); 
            }
            return View();
        }
        //Personel Silme

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5055/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //Personel Verilerini Güncellerken verileri otomatik olarak doldurma
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient(); //istemciyi olusturduk.
            var responseMessage = await client.GetAsync($"http://localhost:5055/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        //Personel Güncelleme
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient(); //istemciyi olusturduk.
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("http://localhost:5055/api/Staff/",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
