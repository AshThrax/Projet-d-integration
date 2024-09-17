using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;

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

        public async Task<ServiceResponse<ThemeDto>> CreateTheme(ThemeDto theme)
        {
            ServiceResponse<ThemeDto> response = new ServiceResponse<ThemeDto>();
            try
            {
               Theme addTheme = _mapper.Map<Theme>(theme);

               response.Data=_mapper.Map<ThemeDto>( await _themeRepository.Insert(addTheme));
               response.Success = true;
               response.Errortype=Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<ThemeDto>> Deletetheme(int themeId)
        {
            ServiceResponse<ThemeDto> response = new ServiceResponse<ThemeDto>();
            try
            {
                await _themeRepository.Delete(themeId);
                response.Success = true;
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<ThemeDto>>> GetAllTheme()
        {
            ServiceResponse<IEnumerable<ThemeDto>> response = new ServiceResponse<IEnumerable<ThemeDto>>();
            try
            {
                response.Data=_mapper.Map<IEnumerable<ThemeDto>>(await  _themeRepository.GetAll());
                response.Success = true;
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<ThemeDto>> GetThemeById(int themeId)
        {
            ServiceResponse<ThemeDto> response = new ServiceResponse<ThemeDto>();
            try
            {
                response.Data= _mapper.Map<ThemeDto>(await _themeRepository.GetById(themeId));
                response.Success = true;
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<ThemeDto>> UpdateTheme(int themeId,ThemeDto updtTheme)
        {
            ServiceResponse<ThemeDto> response = new ServiceResponse<ThemeDto>();
            try
            {
                Theme entityConvert =_mapper.Map<Theme>(updtTheme);
                await _themeRepository.Update(themeId, entityConvert);
                response.Success = true;
                response.Message = "opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = true;
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }
    }
}
