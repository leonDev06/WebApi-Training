using Sidekick.Training.Model;

namespace Sidekick.Training.Providers.InMemory
{
    public class InMemoryUserProvider : IUserProvider
    {
        private static Dictionary<int, User> _inMemoryUser = new Dictionary<int, User>();
        private static int _currentId = 1;

        public async Task<User> CreateUser(User user)
        {
            user.Id = ++_currentId;
            _inMemoryUser.Add(_currentId, user);
            return user;
        }

        public async Task<User?> GetUserById(int id)
        {
            return _inMemoryUser.ContainsKey(id) ? _inMemoryUser[id] : null;
        }
    }
}