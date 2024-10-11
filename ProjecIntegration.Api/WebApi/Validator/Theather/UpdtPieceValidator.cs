namespace WebApi.Validator.Theather
{
    public class UpdtPieceValidator : AbstractValidator<UpdatePieceDto>
    {
        public UpdtPieceValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Duree);
            RuleFor(x => x.ThemeId);
            RuleFor(x => x.Auteur);
            RuleFor(x => x.Description);
        }
    }
}
