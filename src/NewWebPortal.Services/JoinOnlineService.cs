using NewWebPortal.ApplicationCore.Entities;
using NewWebPortal.ApplicationCore.Interfaces.Infrastructure;
using NewWebPortal.ApplicationCore.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebPortal.Services
{
    public class JoinOnlineService : IJoinOnlineService
    {
        private readonly IAsyncRepository<User> _userRepository;

        public JoinOnlineService(IAsyncRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> InsertAsync(User user)
        {

            return (await _userRepository.InsertAsync(user));
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return (await _userRepository.SelectAllAsync()).ToList();
        }
    }
}
