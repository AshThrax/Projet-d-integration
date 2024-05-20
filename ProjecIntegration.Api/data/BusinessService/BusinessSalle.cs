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

        public async Task CreateSalle(int idComplexe, AddSalleDeTheatreDto entity)
        {
            var newEntity = _mapper.Map<SalleDeTheatre>(entity);
            _salleDeTheatreRepository.Insert(newEntity);
        }

        public async Task DeleteSalle(int idSalle)
        {
           await _salleDeTheatreRepository.Delete(idSalle);
        }

        public async Task<IEnumerable<SalleDeTheatreDto>> GetAllSalle()
        {
            var GetEntity = await _salleDeTheatreRepository.GetAll();
            var conversion = _mapper.Map<IEnumerable<SalleDeTheatreDto>>(GetEntity);
            return conversion;
        }

        public async Task<IEnumerable<SalleDeTheatreDto>> GetFromComplexe(int idComplexe)
        {
            var GetEntity = await _salleDeTheatreRepository.GetAll();
            var FromComplexe = GetEntity.Where(x => x.ComplexeId == idComplexe).ToList();
            return _mapper.Map<IEnumerable<SalleDeTheatreDto>>(FromComplexe);
        }

        public async Task<SalleDeTheatreDto> GetSalle(int idSalle)
        {
            var GetEntity = await _salleDeTheatreRepository.GetById(idSalle);

            return _mapper.Map<SalleDeTheatreDto>(GetEntity);
        }

        public async Task Updatesalle(int idSalle, UpdateSalleDeTheatreDto entity)
        {
            var GetEntity = await _salleDeTheatreRepository.GetById(idSalle);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity) + "this Salle detheatre entity doesn't exist");

            var converison = _mapper.Map<SalleDeTheatre>(GetEntity);

            _salleDeTheatreRepository.Update(idSalle, converison);
        }
    }
}
