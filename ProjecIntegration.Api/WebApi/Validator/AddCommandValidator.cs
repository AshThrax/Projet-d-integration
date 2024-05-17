using ApplicationTheather.DTO;
using FluentValidation;

namespace WebApi.Validator
{
    public class AddCommandValidator : AbstractValidator<AddCommandDto>
    {
        public AddCommandValidator()
        {

        }
    }
}
