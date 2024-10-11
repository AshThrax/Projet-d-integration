namespace WebApi.Validator.Theather
{
    public class UpdtCommandValidator : AbstractValidator<UpdateCommandDto>
    {
        public UpdtCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
