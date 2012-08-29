using System;
using System.Data;
using System.Linq;
using Castle.DynamicProxy;
using NHibernate;
using Skeletor.Core.Framework;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Skeletor.Core.Infrastructure
{
    public class NHibernateTransactionInterceptor : IInterceptor
    {
        public NHibernateTransactionInterceptor(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        public void Intercept(IInvocation invocation)
        {

            var transactionAttribute = invocation.MethodInvocationTarget.GetCustomAttributes(true).OfType<TransactionAttribute>().
                    FirstOrDefault().As<TransactionAttribute>();

            if (transactionAttribute == null)
                throw new MissingTransactionAttributeException(String.Format("Method: {0} is missing a transaction attribute which is required for transactions", invocation.MethodInvocationTarget.Name));

            using(var transaction = SessionFactory.GetCurrentSession().BeginTransaction(transactionAttribute.IsolationLevel))
            {
                invocation.Proceed();
                transaction.Commit();
            }
        }

        public ISessionFactory SessionFactory { get; private set; }
    }
}