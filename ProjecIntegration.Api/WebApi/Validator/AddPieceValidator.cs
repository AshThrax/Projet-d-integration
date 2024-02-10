using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace data.Models.Validator
{
    public class AddPieceValidator : AbstractValidator<AddPieceDto>
    {
        public AddPieceValidator() { 
        }
    }
}
