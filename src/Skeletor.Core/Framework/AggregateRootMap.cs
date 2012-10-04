using FluentNHibernate.Mapping;

namespace Skeletor.Core.Framework
{
    public class AggregateRootMap<TAggregrate, TKey> : ClassMap<TAggregrate> where TAggregrate : Aggregate<TKey>
    {
        public AggregateRootMap(string column)
        {
            Id(x => x.Identity).Column(column).GeneratedBy.GuidComb();
            Map(x => x.IsDeleted).Not.Nullable();
            Map(x => x.CreatedOn).Not.Nullable();
            Map(x => x.ModifiedOn).Nullable();
            Map(x => x.CreatedBy).Not.Nullable();
            Map(x => x.ModifiedBy).Nullable();
            Version(x => x.RowVersion).Not.Nullable();
        }
    }
}