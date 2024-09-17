using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Azure;
using DataInfraTheather.Infrastructure.Repository;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInfraTheather.BusinessService
{
    public class BusinessSiege : IBusinessSiege
    {
        private readonly ISiegeRepository _siegeRepository;
        private readonly ICommandRepository _commandRepository;
        private readonly ISalleDeTheatreRepository _salleDeTheatreRepository;
        private readonly IMapper _mapper;

        public BusinessSiege(ISiegeRepository siegeRepository, ISalleDeTheatreRepository salleDeTheatreRepository,ICommandRepository commandRepository,  IMapper mapper)
        {
            _siegeRepository = siegeRepository;
            _salleDeTheatreRepository = salleDeTheatreRepository;
            _mapper = mapper;
            _commandRepository = commandRepository;
        }

        public async Task<ServiceResponse<SiegeDto>> CreateSiegeForSalle(AddSiegeDto siege)
        {
            ServiceResponse<SiegeDto> response = new();
            try
            {
               Siege siegeAdd= _mapper.Map<Siege>(siege);
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

                var entity = await _commandRepository.GetById(commandId);

               
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
                    Siege SiegeToUpdate =_mapper.Map<Siege>(getSiege);
                    await _siegeRepository.Update(SiegeId, SiegeToUpdate);
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
