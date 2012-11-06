namespace Skeletor.Core.Security
{
    public interface IUserDomainService
    {
        bool UserNameInUse(string userName);
        bool UserNameInUse(User user);
    }

    public class UserDomainService : IUserDomainService
    {

        private IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool UserNameInUse(string userName)
        {
            return _userRepository.UserNameInUse(userName);
        }

        public bool UserNameInUse(User user)
        {
            return _userRepository.UserNameInUse(user);
        }
    }

}