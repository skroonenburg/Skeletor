using System;

namespace Skeletor.Web.Security
{
    public class MembershipWriteService : IMembershipWriteService
    {
        public void SignIn(AuthenticationTicket ticket)
        {
            throw new NotImplementedException();
        }

        public void SignOut(AuthenticationTicket ticket)
        {
            throw new NotImplementedException();
        }

        public void CreateMember(Member member)
        {
            throw new NotImplementedException();
        }

        public void DeleteMember(Member member)
        {
            throw new NotImplementedException();
        }

        public void LockOutMember(Member member)
        {
            throw new NotImplementedException();
        }

        public void ExpireSession(Member member)
        {
            throw new NotImplementedException();
        }
    }
}