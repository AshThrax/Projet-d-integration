using ApplicationUser.Dto;
using ApplicationUser.Dto.FeedBack;
using ApplicationUser.Dto.Follow;
using ApplicationUser.Dto.Signalement;
using ApplicationUser.Dto.SignalementType;
using AutoMapper;
using Domain.Entity.PublicationEntity.Modération;
using Domain.Entity.UserEntity;
using Domain.Entity.UserEntity.FeedBack;

namespace ApplicationUser.Common.Mapping
{
    public class Automapper : Profile
    {
        public Automapper() {
            CreateMap<Feedback, FeedBackDto>();
            CreateMap<FeedBackDto, Feedback>();
            CreateMap<AddFeedBackDto, Feedback>();
            CreateMap<UpdateFeedbackDto, Feedback>();

            //Favorit----------------------------
          
            //signalement------------------------
            CreateMap<Signalement, GetSignalementDto>();
            CreateMap<AddSignalementDto, Signalement>();
            CreateMap<UpdateSignalementDto, Signalement>();
            //signalementType--------------------
            CreateMap<SignalementType,GetSignalementTypeDto>();
            CreateMap<AddSignalementTypeDto, SignalementType>();
            CreateMap<UpdateSignalementTypeDto, SignalementType>();
           
            //Follow-----------------------------
            CreateMap<Follow, GetFollowerDto>();
            CreateMap<AddFollowdto, Follow>();
            CreateMap<UpdateFollowDto, Follow>();
            //User-------------------------------
            CreateMap<Banner, BannerDto>();
            CreateMap<BannerDto, Banner>();

        }
    }
}
