using System;

namespace Skeletor.Core.Framework
{
    public class Aggregate<TKey> : Entity<TKey>
    {
        protected Aggregate(){} 

        public Aggregate(TKey identity) : base(identity){}

        public virtual int RowVersion { get; private set; }
        public virtual DateTime CreatedOn { get; private set; }
        public virtual DateTime? ModifiedOn { get; private set; }
    }
}
