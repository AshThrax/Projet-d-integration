using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using AutoMapper;
using WebApi.Application.DTO;

namespace DataInfraTheather.BusinessService
{
    /*
     * cette classe s'occuper de la partie businessde l'application complexe
     * Theatre
     * on retrouvez preincipalement a log lié aux interaction entre les salle les piece et les representation 
     */
    public class TheatreBusiness : ITheatreBusiness
    {
        private readonly IMapper _mapper;
        private readonly IRepresentationRepository _representationRepository;
        private readonly ISalleDeTheatreRepository _Sallerepository;
        private readonly IPieceRepository _peceRepository;
        private readonly IComplexeRepository _complexeRepository;

        public TheatreBusiness(
            IMapper mapper,
            IRepresentationRepository representationRepository,
            ISalleDeTheatreRepository sallerepository,
            IPieceRepository peceRepository,
            IComplexeRepository complexeRepository)
        {
            _mapper = mapper;
            _representationRepository = representationRepository;
            _Sallerepository = sallerepository;
            _peceRepository = peceRepository;
            _complexeRepository = complexeRepository;
        }

        public Task CreateRepresentationForPiece(int IdPiece, int idSalle, AddRepresentationDto represnetaion)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRepresentationForPiece(int idRepresentation, int IdPiece)
        {
            ////verification que la representation est bien liée a la piece en question
            var getPiece = await _peceRepository.GetById(IdPiece);
            //si getpiece existe ent tant qu'object
            if (getPiece != null)
            {
                //si la liste existe 
                if (getPiece.Representations != null)
                {
                    var representation = await _representationRepository.GetById(idRepresentation);

                    if (representation != null)
                    {
                        _representationRepository.Delete(idRepresentation);
                    }
                }
            }
            return;
        }

        public async Task<IEnumerable<PieceDto>> GetallPieceFromComplexe(int IdComplexe)
        {
            var getall = await _peceRepository.GetAll();
            var FromComplexe = getall.Where(x => x.SalleDeTheatre.Complexe.Id == IdComplexe);

            return _mapper.Map<IEnumerable<PieceDto>>(FromComplexe);
        }

        public async Task<IEnumerable<RepresentationDto>> GetRepresentationFromPiece(int IdPiece)
        {
            var getall = await _representationRepository.GetAll();
            var FromComplexe = getall.Where(x => x.IdPiece == IdPiece).ToList();

            return _mapper.Map<IEnumerable<RepresentationDto>>(FromComplexe);
        }

        public async Task<IEnumerable<RepresentationDto>> GetRepresentationFromSalle(int IdSalle)
        {
            var getall = await _representationRepository.GetAll();
            var FromComplexe = getall.Where(x => x.IdSalledeTheatre == IdSalle).ToList();

            return _mapper.Map<IEnumerable<RepresentationDto>>(FromComplexe);
        }

        public async Task SetPieceSalle(int IdPiece, int idSalle)
        {
            var getPiece = await _peceRepository.GetById(IdPiece);
            if (getPiece != null)
            {
                getPiece.IdSalle = idSalle;
                _peceRepository.Update(IdPiece, getPiece);
            }

        }
    }
}
