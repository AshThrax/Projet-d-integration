using FluentValidation;
using WebApi.Application.DTO;

namespace WebApi.Validator
{
    public class AddPieceValidator : AbstractValidator<AddPieceDto>
    {
        public AddPieceValidator()
        {
        }
    }
}
