using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace ProjecIntegration.Api.Models.Validator
{
    public class AddCommandValidator: AbstractValidator<AddCommandDto>
    {
        public AddCommandValidator() {
           
        }
    }
}
