namespace WebApi.Validator
{
    public class UpdtPieceValidator : AbstractValidator<UpdatePieceDto>
    {
        public UpdtPieceValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
