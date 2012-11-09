using System;

namespace Skeletor.Core.Framework
{
    public abstract class Aggregate<TKey> : Entity<TKey>, IAuditable
    {
        protected Aggregate(){} 

        protected void ChangeCreatedBy(Guid userId)
        {
            CreatedBy = userId;
        }

        protected void ChangeModifiedBy(Guid userId)
        {
            ModifiedBy = userId;
        }

        protected void ChangeModifiedOnUtc(DateTime dateTimeUtc)
        {
            ModifiedOnUtc = dateTimeUtc;
        }

        protected void ChangeCreatedOnUtc(DateTime dateTimeUtc)
        {
            CreatedOnUtc = dateTimeUtc;
        }

        public virtual int RowVersion { get; private set; }
        public virtual DateTime CreatedOnUtc { get; private set; }
        public virtual DateTime? ModifiedOnUtc { get; private set; }
        public virtual Guid CreatedBy { get; private set; }
        public virtual Guid? ModifiedBy { get; private set; }
    }
}
