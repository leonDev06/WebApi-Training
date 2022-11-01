using Sidekick.Training.Model;

namespace Sidekick.Training.Services
{
    // This is the interface for the UserService. Implemented in UserService Class.
    // These are the tasks that's going to connect to the controller.
    // UserController -> UserService -> UserProvider -> SQLUserProvider -> Database
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> CreateUser(string name, string emai);
        Task<bool> UpdateUserById(int id, string name, string email);
        Task<bool> DeleteUserById(int id);
    }
}
