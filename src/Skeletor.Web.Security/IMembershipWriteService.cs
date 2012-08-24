namespace Skeletor.Web.Security
{
    public interface IMembershipWriteService
    {
        void SignIn(AuthenticationTicket ticket);
        void SignOut(AuthenticationTicket ticket);
        void CreateMember(Member member);
        void DeleteMember(Member member);
        void LockOutMember(Member member);
        void ExpireSession(Member member);
    }
}
