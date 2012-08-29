namespace Skeletor.Core.Framework
{
    public static class UsabilityExtensions
    {
         public static TTarget As<TTarget>(this object @object)
         {
             return (TTarget) @object;
         }
    }
}