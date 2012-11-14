using NSubstitute;
using NUnit.Framework;
using Skeletor.Core.Framework;
using Skeletor.Core.Security;

namespace Skeletor.Core.UnitTests.As_a_site_administrator
{
    [TestFixture]
    public class when_creating_an_admin_user_account_with_a_valid_command
    {

        private ICreateAdminUserAccountCommandHandler _handler;
        private IUserDomainService _domainService;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private const string username = "administrator";
        private Role _administrationRole ;

        [SetUp]
        public void Setup()
        {
            _domainService = Substitute.For<IUserDomainService>();
            _roleRepository = Substitute.For<IRoleRepository>();
            _userRepository = Substitute.For<IUserRepository>();
            _administrationRole = new Role("Admin");
            _handler = new CreateAdminUserAccountCommandHandler(_domainService, _userRepository, _roleRepository);
        }


        [Test]
        public void It_should_throw_an_error_if_this_process_has_been_run_before()
        {

            _domainService.UserNameInUse(username).Returns(false);
            _roleRepository.GetSystemAdministratorRole().Returns(_administrationRole);

            _handler.Handle(GetValidCreateAdminUserAccountCommand());
            _userRepository.Received(1).Store(Arg.Any<User>());

        }

        private static CreateAdminUserAccountCommand GetValidCreateAdminUserAccountCommand()
        {
            return new CreateAdminUserAccountCommand(username, "padget", "rowell", "padgett@hotmale.com", "password1");
        }

    }
}