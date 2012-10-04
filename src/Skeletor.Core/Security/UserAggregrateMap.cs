using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class UserAggregrateMap : AggregateRootMap<User, Guid>
    {
         public UserAggregrateMap() : base("UserId")
         {

             Component(x => x.Name, x =>
             {
                 x.Map(y => y.FirstName).Not.Nullable();
                 x.Map(y => y.LastName).Not.Nullable();
             });

             Component(x => x.Password, x =>
             {
                 x.Map(y => y.Salt).Column("PasswordSalt").Not.Nullable();
                 x.Map(y => y.Text).Column("Password").Not.Nullable();
                 x.Map(y => y.ExpiryDate).Column("PasswordExpiry").Not.Nullable();
             });

             Component(x => x.EmailAddress, x => x.Map(y => y.Address).Column("Email").Not.Nullable());

             Component(x => x.LockedOut, x =>
             {
                 x.Map(y => y.IsLockedOut).Column("IsLockedOut").Not.Nullable();
                 x.Map(y => y.LockedOutDate).Column("LockedOutDate").Nullable();
             });

             Map(y => y.IsActive).Not.Nullable();
             Map(y => y.IsSystem).Not.Nullable();
         }
    }
}