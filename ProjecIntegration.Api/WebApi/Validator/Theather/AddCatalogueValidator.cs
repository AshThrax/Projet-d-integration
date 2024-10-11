namespace WebApi.Validator.Theather
{
    public class AddCatalogueValidator : AbstractValidator<AddCatalogueDto>
    {
        public AddCatalogueValidator() 
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.ComplexeId).NotNull();
        }
    }
}
