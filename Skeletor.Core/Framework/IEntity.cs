namespace Skeletor.Core.Framework
{
    public interface IEntity<out TKey>
    {
        TKey Identity { get; }
        bool IsDeleted { get; }
    }
}