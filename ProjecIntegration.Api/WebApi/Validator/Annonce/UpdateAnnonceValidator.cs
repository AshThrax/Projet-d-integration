using ApplicationAnnonce.DTO;

namespace WebApi.Validator.Annonce
{
    public class UpdateAnnonceValidator:AbstractValidator<UpdateAnnonceDto>
    {
        public UpdateAnnonceValidator() 
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
