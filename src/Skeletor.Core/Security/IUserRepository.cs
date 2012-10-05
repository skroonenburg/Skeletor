using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public interface IUserRepository : IRetrieveRepository<User,Guid>, IStoreRepository<User,Guid>
    {
        
    }
}