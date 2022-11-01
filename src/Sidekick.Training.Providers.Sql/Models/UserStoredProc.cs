using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidekick.Training.Providers.Sql.Models
{
    public class UserStoredProc
    {
        public const string GetUserById = "usp_GetUserById";
        public const string UpdateUserById = "usp_UpdateUserById";
        public const string DeleteUserById = "usp_DeleteUserById";
        public const string CreateUser = "usp_CreateUser";
    }
}
