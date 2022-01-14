using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {        
        RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz");               
        RuleFor(x => x. Subject).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz");
        RuleFor(x => x. MessageContent).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz");                     
        RuleFor(x => x. Subject).MinimumLength(2).WithMessage("Konu kısmına en az 2 karakter girişi yapmalısınız");        
        }
    }
}
