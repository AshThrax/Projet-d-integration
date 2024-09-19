using ApplicationUser.Dto.Favorit;
using ApplicationUser.Dto.FeedBack;
using ApplicationUser.Dto.Follow;
using ApplicationUser.Dto.Signalement;
using ApplicationUser.Dto.SignalementType;
using ApplicationUser.Dto.UserDetails;
using AutoMapper;
using Domain.Entity.PublicationEntity.Modération;
using Domain.Entity.UserEntity;
using Domain.Entity.UserEntity.FeedBack;
using Domain.Entity.UserEntity.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CreateMap<Favorit, FavoritDto>().ReverseMap();
            CreateMap<FavoritDto, Favorit>();
            CreateMap<AddFavoritDto, Favorit>();
            CreateMap<UpdateFavoritDto, Favorit>();
            //signalement------------------------
            CreateMap<Signalement, GetSignalementDto>();
            CreateMap<AddSignalementDto, Signalement>();
            CreateMap<UpdateSignalementDto, Signalement>();
            //signalementType--------------------
            CreateMap<SignalementType,GetSignalementTypeDto>();
            CreateMap<AddSignalementTypeDto, SignalementType>();
            CreateMap<UpdateSignalementTypeDto, SignalementType>();
            //Userdetails------------------------
            CreateMap<UserDetails, GetUserDetailsDto>();
            CreateMap<AddUserDetailDto, UserDetails>();
            CreateMap<UpdateUserdetailsDto, UserDetails>();
            //Follow-----------------------------
            CreateMap<Follow, GetFollowerDto>();
            CreateMap<AddFollowdto, Follow>();
            CreateMap<UpdateFollowDto, Follow>();
            //User-------------------------------
           

        }
    }
}
