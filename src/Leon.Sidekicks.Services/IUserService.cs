﻿
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
        Task<User> CreateUser(string name, string emai);
        Task<bool> UpdateUserById(int id, String name, string email);
        Task<bool> DeleteUserById(int id);
    }
}
