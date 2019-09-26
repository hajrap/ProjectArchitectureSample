using System.Threading.Tasks;
using NewWebPortal.ApplicationCore.Entities;

namespace NewWebPortal.ApplicationCore.Interfaces.Services
{
    public interface ISendMailService
    {
        bool SendMail(Email mail);
    }
}
