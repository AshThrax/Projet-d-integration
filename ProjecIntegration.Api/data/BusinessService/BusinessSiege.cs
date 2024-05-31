using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using DataInfraTheather.Infrastructure.Repository;
using Domain.Entity.TheatherEntity;
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

        public async Task<SiegeDto> CreateSiegeForSalle(AddSiegeDto siege)
        {
            try
            {
               Siege siegeAdd= _mapper.Map<Siege>(siege);
               Siege Added= await  _siegeRepository.Insert(siegeAdd);
                return _mapper.Map<SiegeDto>(Added);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteSiegeById(int SiegeId)
        {
            try
            {
                Siege getSiege = await _siegeRepository.GetById(SiegeId);

                if (getSiege != null)
                {
                    await _siegeRepository.Delete(SiegeId);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SiegeDto> GetSiegeById(int siegeId)
        {
            try
            {
                Siege getSiege = await _siegeRepository.GetById(siegeId);

                return _mapper.Map<SiegeDto>(getSiege);
            }
            catch (Exception)
            {
                return new SiegeDto();
            }
        }
     
        public async Task<IEnumerable<SiegeDto>> GetSiegeFromCommand(int commandId)
        {
            try
            {

                var entity = await _commandRepository.GetById(commandId);

                return new  List<SiegeDto>();
               
            }
            catch (Exception)
            {
                return new List<SiegeDto>();
            }
        }

        public async Task<IEnumerable<SiegeDto>> GetSiegeFromSalleId(int salleId)
        {
            try
            {
                IEnumerable <Siege> getSiege = await _siegeRepository.GetAllFromSalle(salleId);

                return _mapper.Map<IEnumerable<SiegeDto>>(getSiege);

            }
            catch (Exception)
            {

                return new List<SiegeDto>();
            }
        }

        public async Task UpdateSiegeById(int SiegeId, UpdateSiegeDto siege)
        {
            try
            {
                Siege getSiege = await _siegeRepository.GetById(SiegeId);

                if (getSiege != null)
                {
                    Siege SiegeToUpdate =_mapper.Map<Siege>(getSiege);
                    _siegeRepository.Update(SiegeId, SiegeToUpdate);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
