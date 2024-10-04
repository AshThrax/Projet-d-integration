using ApplicationTheather.BusinessService;
using ApplicationTheather.Common.IRepository;
using ApplicationTheather.DTO;
using AutoMapper;
using Domain.DataType;
using Domain.Entity.TheatherEntity;
using Domain.ServiceResponse;

namespace DataInfraTheather.BusinessService
{
    public class BusinessFavoris : IBusinessFavoris
    {
        private readonly IMapper _mapper;
        private readonly IFavorisrepository _favorisrepository;
        private readonly IPieceRepository _pieceRepository;
        public BusinessFavoris(IMapper mapper, IFavorisrepository favorisrepository, IPieceRepository pieceRepository)
        {
            _mapper = mapper;
            _favorisrepository = favorisrepository;
            _pieceRepository = pieceRepository;
        }

        public async Task<ServiceResponse<FavorisDto>> AddToFavoris(int favorisId,int pieceId)
        {
            ServiceResponse<FavorisDto> response = new ServiceResponse<FavorisDto>();
            try
            {
                bool DoIexist = await _favorisrepository.DoYouExist(favorisId);
                if (!DoIexist)
                {
                    throw new ArgumentException();
                }
                Favoris getFavorisEntity= await _favorisrepository.GetById(favorisId);
                Piece GetPieceToAdd = await _pieceRepository.GetById(pieceId);
                if (GetPieceToAdd != null)
                {
                    if (getFavorisEntity.PieceFavorite == null)
                    {
                        getFavorisEntity.PieceFavorite = new List<Piece>();    
                    }
                    getFavorisEntity.PieceFavorite.Add(GetPieceToAdd);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
        public async Task<ServiceResponse<FavorisDto>> AddToFavoris(string userId, int pieceId)
        {
            ServiceResponse<FavorisDto> response = new ServiceResponse<FavorisDto>();
            try
            {
                bool DoIexist = await _favorisrepository.DoYouExist(x=>x.UserId==userId);
                if (!DoIexist)
                {
                    throw new ArgumentException();
                }
                Favoris getFavorisEntity = await _favorisrepository.Get(x=>x.UserId==userId);
                Piece GetPieceToAdd = await _pieceRepository.GetById(pieceId);
                if (GetPieceToAdd != null)
                {
                    if (getFavorisEntity.PieceFavorite == null)
                    {
                        getFavorisEntity.PieceFavorite = new List<Piece>();
                    }
                    getFavorisEntity.PieceFavorite.Add(GetPieceToAdd);
                    await _favorisrepository.Update(getFavorisEntity.Id,getFavorisEntity);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
        public async Task<ServiceResponse<FavorisDto>> CreateFavoris(string userId)
        {
            ServiceResponse<FavorisDto> response = new ServiceResponse<FavorisDto>();
            try
            {
                Favoris createfavoris = new Favoris()
                {
                    CreatedDate = DateTime.Now,
                    PieceFavorite = new List<Piece>(),
                    UpdatedDate = DateTime.Now,
                    UserId = userId
                };
                _= await _favorisrepository.Insert(createfavoris);
                response.Success = true;
                response.Message = "favoris created";
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ServiceResponse<FavorisDto>> DeleteFromFavoris(int favorisId, int pieceid)
        {
            ServiceResponse<FavorisDto> response = new ServiceResponse<FavorisDto>();
            try
            {
                bool DoIexist = await _favorisrepository.DoYouExist(favorisId);
                if (!DoIexist)
                {
                    throw new ArgumentException();
                }
                Favoris getFavorisEntity = await _favorisrepository.GetById(favorisId);
                if (getFavorisEntity.PieceFavorite !=null)
                {
                    if (getFavorisEntity.PieceFavorite == null)
                    {
                        getFavorisEntity.PieceFavorite = new List<Piece>();
                    }
                    getFavorisEntity.PieceFavorite.RemoveAll(x=>x.Id==pieceid);
                }
                response.Success = true;
                response.Message = "Successfully deleted from the favorite";
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<Pagination<PieceDto>> PaginateFavoris(string userId, int page)
        {
            try
            {
                Favoris favoris =await _favorisrepository.Get(x=>x.UserId==userId);
                favoris = await _favorisrepository.GetById(favoris.Id, x => x.PieceFavorite);
                Pagination<PieceDto> pagination = Pagination<PieceDto>.ToPagedList(_mapper.Map<List<PieceDto>>(favoris.PieceFavorite), page, 5);
                return pagination;
            }
            catch (Exception)
            {

                return new Pagination<PieceDto>(new List<PieceDto>(),page,0);
            }
        }
    }
}
