using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using AutoMapper;
using Domain.Entity.TheatherEntity;
using WebApi.Application.DTO;

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

        public async Task Create(RepresentationDto dto)
        {
            _repservice.Insert(_mapper.Map<Representation>(dto));
            await Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            var doExistEntity = _repservice.GetById(id);
            if (doExistEntity != null)
            {
                throw new ArgumentNullException($"there is no entity with the id {id}");
            } //si l'entité n'existe pas exception

            _repservice.Delete(id);
        }

        public async Task<IEnumerable<RepresentationDto>> getAll()
        {
            var entity = await _repservice.GetAll();
            var conversion = _mapper.Map<IEnumerable<RepresentationDto>>(entity);
            return conversion;
        }
        public async Task<IEnumerable<RepresentationDto>> getAllFromPiece(int id)
        {
            var entity = await _repservice.GetAll();
            var FromPiece = entity.Where(x => x.IdPiece == id).ToList();
            return _mapper.Map<IEnumerable<RepresentationDto>>(FromPiece);
        }
        public async Task<IEnumerable<RepresentationDto>> getAllFromComplexe(int id)
        {
            var entity = await _repservice.GetAll();

            var fromComplexe = entity.Where(x => x.SalleDeTheatre.complexeId == id)
                                    .ToList();
            var conversion = _mapper.Map<IEnumerable<RepresentationDto>>(fromComplexe);
            return conversion;
        }

        public async Task<RepresentationDto> getById(int id)
        {
            var entity = await _repservice.GetById(id);
            return _mapper.Map<RepresentationDto>(entity);

        }

        public async Task Update(int id, RepresentationDto dto)
        {
            var getrep = await _repservice.GetById(id);
            if (getrep != null)
            {
                var entityToUpdate = _mapper.Map<Representation>(dto);
                _repservice.Update(id, entityToUpdate);
            }

        }
    }
}
