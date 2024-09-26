namespace ApplicationUser.Dto.Favorit
{
    public class FavoritDto : BasicDto
    {

        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserDetailId { get; set; }
        public List<int>? PieceFavorite { get; set; }
    }
}
