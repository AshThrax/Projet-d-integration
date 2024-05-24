using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;

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

        public  void CreateSalle(int idComplexe, AddSalleDeTheatreDto entity)
        {
            try
            {
                SalleDeTheatre newEntity = _mapper.Map<SalleDeTheatre>(entity);
                _salleDeTheatreRepository.Insert(newEntity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteSalle(int idSalle)
        {
            try
            {
                SalleDeTheatre salle = await _salleDeTheatreRepository.GetById(idSalle);
                if(salle != null)
                {
                    await _salleDeTheatreRepository.Delete(idSalle);

                }
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<SalleDeTheatreDto>> GetAllSalle()
        {
            try
            {
                var GetEntity = await _salleDeTheatreRepository.GetAll();
                var conversion = _mapper.Map<IEnumerable<SalleDeTheatreDto>>(GetEntity);
                return conversion;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<SalleDeTheatreDto>> GetFromComplexe(int idComplexe)
        {
            try
            {
                var GetEntity = await _salleDeTheatreRepository.GetAll();
                var FromComplexe = GetEntity.Where(x => x.ComplexeId == idComplexe).ToList();
                return _mapper.Map<IEnumerable<SalleDeTheatreDto>>(FromComplexe);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SalleDeTheatreDto> GetSalle(int idSalle)
        {
            try
            {
                var GetEntity = await _salleDeTheatreRepository.GetById(idSalle);

                return _mapper.Map<SalleDeTheatreDto>(GetEntity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Updatesalle(int idSalle, UpdateSalleDeTheatreDto entity)
        {
            try
            {
                var GetEntity = await _salleDeTheatreRepository.GetById(idSalle);
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity) + "this Salle detheatre entity doesn't exist");

                var converison = _mapper.Map<SalleDeTheatre>(GetEntity);

                _salleDeTheatreRepository.Update(idSalle, converison);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
