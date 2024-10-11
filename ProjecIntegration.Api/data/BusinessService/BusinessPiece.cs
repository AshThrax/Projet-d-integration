using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;

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

        public async Task<ServiceResponse<PieceDto>> Create(AddPieceDto Entity)
        {
            ServiceResponse<PieceDto> response = new();
            try
            {
                Piece entittyConversion = _mapper.Map<Piece>(Entity);
                entittyConversion.CreatedDate = DateTime.Now;
                await _pieceRepository.Insert(entittyConversion);
                response.Success = true;
                response.Message = "opération réussi";
                
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
            }
            return response;
        }

        public async Task<ServiceResponse<PieceDto>> Delete(int idPiece)
        {
            ServiceResponse<PieceDto> response = new();
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
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
            }
            return response;
        }

        public async Task<ServiceResponse<PieceDto>> Get(int idPIece)
        {
            ServiceResponse<PieceDto> response = new();
            try
            {
               Piece GetPiece = await _pieceRepository.GetById(idPIece,c =>c.Image);
                
               PieceDto GetPieceDto= new PieceDto().ConvertToDtos(GetPiece,_mapper);

              response.Data=GetPieceDto;
                response.Success = true;
                response.Message = "opération reussi"; 
             
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<IEnumerable<PieceDto>>> GetAll()
        {
            ServiceResponse<IEnumerable<PieceDto>> response = new();
            try
            {
                IEnumerable<Piece> GetPiece = await _pieceRepository.GetAll(c=>c.Image);
                List<PieceDto> PieceDtos=new PieceDto().ConvertToDtos(GetPiece.ToList(),_mapper  );

                response.Data = PieceDtos;
                response.Success = true;
                response.Message = "opération reussi";

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
            }
            return response;
        }
        /// <summary>
        /// recupéraiton des Piece par theme
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<IEnumerable<PieceDto>>> GetPieceByTheme(int themeId)
        {
            ServiceResponse<IEnumerable<PieceDto>> response = new();
            try
            {
                IEnumerable<Piece?> GetPieces = await _pieceRepository.GetPieceByTheme(themeId);

                List<PieceDto> PieceDtos = new PieceDto().ConvertToDtos(GetPieces.ToList(), _mapper );
                response.Data = PieceDtos;
                response.Success = true;
                response.Message = "opération reussi";
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogueId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<IEnumerable<PieceDto>>> GetPiecefromCatalogue(int catalogueId)
        {
            ServiceResponse<IEnumerable<PieceDto>> response = new();
            try
            {
                IEnumerable<int> GetPieceIds = await _cataloguePieceRepository.GetPieceFromCatalogue(catalogueId);
                IEnumerable<Piece> GetPieces = await _pieceRepository.GetPieceByListId(GetPieceIds.ToList());
                List<PieceDto> PieceDtos = new PieceDto().ConvertToDtos(GetPieces.ToList(),_mapper );
                response.Data = PieceDtos;
                response.Success = true;
                response.Message = "opération reussi";
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
            }
            return response;
        }
        /// <summary>
        /// mise a jour des piece de theatre
        /// </summary>
        /// <param name="idPiece"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<PieceDto>> Update(int idPiece, UpdatePieceDto Entity)
        {
            ServiceResponse<PieceDto> response = new();
            try
            {
                Piece getPiece = await _pieceRepository.GetById(idPiece);
                if (getPiece != null)
                {
                    getPiece.Auteur = Entity.Auteur;
                    getPiece.Duree = Entity.Duree;
                    getPiece.Titre = Entity.Titre;
                    getPiece.ThemeId = Entity.ThemeId.Value;
                    getPiece.Description = Entity.Description;
                    getPiece.UpdatedDate = DateTime.Now;
                    await _pieceRepository.Update(idPiece, getPiece);
         
                    response.Success = true;
                    response.Message = "opération reussi";
                }

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu lors de l'opération";
            }
            return response;
        }
    }
}
