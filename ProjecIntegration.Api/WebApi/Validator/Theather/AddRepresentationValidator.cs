namespace WebApi.Validator.Theather
{
    public class AddRepresentationValidator : AbstractValidator<AddRepresentationDto>
    {
        public AddRepresentationValidator()
        {

            RuleFor(x => x.SalledeTheatreId).NotNull();
            RuleFor(x => x.PlaceCurrent).NotNull();
            RuleFor(x => x.Prix).NotNull();
            RuleFor(x => x.PlaceMaximum).NotNull();
            RuleFor(x=>x.Seance).NotNull();
        }
    }
}
