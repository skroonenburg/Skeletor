using FluentNHibernate.Mapping;

namespace Skeletor.Core.Framework
{
    public class AggregateRootMap<TAggregrate, TKey> : ClassMap<TAggregrate> where TAggregrate : Aggregate<TKey>
    {
        public AggregateRootMap(string column)
        {
            Id(x => x.Identity).Column(column).GeneratedBy.GuidComb();
            Map(x => x.IsDeleted).Not.Nullable();
            Map(x => x.CreatedOnUtc).Column("CreatedUtcDate").Not.Nullable();
            Map(x => x.ModifiedOnUtc).Column("ModifiedUtcDate").Nullable();
            Map(x => x.CreatedBy).Column("CreatedByUserId").Not.Nullable();
            Map(x => x.ModifiedBy).Column("ModifiedByUserId").Nullable();
            Version(x => x.RowVersion).Not.Nullable();
        }
    }
}