using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace data.Models.Validator
{
    public class UpdtPieceValidator : AbstractValidator<UpdatePieceDto>
    {
        public UpdtPieceValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
