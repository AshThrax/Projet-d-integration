namespace WebApi.Validator.Theather
{
    public class UpdtComplexeValidator : AbstractValidator<UpdateComplexeDto>
    {
        public UpdtComplexeValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Adress);
            RuleFor(x => x.Name);
            RuleFor(x => x.Description);
        }
    }
}
