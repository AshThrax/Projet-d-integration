using FluentValidation;
using WebApi.Application.DTO;

namespace WebApi.Validator
{
    public class AddRepresentationValidator : AbstractValidator<AddRepresentationDto>
    {
        public AddRepresentationValidator()
        {
        }
    }
}
