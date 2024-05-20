using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;

namespace DataInfraTheather.BusinessService
{
    public class BusinessRepresntation : IBusinessRepresentation
    {
        private readonly IRepresentationRepository _repservice;
        private readonly IComplexeRepository _ComplexeService;
        private readonly IMapper _mapper;
        public BusinessRepresntation(
            IMapper mapper,
            IRepresentationRepository representationRepository,
            IComplexeRepository complexeService)
        {
            _mapper = mapper;
            _repservice = representationRepository;
            _ComplexeService = complexeService;
        }

        public async Task Create(AddRepresentationDto dto)
        {
           _repservice.Insert(_mapper.Map<Representation>(dto));
            await Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            Representation doExistEntity =await _repservice.GetById(id);
            if (doExistEntity != null)
            {
                throw new ArgumentNullException($"there is no entity with the id {id}");
            } //si l'entité n'existe pas exception

            await _repservice.Delete(id);
        }

        public async Task<IEnumerable<RepresentationDto>> GetAll()
        {
            var entity = await _repservice.GetAll();
            var conversion = _mapper.Map<IEnumerable<RepresentationDto>>(entity);
            return conversion;
        }
        public async Task<IEnumerable<RepresentationDto>> GetAllFromPiece(int id)
        {
            var entity = await _repservice.GetAll();
            var FromPiece = entity.Where(x => x.IdPiece == id).ToList();
            return _mapper.Map<IEnumerable<RepresentationDto>>(FromPiece);
        }
        public async Task<IEnumerable<RepresentationDto>> GetAllFromComplexe(int IdComplexe)
        {
            var entity = await _repservice.GetAll();

            var fromComplexe = entity.Where(x => x.SalleDeTheatre?.ComplexeId == IdComplexe)
                                    .ToList();
            var conversion = _mapper.Map<IEnumerable<RepresentationDto>>(fromComplexe);
            return conversion;
        }

        public async Task<RepresentationDto> GetById(int id)
        {
            var entity = await _repservice.GetById(id);
            return _mapper.Map<RepresentationDto>(entity);

        }

        public async Task Update(int id, UpdateRepresentationDto dto)
        {
            Representation getrep = await _repservice.GetById(id);
            if (getrep != null)
            {
                Representation entityToUpdate = _mapper.Map<Representation>(dto);
                _repservice.Update(id, entityToUpdate);
            }

        }

        public Task AddCommandtoRepresentation(AddCommandDto addCommandDto)
        {
            throw new NotImplementedException();
        }
    }
}
