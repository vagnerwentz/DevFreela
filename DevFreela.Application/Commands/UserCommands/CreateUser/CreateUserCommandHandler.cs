using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Core.Exceptions;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var emailAlreadyExists = await _userRepository.FindEmailAsync(request.Email);

            if (emailAlreadyExists)
            {
                throw new EmailAlreadyExistsException();
            }

            var passwordHash = _authService.ComputeSHA256Hash(request.Password);

            var user = new User(request.FullName, request.Email, request.Birthdate, passwordHash, request.Role);

            await _userRepository.CreateUser(user, cancellationToken);

            return user.Id;
        }
    }
}

