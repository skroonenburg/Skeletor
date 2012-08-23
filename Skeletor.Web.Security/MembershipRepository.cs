using System;
using NHibernate;
using Skeletor.Core.Framework;

namespace Skeletor.Web.Security
{
    public class MembershipRepository : RepositoryBase<Member,Guid>,  IMembershipRepository
    {
        public MembershipRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}