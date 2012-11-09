using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class PermissionAggregrateMap : AggregateRootMap<Permission, Guid>
    {
        public PermissionAggregrateMap() : base("PermissionId")
        {
            Map(y => y.Name).Not.Nullable();
            Map(y => y.Description).Nullable();
        }
    }
}