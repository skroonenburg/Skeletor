using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public interface IRoleRepository : IRetrieveRepository<Role,Guid>, IStoreRepository<Role,Guid>
    {
        Role GetSystemAdministratorRole();
    }
}