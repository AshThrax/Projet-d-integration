namespace WebApi.Validator.Theather
{
    public class AddComplexeValidator : AbstractValidator<AddComplexeDto>
    {
        public AddComplexeValidator()
        {
            RuleFor(x => x.Adress);
            RuleFor(x=>x.Name);
            RuleFor(x=>x.Description);
        }
    }
}
