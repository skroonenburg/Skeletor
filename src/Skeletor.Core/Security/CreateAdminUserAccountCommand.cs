using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class CreateAdminUserAccountCommand : ICommand
    {

        public CreateAdminUserAccountCommand(){}


        public CreateAdminUserAccountCommand(string username, string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Username = username;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}