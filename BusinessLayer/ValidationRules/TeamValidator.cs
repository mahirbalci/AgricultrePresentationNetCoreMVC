using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator:AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("İsim Boş Geçilmez");
            RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("50 karakterden fazla giriş yapamazsınız");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev Kısmı Boş Geçilmez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Yolu  Boş Geçilmez");
        }
    }
}
