using NSubstitute;
using NUnit.Framework;
using Skeletor.Core.Framework;
using Skeletor.Core.Security;

namespace Skeletor.Core.UnitTests.As_a_site_administrator
{
    [TestFixture]
    public class when_creating_an_admin_user_account_more_than_once
    {

        private ICreateAdminUserAccountCommandHandler _handler;
        private IUserDomainService _domainService;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private const string username = "administrator";


        [SetUp]
        public void Setup()
        {
            _domainService = Substitute.For<IUserDomainService>();
            _roleRepository = Substitute.For<IRoleRepository>();
            _userRepository = Substitute.For<IUserRepository>();
            _handler = new CreateAdminUserAccountCommandHandler(_domainService, _userRepository,_roleRepository);
        }


        [Test]
        public void It_should_throw_an_error_if_this_process_has_been_run_before()
        {
            
            _domainService.UserNameInUse(username).Returns(true);
            Assert.Throws<NameInUseException>(() => _handler.Handle(GetValidCreateAdminUserAccountCommand()));

        }

        private static CreateAdminUserAccountCommand GetValidCreateAdminUserAccountCommand()
        {
            return new CreateAdminUserAccountCommand(username,"padget","rowell","padgett@hotmale.com","password1");
        }
    }
}