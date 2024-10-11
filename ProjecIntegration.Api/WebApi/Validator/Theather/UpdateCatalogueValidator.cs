namespace WebApi.Validator.Theather
{
    public class UpdateCatalogueValidator : AbstractValidator<UpdateCatalogueDto>
    {
        public UpdateCatalogueValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ComplexeId).NotNull();
        }
    }
}
