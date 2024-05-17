using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;

namespace DataInfraTheather.BusinessService
{
    /*
     * classe chargée de la logique business de l'applciation
     * en ce qui concerne la gestiondes piece de theatre 
     * 
    */
    public class BusinessPiece : IBusinessPiece
    {
        private readonly IPieceRepository _pieceRepository;
        private IMapper _mapper;

        public BusinessPiece(IPieceRepository pieceRepository, IMapper mapper)
        {
            _pieceRepository = pieceRepository;
            _mapper = mapper;
        }

        public async Task Create(AddPieceDto Entity)
        {
            var entittyConversion = _mapper.Map<Piece>(Entity);
            _pieceRepository.Insert(entittyConversion);
        }

        public async Task Delete(int idPIece)
        {
            var getPiece = await _pieceRepository.GetById(idPIece);
            if (getPiece != null)
            {
                _pieceRepository.Delete(idPIece);
            }
        }

        public async Task<PieceDto> Get(int idPIece)
        {
            var GetPiece = await _pieceRepository.GetById(idPIece);
            return _mapper.Map<PieceDto>(GetPiece);
        }

        public async Task<IEnumerable<PieceDto>> GetAll()
        {
            var GetPiece = await _pieceRepository.GetAll();
            return _mapper.Map<IEnumerable<PieceDto>>(GetPiece);
        }

        public async Task Update(int idPiece, UpdatePieceDto Entity)
        {
            var getPiece = await _pieceRepository.GetById(idPiece);
            if (getPiece != null)
            {
                var getConvertion = _mapper.Map<Piece>(Entity);
                _pieceRepository.Update(idPiece, getConvertion);
            }
        }
    }
}
