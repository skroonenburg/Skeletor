using System;
using Skeletor.Core.Framework;

namespace Skeletor.Core.Security
{
    public class CreateUserCommandHandler : ICreateUserCommandHandler
    {
        public CreateUserCommandHandler(IUserDomainService userDomainService, IUserRepository userRepository)
        {
            this.userDomainService = userDomainService;
            this.userRepository = userRepository;
        }

        public object Handle(CreateUserCommand command)
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

            return userRepository.Store(user);
        }

        private readonly IUserDomainService userDomainService;
        private readonly IUserRepository userRepository;
    }
}