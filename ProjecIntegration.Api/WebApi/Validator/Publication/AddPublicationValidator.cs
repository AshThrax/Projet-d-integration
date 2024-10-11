using ApplicationPublication.Dto;

namespace WebApi.Validator.Publication
{
    public class AddPublicationValidator : AbstractValidator<AddPublicationDto>
    {
        public AddPublicationValidator() { 
            RuleFor(x=>x.PieceId).NotEmpty();
            RuleFor(x=>x.Title).NotEmpty();
            RuleFor(x=>x.Review).Empty();
           
        }
    }
}
