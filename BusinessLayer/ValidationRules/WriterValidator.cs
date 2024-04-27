using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.writerName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.writerSurname).NotEmpty().WithMessage("Yazar Soydını Boş Geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda alanını Boş Geçemezsiniz");
            RuleFor(x => x.writerSurname).MinimumLength(2).WithMessage("Lütfen en az 2  karakter girişi yapın");
            RuleFor(x => x.writerSurname).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın");

        }
    }
}
