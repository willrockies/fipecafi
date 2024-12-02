using Fipecafi.Communication.Requests;
using Fipecafi.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fipecafi.Application.Usecases.Leads.Register
{
    public class RegisterLeadValidator : AbstractValidator<RequestRegisterLeadsJson>
    {
        public RegisterLeadValidator()
        {
            RuleFor(lead => lead.Nome).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
            RuleFor(lead => lead.Email).NotEmpty().EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
            RuleFor(lead => lead.Telefone).NotEmpty().WithMessage(ResourceMessagesException.PHONE_EMPTY);
            RuleFor(lead => lead.CursoId).NotEmpty().WithMessage(ResourceMessagesException.CURSOINTERESSE_EMPTY);
            
        }
    }
}
