using Framework.Core.Model;
using System.Collections.Generic;

namespace NotificationManagement.Models
{
    public class SubscriptionVm : IVM
    {
        public SubscriptionVm()
        {

        }
        public SubscriptionVm(int userId, IList<int> flgTyps)
        {
            UserId = userId;
            FlgTyps = flgTyps;
        }

        public SubscriptionVm(string endpoint, string p256dh, string auth, int userId)
        {
            Endpoint = endpoint;
            P256DH = p256dh;
            Auth = auth;
            UserId = userId;
        }
        public int Id { get; set; }
        public string Endpoint { get; set; }
        public string P256DH { get; set; }
        public string Auth { get; set; }
        public int UserId { get; set; }
        public IList<int> FlgTyps { get; set; }
    }
}
