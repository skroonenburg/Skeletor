using System;
using System.Collections.Generic;
using NHibernate;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class PermissionRepository: RepositoryBase<Permission,Guid>, IPermissionRepository
    {
        public PermissionRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        public IEnumerable<Permission> GetAllNonDeletedPermissions()
        {
            return SessionFactory.GetCurrentSession()
                                 .QueryOver<Permission>()
                                 .Where(x => !x.IsDeleted)
                                 .CacheMode(CacheMode.Normal)
                                 .CacheRegion("Permissions")
                                 .Cacheable()
                                 .Future();
        }
    }
}