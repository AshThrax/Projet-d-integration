using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;

namespace DataInfraTheather.BusinessService
{
    /*
     * service dédiée a la gestiondes salle de theatre
     */
    public class BusinessSalle : IBusinessSalle
    {
        private readonly ISalleDeTheatreRepository _salleDeTheatreRepository;
        private readonly IMapper _mapper;

        public BusinessSalle(ISalleDeTheatreRepository salleDeTheatreRepository, IMapper mapper)
        {
            _salleDeTheatreRepository = salleDeTheatreRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SalleDeTheatreDto>> CreateSalle(int idComplexe, AddSalleDeTheatreDto entity)
        {
            ServiceResponse<SalleDeTheatreDto> response = new();
            try
            {
                SalleDeTheatre newEntity = _mapper.Map<SalleDeTheatre>(entity);
                await _salleDeTheatreRepository.Insert(newEntity);

                response.Success = true;
                response.Message = "opération réussi";
                response.Errortype=Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<SalleDeTheatreDto>> DeleteSalle(int idSalle)
        {
            ServiceResponse<SalleDeTheatreDto> response = new();
            try
            {
                SalleDeTheatre salle = await _salleDeTheatreRepository.GetById(idSalle);
                if(salle != null)
                {
                    await _salleDeTheatreRepository.Delete(idSalle);
                    response.Success = true;
                    response.Message = "opération réussi";
                    response.Errortype = Domain.Enum.Errortype.Good;
                }
                

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<SalleDeTheatreDto>>> GetAllSalle()
        {
            ServiceResponse<IEnumerable<SalleDeTheatreDto>> response = new();
            try
            {
                var GetEntity = await _salleDeTheatreRepository.GetAll();
                var conversion = _mapper.Map<IEnumerable<SalleDeTheatreDto>>(GetEntity);
                response.Data= conversion;
                response.Success = true;
                response.Message = "opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<SalleDeTheatreDto>>> GetFromComplexe(int idComplexe)
        {
            ServiceResponse<IEnumerable<SalleDeTheatreDto>> response = new();
            try
            {
                var GetEntity = await _salleDeTheatreRepository.GetAll();
                var FromComplexe = GetEntity.Where(x => x.ComplexeId == idComplexe).ToList();
                //générationde l'objet Final
                response.Data= _mapper.Map<IEnumerable<SalleDeTheatreDto>>(FromComplexe);
                response.Success = true;
                response.Message = "opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<SalleDeTheatreDto>> GetSalle(int idSalle)
        {
            ServiceResponse<SalleDeTheatreDto> response = new();
            try
            {
                SalleDeTheatre GetEntity = await _salleDeTheatreRepository.GetById(idSalle);

                response.Data= _mapper.Map<SalleDeTheatreDto>(GetEntity);
                response.Success = true;
                response.Message = "";
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<SalleDeTheatreDto>> Updatesalle(int idSalle, UpdateSalleDeTheatreDto entity)
        {
            ServiceResponse<SalleDeTheatreDto> response = new();
            try
            {
                SalleDeTheatre GetEntity = await _salleDeTheatreRepository.GetById(idSalle);
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity) + "this Salle detheatre entity doesn't exist");

                var converison = _mapper.Map<SalleDeTheatre>(GetEntity);

               await _salleDeTheatreRepository.Update(idSalle, converison);
                
                response.Success = true;
                response.Message = "opération Réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }
    }
}
