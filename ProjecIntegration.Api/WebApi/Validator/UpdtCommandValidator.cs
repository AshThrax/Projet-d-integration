using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace data.Models.Validator
{
    public class UpdtCommandValidator : AbstractValidator<UpdateCommandDto>
    {
        public UpdtCommandValidator() 
        {
            RuleFor(x =>x.Id).NotNull();
        }   
    }
}
