using NewWebPortal.ApplicationCore.Entities;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace NewWebPortal.ApplicationCore.Interfaces.Services
{
    public interface IJoinOnlineService
    {
        Task<User> InsertAsync(User user);

        Task<List<User>> GetAllUsersAsync();
    }
}
