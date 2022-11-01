namespace Sidekick.Training.Model
{
    // This is the user model. This model is used to create and store data to and from the database to the user table.
    public class User
    {
        // USER PROPERTIES
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //END OF USER PROPERTIES


        // CONSTRUCTORS
        // Default Constructor
        public User()
        {

        }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
        //END OF CONSTRUCTORS
    }
}
