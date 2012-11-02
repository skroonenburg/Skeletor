using System;
using NHibernate;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class RoleRepository : RepositoryBase<Role,Guid>, IRoleRepository
    {
        public RoleRepository(ISessionFactory sessionFactory) : base(sessionFactory) {}

        public Role GetSystemAdministratorRole()
        {
            return SessionFactory.GetCurrentSession().QueryOver<Role>().Where(x => x.Name == "Administrator").SingleOrDefault();
        }
    }
}