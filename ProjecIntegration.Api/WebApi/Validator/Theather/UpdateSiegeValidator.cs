namespace WebApi.Validator.Theather
{
    public class UpdateSiegeValidator :AbstractValidator<UpdateSiegeDto>
    {
        public UpdateSiegeValidator() 
        {
            RuleFor(x => x.SalleId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
