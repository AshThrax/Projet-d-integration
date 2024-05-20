using ApplicationAnnonce.DTO;
using AutoMapper;
using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAnnonce.Common.mapping
{
    public class NotifProfile : Profile
    {
        public NotifProfile()
        {
            CreateMap<AddAnnonceDto, Annonce>().ReverseMap();
            CreateMap<Annonce, GetAnnonceDto>().ReverseMap();
            CreateMap<UpdateNotificationDto, Annonce>().ReverseMap();
            //--------------------------------------------
            CreateMap<AddNotificationDto, Notification>().ReverseMap();
            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<UpdateNotificationDto, Notification>().ReverseMap();

        }
    }
}
