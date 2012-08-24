namespace Skeletor.Core.Framework
{
    public interface IRetrieveRepository<TAggregate, TKey> where TAggregate : Aggregate<TKey>
    {
        TAggregate GetByIdentity(TKey identity);
    }
}