using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.Interfaces.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.Entity.publicationEntity;
using Domain.Entity.TheatherEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _mapper= mapper;    
        }

        public async Task AddPieceToCatalogue(int catalogueId, int PieceId)
        {
            try
            {
                Catalogue? getcatalogue =await _catalogueRepository.GetById(catalogueId) ?? throw new NullReferenceException();

                Piece? getPiece =await _pieceRepository.GetById(PieceId) ?? throw new NullReferenceException();
                
                CataloguePiece addcataloguePiece= new CataloguePiece 
                {  
                    Catalogue=getcatalogue,
                    CatalogueId = catalogueId,
                    Piece=getPiece,
                    PieceId = PieceId,
                    CreatedDate=DateTime.Now,
                    UpdatedDate=DateTime.Now,

                };

                _catPieceRepository.Insert(addcataloguePiece);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CreateCatalogue(AddCatalogueDto addCatalogue)
        {
            try
            {
               Catalogue newCatalogue=_mapper.Map<Catalogue>(addCatalogue);

               _catalogueRepository.Insert(newCatalogue);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteCatalogue(int catalogueId)
        {
            try
            {
                Catalogue getCatalogue = await _catalogueRepository.GetById(catalogueId);
                if (getCatalogue != null)
                {
                   await _catalogueRepository.Delete(catalogueId);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CatalogueDto>> GetCatalogueByComplexe(int complexeId)
        {
            try
            {

                IEnumerable<Catalogue> getCatalogueByComplexeId= await _catalogueRepository.GetCatalogueFromComplexe(complexeId);
                return _mapper.Map<IEnumerable<CatalogueDto>>(getCatalogueByComplexeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CatalogueDto> GetCatalogueById(int catalogueId)
        {
            try
            {
                Catalogue getCatalogue = await _catalogueRepository.GetById(catalogueId);
                
                return _mapper.Map<CatalogueDto>(getCatalogue);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemovePieceToCataogue(int catalogueId, int PieceId)
        {
            try
            {
                await _catPieceRepository.RemovePieceFromcatalogue(catalogueId, PieceId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCatalogue(int catalogueId, UpdateCatalogueDto updtCatalogue)
        {
            try
            {
                Catalogue getCatalogue =await _catalogueRepository.GetById(catalogueId);

                if (getCatalogue != null)
                {
                    Catalogue convertCatalogue =_mapper.Map<Catalogue>(updtCatalogue);
                    _catalogueRepository.Update(catalogueId,convertCatalogue);
                }
               

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
