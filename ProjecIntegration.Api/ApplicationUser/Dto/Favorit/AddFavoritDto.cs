namespace ApplicationUser.Dto.Favorit
{
    public class AddFavoritDto : AddBaseDto
    {
        public int UserDetailId { get; set; }
        public List<int>? PieceFavorite { get; set; }
    }
}
