namespace WebApi.Validator.Theather
{
    public class UpdtSalleValidator : AbstractValidator<UpdateSalleDeTheatreDto>
    {
        public UpdtSalleValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PlaceMax).NotEmpty();
            RuleFor(x => x.ComplexeId).NotNull();
        }
    }
}
