using System;
using System.Collections.Generic;

namespace Skeletor.Core.Framework
{
    public class Entity<TKey> : IEntity<TKey>, IEquatable<Entity<TKey>>
    {
       
        protected Entity(){} 

        protected Entity(TKey identity)
        {
            Identity = identity;
        }

        public virtual void Delete()
        {
            IsDeleted = true;
        }

        public virtual bool Equals(Entity<TKey> other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || EqualityComparer<TKey>.Default.Equals(Identity, other.Identity);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Entity<TKey>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TKey>.Default.GetHashCode(Identity);
        }

        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !Equals(left, right);
        }

        public virtual TKey Identity { get; private set; }
        public virtual bool IsDeleted { get; private set; }
    }
}