using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator:AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Boş Geçilmez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Boş Geçilmez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Boş Geçilmez");
        }


    }
}
