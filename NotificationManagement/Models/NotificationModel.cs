using System.Collections.Generic;

namespace push
{
    public class NotificationModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
        public IList<int> RecieversIds = new List<int>();
        public IList<string> Emails = new List<string>();
    }
}