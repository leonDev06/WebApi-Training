using Sidekick.Training.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidekick.Training.Providers
{
    public interface IUserProvider
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserById(int id);
        Task<bool> UpdateUserById(int id, String name, string email);
        Task<bool> DeleteUserById(int id);

    }
}
