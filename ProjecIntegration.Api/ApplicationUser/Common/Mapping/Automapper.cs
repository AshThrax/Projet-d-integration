using ApplicationUser.Dto.Favorit;
using ApplicationUser.Dto.FeedBack;
using AutoMapper;
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
        }
    }
}
