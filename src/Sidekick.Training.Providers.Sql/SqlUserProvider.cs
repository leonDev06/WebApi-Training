using Dapper;
using Microsoft.Extensions.Options;
using Sidekick.Training.Model;
using Sidekick.Training.Providers.Sql.Models;
using System.Data;
using System.Data.SqlClient;

namespace Sidekick.Training.Providers.Sql
{
    /* This class initiates and holds the CONNECTION to the SQL DATABASE.
    *  This implements the IUserProvider Interface and the business logic functions.
    *  This class implements the executable TASKS of what happens at a certain request with its direct connection to the DATABASE.
    *  This acts as the service provider for the requested services.
    */

    public class SqlUserProvider : IUserProvider
    {
        // SQL configuration holding the ConnectionString
        private readonly SqlConfig _sqlConfig;

        // CONSTRUCTORS
        public SqlUserProvider(IOptions<SqlConfig> sqlConfig)
        {
            // Initialize the SQLConfig value
            _sqlConfig = sqlConfig.Value;
        }

        // Default Constructor
        public SqlUserProvider()
        {

        }
        // END OF CONSTRUCTORS


        private SqlConnection GetConnection()
        {
            // Connect to the SQL database
            return new SqlConnection(_sqlConfig.ConnectionString);
        }


        public async Task<User> CreateUser(User user)
        {
            // For creating new user

            // Connect to the database to execute task
            using (SqlConnection conn = GetConnection())
            {
                // Initialize Query
                // Define the type of the Query (Single-row query typed as int, to accomodate the storedProc output)
                int userId = await conn.QueryFirstOrDefaultAsync<int>(
                    UserStoredProc.CreateUser, // Execute the Query. For these tasks (all tasks below), we're using stored procedures
                    new
                    {
                        // Supply the Parameters required by the stored procedure
                        name = user.Name,
                        email = user.Email
                    },
                    // Specifying how the command is to be interpreted. (StoredProcedure for this one)
                    // (Can  be a hardcoded query as a string)
                    commandType: CommandType.StoredProcedure);
                // Get unique userId of the user as outputted by the storedProcedure
                // The unique userId was generated automatically by the table because of 'IDENTITY'
                user.Id = userId;
            }
            // For displaying purposes only. Data Management succeeded/failed after the query.
            return user;
        }

        // (Tasks below): Same logic as the documented function above (Can be used as reference.)
        public async Task<User> GetUserById(int id)
        {
            // For getting user based on Id
            using (var conn = GetConnection())
            {
                
                var user = await conn.QueryFirstOrDefaultAsync<User>(
                    UserStoredProc.GetUserById, // stored procedure
                    new
                    {
                        // parameters
                        id = id
                    },
                    commandType: CommandType.StoredProcedure);

                return user;
            }
        }

        public async Task<bool> UpdateUserById(int id, string name, string email)
        {
            // Updating a user's details based on Id.
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
                    commandType: CommandType.StoredProcedure);

                // Displays whether the query has succedded or not by checking whether there have been affected rows.
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