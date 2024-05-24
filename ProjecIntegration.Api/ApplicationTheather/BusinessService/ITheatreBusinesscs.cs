using ApplicationTheather.DTO;
using Domain.Entity.TheatherEntity;

namespace ApplicationTheather.BusinessService
{
    public interface ITheatreBusiness
    {
        Task<IEnumerable<ThemeDto>> GetAllTheme();

        Task<ThemeDto> GetThemeById(int themeId);

        void CreateTheme(ThemeDto theme);

        void UpdateTheme(int themeId,ThemeDto updtTheme);   
        void Deletetheme(int themeId);
    }
}
