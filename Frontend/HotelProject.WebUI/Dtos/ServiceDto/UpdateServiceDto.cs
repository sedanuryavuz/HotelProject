using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    //frontend dto
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Hizmet ikon linki giriniz.")]
        public string? ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı linki giriniz.")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı 100 karakterden fazla olamaz.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı linki giriniz.")]
        [StringLength(500, ErrorMessage = "Hizmet açıklaması 500 karakterden fazla olamaz.")]
        public string? Description { get; set; }
    }
}
