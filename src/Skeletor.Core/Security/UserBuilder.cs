using System;

namespace Skeletor.Core.Security
{
    public class UserBuilder 
    {
        public static UserBuilder Setup()
        {
            return new UserBuilder();
        }

        public UserBuilder SetUserName(string username)
        {
            UserName = username;
            return this;
        }

        public UserBuilder SetFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public UserBuilder SetLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public UserBuilder SetPassword(string password)
        {
            Password = password;
            return this;
        }

        public UserBuilder SetMinimumLength(int length)
        {
            MinimumLength = length;
            return this;
        }

        public UserBuilder SetMaximumLength(int length)
        {
            MaximumLength = length;
            return this;
        }

        public UserBuilder SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public UserBuilder SetExpiry(DateTime expiry)
        {
            Expiry = expiry;
            return this;
        }

        public User Build()
        {
            return new User(new Name(FirstName, LastName), new Email(Email), new Password(Password,MinimumLength,MaximumLength, Expiry), new LockedOut()   );
        }

        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public int MinimumLength { get; private set; }
        public int MaximumLength { get; private set; }
        public DateTime Expiry { get; private set; }
        
    }
}