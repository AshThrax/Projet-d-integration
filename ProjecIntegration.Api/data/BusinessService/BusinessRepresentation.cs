using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;
using Domain.Enum;
using Domain.ServiceResponse;

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

        public async Task<ServiceResponse<RepresentationDto>> Create(AddRepresentationDto dto)
        {
            ServiceResponse<RepresentationDto> response = new();
            try
            {
                await _repservice.Insert(_mapper.Map<Representation>(dto));
                await Task.CompletedTask;

                response.Success = true;
                response.Message = "opération ";
                response.Errortype = Errortype.Good;

                return response;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Errortype.Bad;
                return response;
            }
        }

        public async Task<ServiceResponse<RepresentationDto>> Delete(int id)
        {
            ServiceResponse<RepresentationDto> response = new();
            try
            {
                Representation doExistEntity =await _repservice.GetById(id);
                if (doExistEntity != null)
                {
                    throw new ArgumentNullException($"there is no entity with the id {id}");
                } //si l'entité n'existe pas exception

                await _repservice.Delete(id);

                response.Success = true;
                response.Message = "supression de la represnetation";
                response.Errortype=Errortype.Good;
                return response;
            }
            catch (Exception)
            {
                
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Errortype.Bad;
                return response;
            }
        }

        public async Task<ServiceResponse<IEnumerable<RepresentationDto>>> GetAll()
        {
            ServiceResponse<IEnumerable<RepresentationDto>> response = new();
            try
            {
                IEnumerable<Representation> entity = await _repservice.GetAll();
                IEnumerable<RepresentationDto> conversion = _mapper.Map<IEnumerable<RepresentationDto>>(entity);
                response.Success = true;
                response.Data = conversion;
                response.Errortype = Errortype.Good;
                return response;

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Errortype.Bad;
                response.Data= Enumerable.Empty<RepresentationDto>();
                return response;    
            }
        }
        /// <summary>
        /// get from poece 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<IEnumerable<RepresentationDto>>> GetAllFromPiece(int id)
        {
            ServiceResponse<IEnumerable<RepresentationDto>> response = new();
            try
            {
                IEnumerable<Representation> entity = await _repservice.GetAll(x=>x.SalleDeTheatre,c=>c.Piece);
                IEnumerable<Representation> FromPiece = entity.Where(x => x.PieceId == id && x.Seance >= DateTime.Now).ToList();
                response.Data= _mapper.Map<IEnumerable<RepresentationDto>>(FromPiece);
                response.Errortype = Errortype.Good;
                response.Message = "Récupération des representation par pièce";

                return response;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Errortype.Bad;
                response.Data = Enumerable.Empty<RepresentationDto>();
                return response;
            }
        }
        /// <summary>
        /// get from Complexe
        /// </summary>
        /// <param name="IdComplexe"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<IEnumerable<RepresentationDto>>> GetAllFromComplexe(int IdComplexe)
        {
            ServiceResponse<IEnumerable<RepresentationDto>> response = new(); 
            try
            {
                IEnumerable<Representation> entity = await _repservice.GetAll();

                IEnumerable<Representation> fromComplexe = entity.Where(x => x.SalleDeTheatre?.ComplexeId == IdComplexe)
                                                                 .ToList();
               
                response.Data = _mapper.Map<IEnumerable<RepresentationDto>>(fromComplexe);
                response.Errortype = Errortype.Good;
                response.Message = "opération ";
                return response;

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Errortype.Bad;
                response.Data = Enumerable.Empty<RepresentationDto>();
                return response;
            }
        }
        /// <summary>
        /// get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<RepresentationDto>> GetById(int id)
        {
            ServiceResponse<RepresentationDto> response = new();
            try
            {
                Representation entity = await _repservice.GetById(id);
                response.Data= _mapper.Map<RepresentationDto>(entity);
                response.Errortype = Errortype.Good;
                response.Message = "opération Réussis";
                return response;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Errortype.Bad;
                response.Data = new();
                return response;
            }

        }
        /// <summary>
        /// update representation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<RepresentationDto>> Update(int id, UpdateRepresentationDto dto)
        {
            ServiceResponse<RepresentationDto> response=new();
            try
            {
                bool getrep = await _repservice.DoYouExist(dto.Id.Value);
                if (getrep)
                {
                    Representation entityToUpdate = _mapper.Map<Representation>(dto);
                    await _repservice.Update(dto.Id.Value, entityToUpdate);
                    response.Success = true;
                    response.Message = "mise a jour réussi";
                    response.Errortype = Errortype.Good;
                }
                else 
                {
                    response.Success = true;
                    response.Message = $"mise a jour echoué {getrep} n'existe pas";
                    response.Errortype = Errortype.Bad;
                }
                return response;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Errortype.Bad;
                return response;
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
        public async  Task<ServiceResponse<IEnumerable<RepresentationDto>>> GetAllFromSalle(int salleId)
        {
            ServiceResponse<IEnumerable<RepresentationDto>> response = new();
            try
            {
                IEnumerable<Representation> entity = await _repservice.GetAll();

                IEnumerable<Representation> fromComplexe = entity.Where(x => x.SalleDeTheatre?.Id == salleId && x.Seance<=DateTime.Now)
                                                                 .ToList();

                IEnumerable<RepresentationDto> conversion = _mapper.Map<IEnumerable<RepresentationDto>>(fromComplexe);
                
                response.Success = true;
                response.Data = conversion;
                response.Errortype = Errortype.Good;
                response.Message = "opération sur les salles";

                return response;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Errortype = Errortype.Bad;
                response.Message = "opération sur les salles";
                return response ;
            }
        }
    }
}
