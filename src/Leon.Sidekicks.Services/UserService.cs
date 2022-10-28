using Leon.Sidekicks.Services;
using Sidekick.Training.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidekick.Training.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserById(int id)
        {
            Console.WriteLine(id);
            return new User()
            {
                Id = id,
            };
        }
    }
}
