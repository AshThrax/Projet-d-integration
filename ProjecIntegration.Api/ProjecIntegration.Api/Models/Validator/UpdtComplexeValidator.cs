using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Models.Validator
{
    public class UpdtComplexeValidator :AbstractValidator<UpdateComplexeDto>
    {
        public UpdtComplexeValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
