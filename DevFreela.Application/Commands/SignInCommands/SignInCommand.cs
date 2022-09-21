using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Commands.SignInCommands
{
    public class SignInCommand : IRequest<SignInViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

