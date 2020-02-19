using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationManagement.Services
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string subject, string message, IList<string> emails);
    }
}
