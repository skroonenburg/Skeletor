using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class CreateUserCommand : ICommand
    {

        protected CreateUserCommand()
        {
        }

        public CreateUserCommand(string username, string firstName, string lastName, string email, string password)
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