using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;

namespace DataInfraTheather.BusinessService
{
    /*
     * cette classe s'occuper de la partie businessde l'application complexe
     * Theatre
     * on retrouvez preincipalement a log lié aux interaction entre les salle les piece et les representation 
     */
    public class TheatreBusiness : ITheatreBusiness
    {
        private readonly IMapper _mapper;
        private readonly IThemeRepository _themeRepository;

        public TheatreBusiness(
            IMapper mapper, IThemeRepository themeRepository)
        {
            _mapper = mapper;
            _themeRepository = themeRepository;
        }

        public void CreateTheme(ThemeDto theme)
        {

            try
            {
               Theme addTheme = _mapper.Map<Theme>(theme);

               _themeRepository.Insert(addTheme);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletetheme(int themeId)
        {
            try
            {
                _themeRepository.Delete(themeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ThemeDto>> GetAllTheme()
        {
            try
            {
                return _mapper.Map<IEnumerable<ThemeDto>>(await  _themeRepository.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ThemeDto> GetThemeById(int themeId)
        {
            try
            {
                return _mapper.Map<ThemeDto>(await _themeRepository.GetById(themeId));
            
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateTheme(int themeId,ThemeDto updtTheme)
        {
            try
            {
                Theme entityConvert =_mapper.Map<Theme>(updtTheme);
                _themeRepository.Update(themeId, entityConvert);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
