using NewWebPortal.ApplicationCore.Entities;
using NewWebPortal.ApplicationCore.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace NewWebPortal.Services
{
    public class SendMailService : ISendMailService
    {
        public bool SendMail(Email mail)
        {
                return !string.IsNullOrEmpty(mail.ToEmail) && !string.IsNullOrEmpty(mail.Subject)
                       && !string.IsNullOrEmpty(mail.Message);
        }
    }
}
