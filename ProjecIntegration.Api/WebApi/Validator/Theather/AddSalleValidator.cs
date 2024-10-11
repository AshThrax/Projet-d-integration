namespace WebApi.Validator.Theather
{
    public class AddSalleValidator : AbstractValidator<AddSalleDeTheatreDto>
    {
        public AddSalleValidator() 
        {
            RuleFor(x =>x.Name).NotEmpty();
            RuleFor(x=>x.PlaceMax).NotEmpty();
            RuleFor(x=>x.ComplexeId).NotNull();
        }
    }
}
