using Sidekick.Training.Model;

namespace Sidekick.Training.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> CreateUser(string name, string emai);
        Task<bool> UpdateUserById(int id, string name, string email);
        Task<bool> DeleteUserById(int id);
    }
}
