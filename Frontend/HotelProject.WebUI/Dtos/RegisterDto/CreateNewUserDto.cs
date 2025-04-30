using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Ad alanı gereklidir..")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir..")]
        public required string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı alanı gereklidir..")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Mail alanı gereklidir..")]
        public required string Mail { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir..")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar alanı gereklidir..")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor..")]
        public required string ConfirmPassword { get; set; }
    }
}
