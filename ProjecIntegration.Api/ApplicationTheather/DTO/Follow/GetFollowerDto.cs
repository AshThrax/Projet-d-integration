namespace ApplicationUser.Dto
{
    public class GetFollowerDto: BasicDto
    {
        public string FollowerId { get; set; } = string.Empty;
        public string FollowId { get; set; } = string.Empty;
    }
}
