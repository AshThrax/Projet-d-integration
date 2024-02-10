using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Models.Validator
{
    public class UpdtPieceValidator : AbstractValidator<UpdatePieceDto>
    {
        public UpdtPieceValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
