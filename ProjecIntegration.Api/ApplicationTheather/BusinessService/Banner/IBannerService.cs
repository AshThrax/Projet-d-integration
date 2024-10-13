using ApplicationUser.Dto;
using Domain.ServiceResponse;

namespace ApplicationUser.BusinessService.Banner
{
    public interface IBannerService
    {
        Task<ServiceResponse<BannerDto>> AddBanner(string userId, string Imageressourcess);
        Task<ServiceResponse<BannerDto>> HasBanner(string userId);
        Task<ServiceResponse<BannerDto>> UpdateBanner(string userId, string ImageRessourcess);
    }
}
