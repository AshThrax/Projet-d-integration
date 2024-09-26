
namespace ApplicationTheather.DTO
{
    public class AddFavoritDto 
    {
        public string UserId { get; set; }= string.Empty;
        public List<int>? PieceFavorite { get; set; }
    }
}
