namespace WebApi.Validator.Theather
{
    public class AddCommandValidator : AbstractValidator<AddCommandDto>
    {
        public AddCommandValidator()
        {
            RuleFor(x=>x.SiegeIds).NotEmpty();
            RuleFor(x=>x.IdRepresentation).NotEmpty();
            RuleFor(x=>x.NombreDePlace).NotEmpty();
        }
    }
}
