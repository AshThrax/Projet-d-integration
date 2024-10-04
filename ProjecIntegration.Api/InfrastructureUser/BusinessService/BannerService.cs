using ApplicationUser.BusinessService;
using ApplicationUser.Common.IRepository;
using ApplicationUser.Dto;
using AutoMapper;
using Domain.Entity.UserEntity;
using Domain.Enum;
using Domain.ServiceResponse;

namespace InfrastructureUser.BusinessService
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _bannerRepository; 
        private readonly IMapper _mapper;

        public BannerService(IBannerRepository bannerRepository, IMapper mapper)
        {
            _bannerRepository = bannerRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// add a new banner for a user 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Imageressourcess"></param>
        /// <returns></retus
        public async Task<ServiceResponse<BannerDto>> AddBanner(string userId, string Imageressourcess)
        {
            ServiceResponse<BannerDto> response =new();
            try
            {
                BannerDto bannerDto = new BannerDto() 
                {
                    ImageRessource=Imageressourcess,
                    UserId=userId
                };
                Banner addBanner = _mapper.Map<Banner>(bannerDto);
                Banner Inserted =await _bannerRepository.Insert(addBanner);

                response.Data = _mapper.Map<BannerDto>(Inserted);
            }
            catch (Exception ex)
            {
                response.Errortype = Errortype.Bad;
                response.Message = $"une erreur est apparut :{ex.Message}";
            }
            return response;
        }
        /// <summary>
        /// make sur a banner exist for a user 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Imageressourcess"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<BannerDto>> HasBanner(string userId)
        {
            ServiceResponse<BannerDto> response = new();
            try
            {
                bool getBanner = await _bannerRepository.DoYouExist(x=>x.UserId==userId);
                if (getBanner)
                {
                    Banner getbanner = await _bannerRepository.Get(x => x.UserId == userId);
                    response.Data=new BannerDto() {Id=getbanner.Id,ImageRessource=getbanner.ImageRessource,UserId=getbanner.UserId };
                    response.Message="banner succesfully retrieve";
                }
                else
                {
                    response.Success = false;
                    response.Message = "banner Unsuccesfully retrieve";

                }
            }
            catch (Exception ex)
            {
                response.Errortype = Errortype.Bad;
                response.Message = $"An Error has occured :{ex.Message}";
            }
            return response;
        }
        /// <summary>
        /// update a banner
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Imageressourcess"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<BannerDto>> UpdateBanner(int bannerId, string ImageRessourcess)
        {
            ServiceResponse<BannerDto> response = new();
            try
            {
                bool Doexist =await _bannerRepository.DoYouExist(bannerId);
                if (!Doexist)
                {
                    throw new NullReferenceException("");
                }
                
                Banner toUpdated = await _bannerRepository.GetById(bannerId);
                toUpdated.ImageRessource = ImageRessourcess;
                await _bannerRepository.Update(bannerId, toUpdated);
                response.Data = _mapper.Map<BannerDto>(toUpdated);
                response.Message = "operation succesfull";
            }
            catch (Exception ex)
            {
                response.Errortype = Errortype.Bad;
                response.Message = $"une erreur est apparut :{ex.Message}";
            }
            return response;
        }
    }
}
