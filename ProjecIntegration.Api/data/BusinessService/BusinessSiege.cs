using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;

namespace DataInfraTheather.BusinessService
{
    public class BusinessSiege : IBusinessSiege
    {
        private readonly ISiegeRepository _siegeRepository;
        private readonly ICommandRepository _commandRepository;
        private readonly ISalleDeTheatreRepository _salleDeTheatreRepository;
        private readonly IMapper _mapper;
        private readonly ISiegeCommandRepository _siegeCommandRepository;
        public BusinessSiege(ISiegeRepository siegeRepository, 
                             ISalleDeTheatreRepository salleDeTheatreRepository,
                             ISiegeCommandRepository siegeCommandRepository,
                             ICommandRepository commandRepository,
                             IMapper mapper)
        {
            _siegeRepository = siegeRepository;
            _salleDeTheatreRepository = salleDeTheatreRepository;
            _mapper = mapper;
            _commandRepository = commandRepository;
            _siegeCommandRepository = siegeCommandRepository;
        }

        public async Task<ServiceResponse<SiegeDto>> CreateSiegeForSalle(AddSiegeDto siege)
        {
            ServiceResponse<SiegeDto> response = new();
            try
            {
               Siege siegeAdd= _mapper.Map<Siege>(siege);
               siegeAdd.CreatedDate = DateTime.Now;
               Siege Added= await  _siegeRepository.Insert(siegeAdd);

               response.Data= _mapper.Map<SiegeDto>(Added);
               response.Success= true;
               response.Message = "operation réussi";
               response.Errortype=Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Errortype=Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<SiegeDto>> DeleteSiegeById(int SiegeId)
        {
            ServiceResponse<SiegeDto> response = new();
            try
            {
                Siege getSiege = await _siegeRepository.GetById(SiegeId);

                if (getSiege != null)
                {
                    await _siegeRepository.Delete(SiegeId);
                    response.Success = true;
                    response.Message = "operation réussi";
                    response.Errortype = Domain.Enum.Errortype.Good;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<SiegeDto>>> GetAvailbleByrepresentationId(int representationId,int salleId)
        {
            ServiceResponse<IEnumerable<SiegeDto>> response = new();
            try
            {
                //récupére les siege reserver sur base de la representation et de la salle
                List<SiegeCommand> SiegeARecuperer = (await _siegeCommandRepository.GetAllCustomWithInclude(x => x.Command.IdRepresentation == representationId, c => c.Siege)).ToList();
                IEnumerable<int> getSiegeUnavailable = SiegeARecuperer.Select(x => x.Siege.Id);
                //récupére les Siéfe lier a la salle
                List<Siege> getAvailableSiege = (await _siegeRepository.GetAllCustomWithInclude(x => x.SalleId == salleId)).ToList();
                //ne récup^ére que les siege qui se sont pas présente dans la liste
                getAvailableSiege = getAvailableSiege.Where(x => !getSiegeUnavailable.Contains(x.Id)).ToList();
                response.Data = _mapper.Map<IEnumerable<SiegeDto>>(getAvailableSiege);
                response.Success = true;
                response.Message = "operation réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une Erreurr a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<SiegeDto>> GetSiegeById(int siegeId)
        {
            ServiceResponse<SiegeDto> response = new();
            try
            {
                Siege getSiege = await _siegeRepository.GetById(siegeId);

                response.Data= _mapper.Map<SiegeDto>(getSiege);
                response.Success = true;
                response.Message = "operation réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une Erreurr a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }
     
        public async Task<ServiceResponse<IEnumerable<SiegeDto>>> GetSiegeFromCommand(int commandId)
        {
            ServiceResponse<IEnumerable<SiegeDto>> response = new();
            try
            {

                var entity = await _siegeCommandRepository.GetAllCustomWithInclude(x=>x.CommandId==commandId,d=>d.Siege);
                IEnumerable<Siege> getSiegeFromCommand =entity.Select(x=>x.Siege).ToList();

                response.Data = _mapper.Map<IEnumerable<SiegeDto>>(getSiegeFromCommand);
                response.Success = true;
                response.Message = "operation réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<SiegeDto>>> GetSiegeFromSalleId(int salleId)
        {
            ServiceResponse<IEnumerable<SiegeDto>> response = new();
            try
            {
                IEnumerable <Siege> getSiege = await _siegeRepository.GetAllFromSalle(salleId);

                response.Data= _mapper.Map<IEnumerable<SiegeDto>>(getSiege);
                response.Success = true;
                response.Message = "operation réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<SiegeDto>> UpdateSiegeById(int SiegeId, UpdateSiegeDto siege)
        {
            ServiceResponse<SiegeDto> response = new();
            try
            {
                Siege getSiege = await _siegeRepository.GetById(SiegeId);

                if (getSiege != null)
                {

                    getSiege.UpdatedDate = DateTime.Now;
                    getSiege.SalleId = siege.SalleId;
                    getSiege.Name = siege.Name;
                    await _siegeRepository.Update(SiegeId, getSiege);
                    response.Success = true;
                    response.Message = "operation réussi";
                    response.Errortype = Domain.Enum.Errortype.Good;
                }
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }
    }
}
