using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class ServiceAddViewModel
    {
        [Display(Name ="Başlık")]
        [Required(ErrorMessage ="Boş Geçilemez")]
        public string Title { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Description { get; set; }

        [Display(Name = "Resim Url")]
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Image { get; set; }
    }
}
