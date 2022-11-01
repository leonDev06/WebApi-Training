using Dapper;
using Microsoft.Extensions.Options;
using Sidekick.Training.Model;
using Sidekick.Training.Providers.Sql.Models;
using System.Data;
using System.Data.SqlClient;

namespace Sidekick.Training.Providers.Sql
{
    public class SqlUserProvider : IUserProvider
    {
        private readonly SqlConfig _sqlConfig;

        public SqlUserProvider(IOptions<SqlConfig> sqlConfig)
        {
            _sqlConfig = sqlConfig.Value;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_sqlConfig.ConnectionString);
        }


        public async Task<User> CreateUser(User user)
        {
            using (var conn = GetConnection())
            {
                var userId = await conn.QueryFirstOrDefaultAsync<int>(
                    UserStoredProc.CreateUser, // stored procedure
                    new
                    {
                        // parameters
                        name = user.Name,
                        email = user.Email
                    },
                    commandType: CommandType.StoredProcedure);
                user.Id = userId;

            }
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            using (var conn = GetConnection())
            {
                var user = await conn.QueryFirstOrDefaultAsync<User>(
                    UserStoredProc.GetUserById, // stored procedure
                    new
                    {
                        // parameters
                        id = id
                    },
                    commandType: CommandType.StoredProcedure); ;
                
                return user;
            }
        }

        public async  Task<bool> UpdateUserById(int id, string name, string email)
        {
            using (var conn = GetConnection())
            {
                var affectedRows = await conn.ExecuteAsync(
                    UserStoredProc.UpdateUserById, // stored procedure
                    new
                    {
                        // parameters
                        id = id,
                        name = name,
                        email = email
                    },
                    commandType: CommandType.StoredProcedure); ;
                return affectedRows != 0;
            }
        }

        public async Task<bool> DeleteUserById(int id)
        {
            using (var conn = GetConnection())
            {
                var affectedRows = await conn.ExecuteAsync(
                    UserStoredProc.DeleteUserById, // stored procedure
                    new
                    {
                        // parameters
                        id = id
                        
                    },
                    commandType: CommandType.StoredProcedure);
                return affectedRows != 0;
            }
        }
    }
}