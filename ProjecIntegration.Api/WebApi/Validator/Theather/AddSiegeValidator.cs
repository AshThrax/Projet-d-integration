namespace WebApi.Validator.Theather
{
    public class AddSiegeValidator : AbstractValidator<AddSiegeDto>
    {
        public AddSiegeValidator() 
        {
            RuleFor(x=>x.SalleId).NotEmpty();
            RuleFor(x=>x.Name).NotEmpty().NotNull();

        }
    }
}
