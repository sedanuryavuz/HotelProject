using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _OurRoomsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OurRoomsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); //bir tane istemci olustur
            var responseMessage = await client.GetAsync("http://localhost:5055/api/Room"); //api'den verileri al (istek için kullanıyoruz)
            if (responseMessage.IsSuccessStatusCode) //istek başarılı ise
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi string'e çeviriyoruz.
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData); //json verisini deserialize ettik.
                return View(values); //verileri view'e gönderiyoruz.
            }
            return View();
        }
    }
}
