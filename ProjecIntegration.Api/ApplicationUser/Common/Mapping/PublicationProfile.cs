using ApplicationAnnonce.DTO;
using ApplicationPublication.Dto;
using AutoMapper;
using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Common.Mapping
{
    public class PublicationProfile : Profile
    {
        public PublicationProfile()
        {
            CreateMap<AddPublicationDto, Publication>().ReverseMap();
            CreateMap<Publication, PublicationDto>().ReverseMap();
            CreateMap<UpdatePublicationDto, Publication>().ReverseMap();

            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<AddPostDto, Post>().ReverseMap();
            CreateMap<Repost, RepostDto>().ReverseMap();
            CreateMap<UpdatePostDto,Post>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
