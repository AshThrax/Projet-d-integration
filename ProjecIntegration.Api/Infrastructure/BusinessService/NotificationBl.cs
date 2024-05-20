using ApplicationAnnonce.Common.businessService;
using ApplicationAnnonce.Common.Repository;
using ApplicationAnnonce.DTO;
using AutoMapper;
using Domain.DataType;
using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureAnnonce.BusinessService
{
    public class NotificationBl : INotificationBl
    {

        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public NotificationBl(INotificationRepository notificationRepository, IMapper mapper)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public void CreateNotification(AddNotificationDto notification)
        {
            try
            {
                Notification notificationEntity = _mapper.Map<Notification>(notification);
                _notificationRepository.Insert(notificationEntity);
            }
            catch (Exception)
            {

            }

        }

        public async Task DeleteNotification(string notificationId)
        {
            try
            {
                Notification notification = await _notificationRepository.GetById(notificationId)
                                          ?? throw new NullReferenceException("il n'existe pas de reference ");

                _notificationRepository.Delete(notificationId);
            }
            catch (NullReferenceException)
            {
            }
            catch (Exception)
            {

            }

        }

        public async Task<NotificationDto> GetNotificationById(string id)
        {
            try
            {
                return _mapper.Map<NotificationDto>(await _notificationRepository.GetById(id))
                       ?? throw new NullReferenceException("null reference");
            }
            catch (Exception)
            {
                return new NotificationDto() { Id = id };
                throw;
            }
        }

        public async Task<Pagination<NotificationDto>> GetNotificationByUserId(string userId, int pageNumber)
        {
            Pagination<NotificationDto> notificationDtoPaginated;
            try
            {
                IEnumerable<Notification> getdata = await _notificationRepository.GetNotificationByUserId(userId);
                IEnumerable<NotificationDto> notificationDto = _mapper.Map<IEnumerable<NotificationDto>>(getdata);
                return notificationDtoPaginated = Pagination<NotificationDto>
                                                                     .ToPagedList(notificationDto.ToList(), pageNumber, 5);
            }
            catch (Exception)
            {
                return notificationDtoPaginated = Pagination<NotificationDto>.ToPagedList(new List<NotificationDto>(), pageNumber, 5);
            }
        }

        public async Task UpdateNotification(string notificationId, UpdateNotificationDto updtNotification)
        {
            try
            {
                Notification Getnotification = await _notificationRepository.GetById(notificationId)
                                          ?? throw new NullReferenceException("il n'existe pas de reference ");

                _notificationRepository.Update(notificationId, _mapper.Map<Notification>(updtNotification));
            }
            catch (Exception)
            {

            }
        }
    }
}
