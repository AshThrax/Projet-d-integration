using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Models.Validator
{
    public class AddPieceValidator : AbstractValidator<AddPieceDto>
    {
        public AddPieceValidator() { 
        }
    }
}
