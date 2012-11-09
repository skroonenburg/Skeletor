using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public interface IPermissionRepository  : IRetrieveRepository<Permission,Guid>
    {
        IEnumerable<Permission> GetAllNonDeletedPermissions();
    }
}