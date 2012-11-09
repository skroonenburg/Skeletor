using System;
using Iesi.Collections.Generic;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class Role : Aggregate<Guid>, IActiveEntity, IEquatable<Role>
    {
        protected Role() { }

        public Role(string roleName)
        {

            Guard.Combine(ValidateRoleName(roleName))
                 .EnforceInvariants()
                 .ThrowIfAny();

            Name = roleName;
        }

        protected virtual IGuard ValidateRoleName(string name)
        {
            return Guard.On(() => !string.IsNullOrEmpty(name), "Role name is required");
        }

        public void AssignPermission(Permission permission)
        {
            Guard.On(() => permission != null, "Unable to assign a non existent permission.").EnforceInvariants().ThrowIfAny();
            if (Permissions.Contains(permission)) return;
            Permissions.Add(permission);
        }

        public virtual bool Equals(Role other)
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
            return Equals((Role) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ Name.GetHashCode();
            }
        }

        public static bool operator ==(Role left, Role right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Role left, Role right)
        {
            return !Equals(left, right);
        }

        public virtual string Name { get; protected set; }
        public virtual bool IsActive { get; protected set; }
        public virtual ISet<Permission> Permissions { get; protected set; }
    }
}