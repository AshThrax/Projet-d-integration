using ApplicationPublication.Dto;

namespace WebApi.Validator.Publication
{
    public class AddPostValidator : AbstractValidator<AddPostDto>
    {
        public AddPostValidator() 
        {
            
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.PublicationId).NotEmpty();
        }
    }
}
