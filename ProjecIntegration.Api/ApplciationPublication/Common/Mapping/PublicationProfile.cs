using ApplciationPublication.Dto;
using AutoMapper;
using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplciationPublication.Common.Mapping
{
    public class PublicationProfile : Profile
    {
        protected PublicationProfile()
        {
            CreateMap<AddPublicationDto, Publication>();
            CreateMap<Publication,PublicationDto>();
            CreateMap<UpdatePublicationDto, Publication>();

            CreateMap<Post,PostDto>();
            CreateMap<RePost, RepostDto>();
           
        }
    }
}
