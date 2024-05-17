using ApplicationTheather.DTO;
using FluentValidation;

namespace WebApi.Validator
{
    public class AddPieceValidator : AbstractValidator<AddPieceDto>
    {
        public AddPieceValidator()
        {
        }
    }
}
