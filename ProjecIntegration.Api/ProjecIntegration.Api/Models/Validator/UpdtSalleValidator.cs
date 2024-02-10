using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Models.Validator
{
    public class UpdtSalleValidator: AbstractValidator<UpdateSalleDeTheatreDto>
    {
        public UpdtSalleValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
