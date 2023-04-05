using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Boş Geçilmez")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Boş Geçilmez")]
        public string mail { get; set; }

        [Required(ErrorMessage = "Boş Geçilmez")]
        public string password { get; set; }

        [Required(ErrorMessage = "Boş Geçilmez")]
        [Compare("password",ErrorMessage ="Şifreler uyumlu değil")]
        public string passwordConfirm { get; set; }



    }
}
