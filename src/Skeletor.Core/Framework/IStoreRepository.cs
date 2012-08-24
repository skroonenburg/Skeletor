namespace Skeletor.Core.Framework
{
    public interface IStoreRepository<TAggregate, TKey> where TAggregate : Aggregate<TKey>
    {
        TKey Store(TAggregate aggregate);
    }
}