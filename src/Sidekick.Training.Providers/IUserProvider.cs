using Sidekick.Training.Model;

namespace Sidekick.Training.Providers
{
    // This is the interface for UserProviders. This provides the tasks that would be requested as part of the business logic.
    public interface IUserProvider
    {
        // Expected requestable tasks.
        Task<User> CreateUser(User user);
        Task<User> GetUserById(int id);
        Task<bool> UpdateUserById(int id, string name, string email);
        Task<bool> DeleteUserById(int id);
    }
}