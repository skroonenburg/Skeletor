using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class CreateAdminUserAccountCommand : ICommand
    {

        protected CreateAdminUserAccountCommand(){}


        public CreateAdminUserAccountCommand(string username, string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Username = username;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Username { get; private set; }
    }
}