using System;

namespace Skeletor.Core.Framework
{
    public abstract class Aggregate<TKey> : Entity<TKey>
    {
        protected Aggregate(){} 

        public virtual int RowVersion { get; private set; }
        public virtual DateTime CreatedOn { get; private set; }
        public virtual DateTime? ModifiedOn { get; private set; }
        public virtual Guid CreatedBy { get; private set; }
        public virtual Guid ModifiedBy { get; private set; }
    }
}
