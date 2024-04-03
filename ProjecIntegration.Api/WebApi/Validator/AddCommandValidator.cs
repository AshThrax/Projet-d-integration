using FluentValidation;
using WebApi.Application.DTO;

namespace WebApi.Validator
{
    public class AddCommandValidator : AbstractValidator<AddCommandDto>
    {
        public AddCommandValidator()
        {

        }
    }
}
