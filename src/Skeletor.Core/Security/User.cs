using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class User : Aggregate<Guid>, IActiveEntity, ISystemEntity
    {
        protected User() { }

        public User(Name name, Email emailAddress, Password password, LockedOut lockedOut)
        {
            Name = name;
            EmailAddress = emailAddress;
            Password = password;
            LockedOut = lockedOut;
        }

        public Name Name { get; protected set; }
        public Email EmailAddress { get; protected set; }
        public Password Password { get; protected set; }
        public LockedOut LockedOut { get; protected set; }
        public bool IsActive { get; protected set; }
        public bool IsSystem { get; protected set; }
    }
}