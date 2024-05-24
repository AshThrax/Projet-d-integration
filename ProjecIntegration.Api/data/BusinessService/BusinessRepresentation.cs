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
            try
            {
               _repservice.Insert(_mapper.Map<Representation>(dto));
                await Task.CompletedTask;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                Representation doExistEntity =await _repservice.GetById(id);
                if (doExistEntity != null)
                {
                    throw new ArgumentNullException($"there is no entity with the id {id}");
                } //si l'entité n'existe pas exception

                await _repservice.Delete(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<RepresentationDto>> GetAll()
        {
            try
            {
                IEnumerable<Representation> entity = await _repservice.GetAll();
                IEnumerable<RepresentationDto> conversion = _mapper.Map<IEnumerable<RepresentationDto>>(entity);
                return conversion;

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// get from poece 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RepresentationDto>> GetAllFromPiece(int id)
        {
            try
            {
                IEnumerable<Representation> entity = await _repservice.GetAll();
                IEnumerable<Representation> FromPiece = entity.Where(x => x.PieceId == id).ToList();
                return _mapper.Map<IEnumerable<RepresentationDto>>(FromPiece);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// get from Complexe
        /// </summary>
        /// <param name="IdComplexe"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RepresentationDto>> GetAllFromComplexe(int IdComplexe)
        {
            try
            {
                IEnumerable<Representation> entity = await _repservice.GetAll();

                IEnumerable<Representation> fromComplexe = entity.Where(x => x.SalleDeTheatre?.ComplexeId == IdComplexe)
                                        .ToList();
                var conversion = _mapper.Map<IEnumerable<RepresentationDto>>(fromComplexe);
                return conversion;

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RepresentationDto> GetById(int id)
        {
            try
            {
                Representation entity = await _repservice.GetById(id);
                return _mapper.Map<RepresentationDto>(entity);

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// update representation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task Update(int id, UpdateRepresentationDto dto)
        {
            try
            {
                Representation getrep = await _repservice.GetById(id);
                if (getrep != null)
                {
                    Representation entityToUpdate = _mapper.Map<Representation>(dto);
                    _repservice.Update(id, entityToUpdate);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task AddCommandtoRepresentation(AddCommandDto addCommandDto)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// get from salle
        /// </summary>
        /// <param name="salleId"></param>
        /// <returns></returns>
        public async  Task<IEnumerable<RepresentationDto>> GetAllFromSalle(int salleId)
        {
            try
            {
                IEnumerable<Representation> entity = await _repservice.GetAll();

                IEnumerable<Representation> fromComplexe = entity.Where(x => x.SalleDeTheatre.Id == salleId)
                                        .ToList();
                IEnumerable<RepresentationDto> conversion = _mapper.Map<IEnumerable<RepresentationDto>>(fromComplexe);
                return conversion;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
