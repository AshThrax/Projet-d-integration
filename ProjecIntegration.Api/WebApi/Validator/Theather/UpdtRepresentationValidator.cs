namespace WebApi.Validator.Theather
{
    public class UpdtRepresentationValidator : AbstractValidator<UpdateRepresentationDto>
    {
        public UpdtRepresentationValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.SalledeTheatreId).NotNull();
            RuleFor(x => x.PlaceCurrent).NotNull();
            RuleFor(x => x.Prix).NotNull();
            RuleFor(x => x.PlaceMaximum).NotNull();
            RuleFor(x => x.Seance).NotNull();
        }
    }
}
