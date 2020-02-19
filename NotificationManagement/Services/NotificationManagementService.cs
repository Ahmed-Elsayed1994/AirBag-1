using CoreData.Common.Entities.Notifications;
using Framework.Core.BaseModel;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.UOW;
using NotificationManagement.Models;
using NotificationManagement.Models.Enum;
using push;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationManagement.Services
{
    public class NotificationManagementService : BaseService<Subscriptions, SubscriptionVm>, INotificationManagementService
    {
        public NotificationManagementService(IRepository<Subscriptions> repository,
            IUnitOfWork unitOfWork)
        : base(repository, unitOfWork)
        {
        }



        public override SubscriptionVm MapEntityToModel(Subscriptions entity)
        {
            return new SubscriptionVm()
            {
                P256DH = entity.P256DH,
                Endpoint = entity.Endpoint,
                Auth = entity.Auth,
                UserId = entity.UserId
            };
        }

        public override Subscriptions MapModelToEntity(SubscriptionVm model)
        {
            return new Subscriptions()
            {
                Endpoint = model.Endpoint,
                Auth = model.Auth,
                P256DH = model.P256DH,
                User = _unitOfWork.Users.GetById(model.UserId)
            };
        }

        public void SubscribeUser(SubscriptionVm subscription)
        {
            Insert(subscription);
        }

        public override Subscriptions Insert(SubscriptionVm model)
        {
            var entity = new Subscriptions();
            if (model.FlgTyps.Contains((int)NotificationType.PushNotification))
            {
                entity = base.Insert(model);
            }
            if (model.FlgTyps.Contains((int)NotificationType.Email))
            {
                var user = _unitOfWork.Users.GetById(model.UserId);
                user.UserNotificationTypes.Add(new UserNotificationType()
                {
                    FlgNotificationType = (int)NotificationType.Email
                });
            }
            return entity;
        }
        protected override Func<Subscriptions, IVM> FuncToVM()
        {
            return (entity) => new SubscriptionVm()
            {
                P256DH = entity.P256DH,
                Endpoint = entity.Endpoint,
                Auth = entity.Auth,
                UserId = entity.UserId
            };
        }

        public void UnSubscribe(SubscriptionVm model)
        {
            if (model.FlgTyps.Contains((int)NotificationType.PushNotification))
            {
                Subscriptions entity = ValidateDelete(model);
                if (_unitOfWork.SaveResult.Errors.Count > 0 || entity == null)
                    return;
                _repository.Delete(entity);
            }
            if (model.FlgTyps != null && model.FlgTyps.Count > 0)
            {
                if (model.FlgTyps.Contains((int)NotificationType.PushNotification))
                {
                    var match = _repository.Where(a => a.Endpoint == model.Endpoint).FirstOrDefault();
                    if (match == null)
                        AddError(CommonErrors.NOT_FOUND);
                    _repository.Delete(match);
                }
                if (model.FlgTyps.Contains((int)NotificationType.Email))
                {
                    var user = _unitOfWork.Users.GetById(model);
                    if (user.UserNotificationTypes.Where(a => a.FlgNotificationType == (int)NotificationType.Email).Count() == 0)
                        AddError(CommonErrors.NOT_FOUND);
                    var notificationType = user.UserNotificationTypes.Where(a => a.FlgNotificationType == (int)NotificationType.Email).FirstOrDefault();
                    user.UserNotificationTypes.Remove(notificationType);
                }
            }

        }
        public IList<SubscriptionVm> GetSubscriptions(IList<int> userIds)
        {
            var list = _repository.Where(a => userIds.Contains(a.UserId)).ToList();
            IList<SubscriptionVm> subscriptions = new List<SubscriptionVm>();
            foreach (var item in list)
            {
                subscriptions.Add(MapEntityToModel(item));
            }
            return subscriptions;
        }

        public void GetRecievers(ref IList<int> emailRecievers,
          ref IList<int> pushNotificationRecievers, ref IList<string> userEmails, NotificationModel notificationModel)
        {
            for (int i = 0; i < notificationModel.RecieversIds.Count; i++)
            {
                var user = _unitOfWork.Users.GetById(notificationModel.RecieversIds[i]);
                var userNotificationsType = user.UserNotificationTypes.Select(a => a.FlgNotificationType).ToList();
                if (userNotificationsType.Contains((int)NotificationType.Email)) // Email
                {
                    userEmails.Add(user.Email);
                    emailRecievers.Add(user.Id);
                }
                if (userNotificationsType.Contains((int)NotificationType.PushNotification)) // push notification
                {
                    pushNotificationRecievers.Add(user.Id);
                }
            }
        }

    }
}
