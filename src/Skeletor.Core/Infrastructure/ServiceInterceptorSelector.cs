using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Infrastructure
{
    public class ServiceInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var results = new List<IInterceptor>();
            AddTransactionSupportIfRequired(results, method, interceptors);
            

            return results.ToArray();
        }

        private void AddTransactionSupportIfRequired(ICollection<IInterceptor> results, MethodInfo method, IEnumerable<IInterceptor> interceptors)
        {
            if (method.GetCustomAttributes(true).OfType<TransactionAttribute>().Any())
            {
                results.Add(interceptors.Single(x => x.GetType() == typeof (NHibernateTransactionInterceptor)));
            }
        }
    }
}