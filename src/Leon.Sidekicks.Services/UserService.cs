using Leon.Sidekicks.Services;
using Sidekick.Training.Model;
using Sidekick.Training.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidekick.Training.Services
{
    public class UserService : IUserService
    {
        private readonly IUserProvider _userProvider;

        public UserService(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userProvider.GetUserById(id);
        }

        public async Task<User> CreateUser(string name, string email)
        {
            return await _userProvider.CreateUser(new User(name, email));
        }
    }
}
