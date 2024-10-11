using ApplicationAnnonce.DTO;

namespace WebApi.Validator.Annonce
{
    public class AddAnonceValidator : AbstractValidator<AddAnnonceDto>
    {
        public AddAnonceValidator() 
        {
            RuleFor(x=>x.Title).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}
