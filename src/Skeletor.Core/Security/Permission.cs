using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class Permission : Aggregate<Guid>, IEquatable<Permission>
    {
        protected Permission() { }

        public Permission(string name, string description)
        {
            Guard.Combine(ValidatePermissionName(name), ValidatePermissionDescription(description))
                .EnforceInvariants()
                .ThrowIfAny();

            Name = name;
        }

        protected virtual IGuard ValidatePermissionName(string name)
        {
            return Guard.On(() => !string.IsNullOrEmpty(name) && name.Length > 100, "Permission name is required and must be 100 or less characters");
        }

        protected virtual IGuard ValidatePermissionDescription(string description)
        {
            return Guard.On(() => !string.IsNullOrEmpty(description) && description.Length > 1000, "Description must be 1000 or less characters");
        }

        public bool Equals(Permission other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Permission) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ Name.GetHashCode();
            }
        }

        public static bool operator ==(Permission left, Permission right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Permission left, Permission right)
        {
            return !Equals(left, right);
        }

        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
     
    }
}