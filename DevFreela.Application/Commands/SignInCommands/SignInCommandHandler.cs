using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.SignInCommands
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        
        public SignInCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<SignInViewModel> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSHA256Hash(request.Password);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user is null)
            {
                return null;
            }

            var token = _authService.GenerateJWTToken(user.Email, user.Role);

            return new SignInViewModel(user.Email, token);
        }
    }
}

