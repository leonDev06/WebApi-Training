using Sidekick.Training.Model;

namespace Sidekick.Training.Providers.InMemory
{
    // This is an InMemoryUserProvider. This emulates the events of actual Requests and Responses in the memory.
    // This is used as a test and is currently DETACHED from this WebApi.
    public class InMemoryUserProvider
    {
        private static Dictionary<int, User> _inMemoryUser = new Dictionary<int, User>();
        private static int _currentId = 0;

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