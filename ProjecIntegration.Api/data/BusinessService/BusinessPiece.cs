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
        private readonly IImageRepository _imageRepository; 
        private readonly ICataloguePieceRepository _cataloguePieceRepository; 
        private IMapper _mapper;

        public BusinessPiece(IPieceRepository pieceRepository,IImageRepository imageRepository, ICataloguePieceRepository cataloguePieceRepository, IMapper mapper)
        {
            _pieceRepository = pieceRepository;
            _imageRepository = imageRepository;
            _cataloguePieceRepository = cataloguePieceRepository;
            _mapper = mapper;
        }

        public void Create(AddPieceDto Entity)
        {
            try
            {
                Piece entittyConversion = _mapper.Map<Piece>(Entity);
               
                _pieceRepository.Insert(entittyConversion);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(int idPiece)
        {
            try
            {
                Piece getPiece = await _pieceRepository.GetById(idPiece);
                if (getPiece != null)
                {
                   await _pieceRepository.Delete(idPiece);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PieceDto> Get(int idPIece)
        {
            try
            {
                Piece GetPiece = await _pieceRepository.GetById(idPIece,c =>c.Image);
                
               PieceDto GetPieceDto= new PieceDto().ConvertToDtos(GetPiece,_mapper);

              
               return GetPieceDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PieceDto>> GetAll()
        {
            try
            {
                IEnumerable<Piece> GetPiece = await _pieceRepository.GetAll(c=>c.Image);
                List<PieceDto> PieceDtos=new PieceDto().ConvertToDtos(GetPiece.ToList(),_mapper  );

             
                return PieceDtos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PieceDto>> GetPieceByTheme(int themeId)
        {
            try
            {
                IEnumerable<Piece?> GetPieces = await _pieceRepository.GetPieceByTheme(themeId);

                List<PieceDto> PieceDtos = new PieceDto().ConvertToDtos(GetPieces.ToList(), _mapper );


                return PieceDtos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogueId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PieceDto>> GetPiecefromCatalogue(int catalogueId)
        {
            try
            {
                IEnumerable<int> GetPieceIds = await _cataloguePieceRepository.GetPieceFromCatalogue(catalogueId);
                IEnumerable<Piece> GetPieces = await _pieceRepository.GetPieceByListId(GetPieceIds.ToList());
                List<PieceDto> PieceDtos = new PieceDto().ConvertToDtos(GetPieces.ToList(),_mapper );


                return PieceDtos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// mise a jour des piece de theatre
        /// </summary>
        /// <param name="idPiece"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public async Task Update(int idPiece, UpdatePieceDto Entity)
        {
            try
            {
                Piece getPiece = await _pieceRepository.GetById(idPiece);
                if (getPiece != null)
                {
                    Piece getConvertion = _mapper.Map<Piece>(Entity);
                    _pieceRepository.Update(idPiece, getConvertion);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
