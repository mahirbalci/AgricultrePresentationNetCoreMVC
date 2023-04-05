using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Boş Geçilmez")]
        public string username { get; set; }

        [Required(ErrorMessage = "Boş Geçilmez")]
        public string password { get; set; }
    }
}
