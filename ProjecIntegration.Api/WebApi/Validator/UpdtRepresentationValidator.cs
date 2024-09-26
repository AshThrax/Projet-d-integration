namespace WebApi.Validator
{
    public class UpdtRepresentationValidator : AbstractValidator<UpdateRepresentationDto>
    {
        public UpdtRepresentationValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
