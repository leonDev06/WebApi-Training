namespace Sidekick.Training.Providers.Sql.Models
{
    // This class stores the created Stored Procedures' names as a string.
    // These strings references the StoredProcedures in the SQL database.
    public class UserStoredProc
    {
        public const string GetUserById = "usp_GetUserById";
        public const string UpdateUserById = "usp_UpdateUserById";
        public const string DeleteUserById = "usp_DeleteUserById";
        public const string CreateUser = "usp_CreateUser";
    }
}
