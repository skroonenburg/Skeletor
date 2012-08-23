using System;

namespace Skeletor.Web.Security
{
    public interface IMembershipRepository
    {
        Guid Store(Member member);
        Member GetByIdentity(Guid identity);
    }
}