using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class RoleAggregrateMap : AggregateRootMap<Role, Guid>
    {
        public RoleAggregrateMap() : base("RoleId")
        {
            Map(y => y.Name).Not.Nullable();
            Map(y => y.IsActive).Not.Nullable();
            HasManyToMany(y => y.Permissions).AsSet().Cascade.AllDeleteOrphan().ParentKeyColumn("RoleId");
        }
    }
}