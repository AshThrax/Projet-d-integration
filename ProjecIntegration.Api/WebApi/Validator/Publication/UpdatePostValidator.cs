using ApplicationPublication.Dto;

namespace WebApi.Validator.Publication
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostDto>
    {
        public UpdatePostValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Content).NotEmpty();
            RuleFor(x=>x.PublicationId).NotEmpty();
        }
    }
}
