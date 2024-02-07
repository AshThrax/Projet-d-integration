using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace data.Models.Validator
{
    public class UpdtRepresentationValidator: AbstractValidator<UpdateRepresentationDto>
    {
        public UpdtRepresentationValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
