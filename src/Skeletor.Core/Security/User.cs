using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class User : Aggregate<Guid>, IActiveEntity, ISystemEntity
    {
        protected User() { }

        public User(Username username, Name name, Email emailAddress, Password password, LockedOut lockedOut)
        {

            Guard.Combine(ValidateUserName(username), ValidateName(name), ValidateEmail(emailAddress), ValidatePassword(password), ValidateLockedOut(lockedOut))
                 .EnforceInvariants()
                 .ThrowIfAny();

            Username = username;
            Name = name;
            EmailAddress = emailAddress;
            Password = password;
            LockedOut = lockedOut;
        }

        protected IGuard ValidateUserName(Username name)
        {
            return Guard.On(() => name != null, "Username is required");
        }

        protected IGuard ValidateName(Name name)
        {
            return Guard.On(() => name != null, "Name is required");
        }

        protected IGuard ValidateEmail(Email email)
        {
            return Guard.On(() => email != null, "Email is required");
        }

        protected IGuard ValidatePassword(Password password)
        {
            return Guard.On(() => password != null, "Password is required");
        }

        protected IGuard ValidateLockedOut(LockedOut lockedOut)
        {
            return Guard.On(() => lockedOut != null, "Lockedout is required");
        }

        public virtual Name Name { get; protected set; }
        public virtual Email EmailAddress { get; protected set; }
        public virtual Password Password { get; protected set; }
        public virtual LockedOut LockedOut { get; protected set; }
        public virtual bool IsActive { get; protected set; }
        public virtual bool IsSystem { get; protected set; }
        public virtual Username Username { get; protected set; }
    }
}