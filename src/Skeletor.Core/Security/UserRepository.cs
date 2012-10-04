using System;
using NHibernate;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class UserRepository : RepositoryBase<User,Guid>, IUserRepository
    {
        public UserRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}