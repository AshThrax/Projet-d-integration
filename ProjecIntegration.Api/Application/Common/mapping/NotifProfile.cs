using Application.DTO;
using AutoMapper;
using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.mapping
{
    public class NotifProfile : Profile
    {
        protected NotifProfile()
        {
            CreateMap<AddAnnonceDto, Annonce>();
            CreateMap<Annonce, GetAnnonceDto>();
            CreateMap<UpdateNotificationDto,Annonce>();
        }
    }
}
