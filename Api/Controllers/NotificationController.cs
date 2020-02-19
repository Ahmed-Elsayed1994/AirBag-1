using Framework.Core.UOW;
using NotificationManagement.Models;
using NotificationManagement.Services;
using push;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using WebPush;
using Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using CoreData.Common.Entities.Notifications;
using Framework.Helpers;
using System.Threading.Tasks;

namespace push_notification_angular_dotnet_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : BaseAPIController<INotificationService, Notification, NotificationVm>
    {
        private readonly ISendNotificationService _sendNotificationService;
        private readonly INotificationManagementService _notificationManagementService;



        public NotificationController(ISendNotificationService sendNotificationService,
            IUnitOfWork unitOfWork,
            INotificationService notificationService,
            INotificationManagementService notificationManagementService) : base(unitOfWork, notificationService)
        {
            _sendNotificationService = sendNotificationService;
            _notificationManagementService = notificationManagementService;
        }
        public static List<PushSubscription> Subscriptions { get; set; } = new List<PushSubscription>();

        [HttpPost("subscribe")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Subscribe([FromBody] PushSubscription sub)
        {
            var claimsIdentity = Request.HttpContext.User.Identity as ClaimsIdentity;
            var userId = "2";
            SubscriptionVm subscriptionVm = new SubscriptionVm(sub.Endpoint, sub.P256DH, sub.Auth, int.Parse(userId));
            _notificationManagementService.SubscribeUser(subscriptionVm);
            await _unitOfWork.Save();
        }

        [HttpPost("unsubscribe")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Unsubscribe([FromBody] PushSubscription sub)
        {
            _notificationManagementService.UnSubscribe(new SubscriptionVm() { Endpoint = sub.Endpoint });
            await _unitOfWork.Save();
        }

        [HttpPost("broadcast")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Broadcast([FromBody] NotificationModel message, [FromServices] VapidDetails vapidDetails)
        {
            var claimsIdentity = Request.HttpContext.User.Identity as ClaimsIdentity;
            var userId = "2";
            await _sendNotificationService.SendMessage(message, vapidDetails, int.Parse(userId), message.UserId);
            await _unitOfWork.Save();
        }
        [HttpGet("GetByUser/{userId}")]
        public IActionResult GetByUser(int userId)
        {
            //var val = "sico".L(_localizer);
            var single = _service.GetNotificationsByUser(userId);
            if (single == null) return ResCreateNotFound();
            return ResCreateOk(single);
        }

        [HttpGet("MakeAsRead/{userId}")]
        public async Task<IActionResult> MakeAsRead(int userId)
        {
            _service.MakeAsRead(userId);
            await _unitOfWork.Save();
            return Ok();
        }
    }
}
