using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace data.Models.Validator
{ 
    public class UpdtComplexeValidator :AbstractValidator<UpdateComplexeDto>
    {
        public UpdtComplexeValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
