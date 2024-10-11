using ApplicationPublication.Dto;

namespace WebApi.Validator.Publication
{
    public class UpdatePublicationValidator : AbstractValidator<UpdatePublicationDto>
    {
        public UpdatePublicationValidator()
        {
            RuleFor(x => x.PieceId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Review).Empty();

        }
    }
}
