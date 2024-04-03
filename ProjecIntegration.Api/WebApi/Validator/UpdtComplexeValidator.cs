using FluentValidation;
using WebApi.Application.DTO;

namespace WebApi.Validator
{
    public class UpdtComplexeValidator : AbstractValidator<UpdateComplexeDto>
    {
        public UpdtComplexeValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
