using Framework.Core.Model;
using System;
using System.Collections.Generic;

namespace NotificationManagement.Models
{
    public class NotificationVm : IVM
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public string Link { get; set; }
        public int NotReadCount { get; set; }
        public IList<int> RecieversIds { get; set; }
        public int FlgType { get; set; }
    }
}
