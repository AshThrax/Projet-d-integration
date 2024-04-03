using FluentValidation;
using WebApi.Application.DTO;

namespace WebApi.Validator
{
    public class UpdtCommandValidator : AbstractValidator<UpdateCommandDto>
    {
        public UpdtCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
