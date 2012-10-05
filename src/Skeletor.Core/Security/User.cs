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

        public virtual Name Name { get; protected set; }
        public virtual Email EmailAddress { get; protected set; }
        public virtual Password Password { get; protected set; }
        public virtual LockedOut LockedOut { get; protected set; }
        public virtual bool IsActive { get; protected set; }
        public virtual bool IsSystem { get; protected set; }
    }
}