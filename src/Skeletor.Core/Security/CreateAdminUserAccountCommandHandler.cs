using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class CreateAdminUserAccountCommandHandler : ICreateAdminUserAccountCommandHandler
    {
        public CreateAdminUserAccountCommandHandler(IUserDomainService userDomainService, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userDomainService = userDomainService;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public object Handle(CreateAdminUserAccountCommand command)
        {
            if(userDomainService.UserNameInUse(command.Username))
                throw new NameInUseException();

            var user = UserBuilder.Setup()
                                     .SetUserName(command.Username)
                                     .SetFirstName(command.FirstName)
                                     .SetLastName(command.LastName)
                                     .SetPassword(command.Password)
                                     .SetEmail(command.Email)
                                     .SetMinimumLength(8)
                                     .SetMaximumLength(30)
                                     .SetExpiry(DateTime.Now.AddDays(90))
                                     .Build();

            

            user.PromoteToSystemAministrator(roleRepository.GetSystemAdministratorRole());

            return userRepository.Store(user);
        }

        private readonly IUserDomainService userDomainService;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
    }
}