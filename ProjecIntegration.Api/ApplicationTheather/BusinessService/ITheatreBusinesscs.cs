using ApplicationTheather.DTO;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;

namespace ApplicationTheather.BusinessService
{
    public interface ITheatreBusiness
    {
        Task<ServiceResponse<IEnumerable<ThemeDto>>> GetAllTheme();

        Task<ServiceResponse<ThemeDto>> GetThemeById(int themeId);

        Task<ServiceResponse<ThemeDto>> CreateTheme(ThemeDto theme);

        Task<ServiceResponse<ThemeDto>> UpdateTheme(int themeId,ThemeDto updtTheme);
        Task<ServiceResponse<ThemeDto>> Deletetheme(int themeId);
    }
}
