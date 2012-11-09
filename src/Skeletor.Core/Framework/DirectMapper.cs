using System.Reflection;

namespace Skeletor.Core.Framework
{
    public static class DirectMapper
    {
        public static TResult Map<TResult, TSource>(TSource input) where TResult : new()
        {
            var result = new TResult();

            CopyPropertiesFromSource(input, result);

            return result;
        }

        public static void Map<TResult, TSource>(TSource input, TResult result) where TResult : new()
        {
            CopyPropertiesFromSource(input, result);
        }

        private static void CopyPropertiesFromSource<TResult, TSource>(TSource input, TResult result) where TResult : new()
        {
            foreach (var property in typeof(TResult).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                Map(input, result, property);
            }
        }

        private static void Map<TResult, TSource>(TSource input, TResult result, PropertyInfo property) where TResult : new()
        {
            PropertyInfo propertyInfo = typeof(TSource).GetProperty(property.Name);
            if (propertyInfo == null)
                return;
            typeof(TResult).GetProperty(property.Name).GetSetMethod().Invoke(result,
                                                                              new[]
                                                                                  {
                                                                                      propertyInfo.GetValue(
                                                                                              input, new object[] {})
                                                                                  });
        }
    }

}