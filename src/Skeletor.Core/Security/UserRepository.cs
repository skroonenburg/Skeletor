using System;
using NHibernate;
using Skeletor.Core.Framework;
using NHibernate.Linq;
using System.Linq;

namespace Skeletor.Core.Security
{
    public class UserRepository : RepositoryBase<User,Guid>, IUserRepository
    {
        public UserRepository(ISessionFactory sessionFactory) : base(sessionFactory) {}

        public bool UserNameInUse(string userName)
        {
            return  SessionFactory.GetCurrentSession().Query<User>().Select(x => x.Username.Name == userName).Any();
        }

        public bool UserNameInUse(User user)
        {
            return SessionFactory.GetCurrentSession().Query<User>().Where(x => x.Identity != user.Identity).Any(x => x.Username.Name == user.Username.Name);
        }
    }
}