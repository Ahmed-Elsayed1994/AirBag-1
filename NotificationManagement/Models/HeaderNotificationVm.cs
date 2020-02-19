using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationManagement.Models
{
    public class HeaderNotificationVm
    {
        public IList<NotificationVm> Notifications;
        public int NotReadCount { get; set; }
    }
}
