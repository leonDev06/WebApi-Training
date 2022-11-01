using Sidekick.Training.Model;
using Sidekick.Training.Providers;

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

        public async Task<bool> UpdateUserById(int id, string name, string email)
        {
            return await _userProvider.UpdateUserById(id, name, email);
        }

        public async Task<bool> DeleteUserById(int id)
        {
            return await _userProvider.DeleteUserById(id);
        }
    }
}
