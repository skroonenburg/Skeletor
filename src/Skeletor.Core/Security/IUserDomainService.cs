namespace Skeletor.Core.Security
{
    public interface IUserDomainService
    {
        bool UserNameInUse(string userName);
        bool UserNameInUse(User user);
    }
}