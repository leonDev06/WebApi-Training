using Sidekick.Training.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leon.Sidekicks.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
    }
}
