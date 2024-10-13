using ApplicationTheather.BusinessService.Catalogue;
using ApplicationTheather.Common.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;

namespace DataInfraTheather.BusinessService
{
    public class BusinessCatalogue : IBusinessCatalogue
    {
        private readonly IPieceRepository _pieceRepository;
        private readonly ICatalogueRepository _catalogueRepository;
        private readonly ICataloguePieceRepository _catPieceRepository;
        private readonly IMapper _mapper;

        public BusinessCatalogue(
            IPieceRepository pieceRepository,
            ICatalogueRepository catalogueRepository,
            ICataloguePieceRepository catPieceRepository,
            IMapper mapper)
        {
            _pieceRepository = pieceRepository;
            _catalogueRepository = catalogueRepository;
            _catPieceRepository = catPieceRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CatalogueDto>> AddPieceToCatalogue(int catalogueId, int PieceId)
        {
            ServiceResponse<CatalogueDto> response = new();
            try
            {
                Catalogue? getcatalogue = await _catalogueRepository.GetById(catalogueId) ?? throw new NullReferenceException();

                Piece? getPiece = await _pieceRepository.GetById(PieceId) ?? throw new NullReferenceException();

                CataloguePiece addcataloguePiece = new CataloguePiece
                {
                    Catalogue = getcatalogue,
                    CatalogueId = catalogueId,
                    Piece = getPiece,
                    PieceId = PieceId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,

                };
                await _catPieceRepository.Insert(addcataloguePiece);
                response.Success = true;
                response.Message = "Opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "un probléme a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<CatalogueDto>> CreateCatalogue(AddCatalogueDto addCatalogue)
        {
            ServiceResponse<CatalogueDto> response = new();
            try
            {
                Catalogue newCatalogue = _mapper.Map<Catalogue>(addCatalogue);
                newCatalogue.CreatedDate = DateTime.Now;
                Catalogue converted = await _catalogueRepository.Insert(newCatalogue);
                response.Data = _mapper.Map<CatalogueDto>(converted);
                response.Success = true;
                response.Message = "Opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "un probléme a eu lieu lors de l'opération";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<CatalogueDto>> DeleteCatalogue(int catalogueId)
        {
            ServiceResponse<CatalogueDto> response = new();
            try
            {
                Catalogue getCatalogue = await _catalogueRepository.GetById(catalogueId);
                if (getCatalogue != null)
                {
                    await _catalogueRepository.Delete(catalogueId);
                    response.Success = true;
                    response.Message = "Opération réussi";
                    response.Errortype = Domain.Enum.Errortype.Good;

                }
                else
                {
                    response.Success = false;
                    response.Message = "une erreur a eu lieu";
                    response.Errortype = Domain.Enum.Errortype.Null;

                }

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<CatalogueDto>>> GetAllCatalogue()
        {
            ServiceResponse<IEnumerable<CatalogueDto>> response = new();
            try
            {
                response.Data = _mapper.Map<IEnumerable<CatalogueDto>>(await _catalogueRepository.GetAll());
                response.Success = true;
                response.Message = "Opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Domain.Enum.Errortype.Bad;
                response.Data = Enumerable.Empty<CatalogueDto>();
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<CatalogueDto>>> GetCatalogueByComplexe(int complexeId)
        {
            ServiceResponse<IEnumerable<CatalogueDto>> response = new();
            try
            {

                IEnumerable<Catalogue> getCatalogueByComplexeId = await _catalogueRepository.GetCatalogueFromComplexe(complexeId);
                response.Data = _mapper.Map<IEnumerable<CatalogueDto>>(getCatalogueByComplexeId);
                response.Success = true;
                response.Message = "Opération réussi";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Domain.Enum.Errortype.Bad;
                response.Data = Enumerable.Empty<CatalogueDto>();
            }
            return response;
        }

        public async Task<ServiceResponse<CatalogueDto>> GetCatalogueById(int catalogueId)
        {
            ServiceResponse<CatalogueDto> response = new();
            try
            {
                Catalogue getCatalogue = await _catalogueRepository.GetById(catalogueId);

                response.Data = _mapper.Map<CatalogueDto>(getCatalogue);
                response.Success = true;
                response.Message = "Récupération catalogue Successfull";
                response.Errortype = Domain.Enum.Errortype.Bad;

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur a eu lieu";
                response.Errortype = Domain.Enum.Errortype.Bad;
                response.Data = null;
            }
            return response;
        }

        public async Task<ServiceResponse<CatalogueDto>> RemovePieceToCataogue(int catalogueId, int PieceId)
        {
            ServiceResponse<CatalogueDto> response = new();
            try
            {
                await _catPieceRepository.RemovePieceFromcatalogue(catalogueId, PieceId);
                response.Success = true;
                response.Message = "opération Réussi, la pièce a été correctement retiré du catalogue";
                response.Errortype = Domain.Enum.Errortype.Good;

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "une erreur est survenu";
                response.Errortype = Domain.Enum.Errortype.Good;
            }
            return response;
        }

        public async Task<ServiceResponse<CatalogueDto>> UpdateCatalogue(int catalogueId, UpdateCatalogueDto updtCatalogue)
        {
            ServiceResponse<CatalogueDto> response = new();
            try
            {
                Catalogue getCatalogue = await _catalogueRepository.GetById(catalogueId);

                if (getCatalogue != null)
                {
                    Catalogue convertCatalogue = _mapper.Map<Catalogue>(updtCatalogue);
                    getCatalogue.Description = updtCatalogue.Description;
                    getCatalogue.Name = updtCatalogue.Name;
                    getCatalogue.UpdatedDate = DateTime.Now;

                    await _catalogueRepository.Update(catalogueId, getCatalogue);
                    response.Success = true;
                    response.Message = "mise a jour réussi";
                    response.Errortype = Domain.Enum.Errortype.Good;
                }
                else
                {
                    response.Success = false;
                    response.Message = "la mise a jour a Echoué";
                    response.Errortype = Domain.Enum.Errortype.Good;
                }
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Une Erreur a eu lieu";
                response.Errortype = Domain.Enum.Errortype.Bad;
            }
            return response;
        }
    }
}
