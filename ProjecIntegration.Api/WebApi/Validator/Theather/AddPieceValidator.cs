namespace WebApi.Validator.Theather
{
    public class AddPieceValidator : AbstractValidator<AddPieceDto>
    {
        public AddPieceValidator()
        {

            RuleFor(x => x.Duree);
            RuleFor(x => x.ThemeId);
            RuleFor(x=>x.Auteur);
            RuleFor(x => x.Description);
        }
    }
}
