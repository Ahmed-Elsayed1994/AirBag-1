using CoreData.Common.Entities.Notifications;
using Framework.Core.BaseModel;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.UOW;
using NotificationManagement.Models;
using push;
using System;
using System.Collections.Generic;
using System.Linq;
using User.BAL.Services;

namespace NotificationManagement.Services
{
    public class NotificationService : BaseService<Notification, NotificationVm>, INotificationService
    {
        private readonly IUsersService _usersService;
        public NotificationService(IRepository<Notification> repository,
            IUnitOfWork unitOfWork, IUsersService usersService) : base(repository, unitOfWork)
        {
            _usersService = usersService;
        }
        public override NotificationVm MapEntityToModel(Notification entity)
        {
            return new NotificationVm()
            {
                Id = entity.Id,
                Date = entity.Date,
                IsRead = entity.IsRead,
                Link = entity.Link,
                Message = entity.Message,
                SenderId = entity.SenderId,
                Title = entity.Title,
                FlgType = entity.FlgType
            };
        }

        public override Notification MapModelToEntity(NotificationVm model)
        {
            var entity = _repository.GetById(model.Id);
            if (entity == null)
            {
                var notification = new Notification()
                {
                    Id = model.Id,
                    Date = DateTime.UtcNow,
                    IsRead = model.IsRead,
                    Link = model.Link,
                    Message = model.Message,
                    SenderId = model.SenderId,
                    Sender = _usersService.GetEntityById(model.SenderId),
                    FlgType = model.FlgType
                };

                notification.Recievers = MapUsersToRecievers(model.RecieversIds, notification);
                return notification;
            }
            return entity;
        }
        private IList<NotificationUsers> MapUsersToRecievers(IList<int> usersIds, Notification notification)
        {
            var userUnits = new List<NotificationUsers>();
            var users = _usersService.GetUsersByIds(usersIds);
            if (users != null && users.Count > 0)
                foreach (var item in users)
                {
                    userUnits.Add(new NotificationUsers()
                    {
                        Reciever = item,
                        Notification = notification
                    });
                }
            return userUnits;
        }
        protected override Func<Notification, IVM> FuncToVM()
        {
            return (a) => new NotificationVm()
            {
                Id = a.Id,
                Date = a.Date,
                IsRead = a.IsRead,
                Link = a.Link,
                Message = a.Message,
                SenderId = a.SenderId,
                Title = a.Title,
                FlgType = a.FlgType
            };
        }

        public HeaderNotificationVm GetNotificationsByUser(int userId)
        {
            IList<NotificationVm> notificationVms = new List<NotificationVm>();
            var notifications = _repository.Where(a => a.Recievers.Any(b => b.Reciever.Id == userId)).OrderByDescending(a => a.Id).ToList();
            if (notifications == null || notifications.Count == 0)
                return null;
            foreach (var item in notifications)
            {
                notificationVms.Add(MapEntityToModel(item));
            }
            return new HeaderNotificationVm()
            {
                Notifications = notificationVms,
                NotReadCount = notifications.Where(a => a.IsRead == false).Count()
            };
        }

        public void MakeAsRead(int userId)
        {
            var notifications = _repository.Where(a => a.Recievers.Any(b => b.Reciever.Id == userId) && a.IsRead == false).OrderByDescending(a => a.Id).ToList();
            ; if (notifications == null || notifications.Count == 0)
                return;
            foreach (var item in notifications)
            {
                item.IsRead = true;
                _repository.Update(item);
            }
        }
        public void SaveNotification(NotificationModel notificationModel,
            int sigInUserId, IList<int> recieversIds, int flgType)
        {
            Insert(new NotificationVm()
            {
                Date = DateTime.UtcNow,
                IsRead = false,
                Message = notificationModel.Message,
                Title = notificationModel.Title,
                SenderId = sigInUserId,
                RecieversIds = recieversIds,
                Link = notificationModel.Link,
                FlgType = flgType // email or push notification or sms
            });
        }
    }
}
