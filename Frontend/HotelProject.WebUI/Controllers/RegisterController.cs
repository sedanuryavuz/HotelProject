using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous] //Login olmadan erişim sağlanabilmesi için AllowAnonymous attribute'u eklenmiştir.
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task <IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = createNewUserDto.Name,
                Surname = createNewUserDto.Surname,
                UserName = createNewUserDto.Username,
                Email = createNewUserDto.Mail
            };
            var result = await _userManager.CreateAsync(appUser, createNewUserDto.Password); // kullanıcıyı oluştur
             if (result.Succeeded)
             {
                return RedirectToAction("Index", "Login"); // başarılı ise login sayfasına yönlendir
            }           
            return View();
        }
    }
}
