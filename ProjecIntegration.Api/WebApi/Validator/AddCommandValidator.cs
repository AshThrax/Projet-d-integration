using FluentValidation;
using ProjecIntegration.Api.Application.DTO;

namespace data.Models.Validator
{
    public class AddCommandValidator: AbstractValidator<AddCommandDto>
    {
        public AddCommandValidator() {
           
        }
    }
}
