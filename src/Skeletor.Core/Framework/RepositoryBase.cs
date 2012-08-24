using NHibernate;

namespace Skeletor.Core.Framework
{
    public class RepositoryBase<TAggregate, TKey> : IRetrieveRepository<TAggregate, TKey>, IStoreRepository<TAggregate, TKey> where TAggregate : Aggregate<TKey>
    {
        public RepositoryBase(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        public virtual TAggregate GetByIdentity(TKey identity)
        {
            return GetCurrentSession().Get<TAggregate>(identity);
        }

        public virtual TKey Store(TAggregate aggregate)
        {
            GetCurrentSession().SaveOrUpdate(aggregate);
            return aggregate.Identity;
        }

        protected virtual ISession GetCurrentSession()
        {
            return SessionFactory.GetCurrentSession();
        }

        public ISessionFactory SessionFactory { get; private set; }

    }
}