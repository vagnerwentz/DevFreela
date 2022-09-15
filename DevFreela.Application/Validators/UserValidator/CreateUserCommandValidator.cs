using System.Text.RegularExpressions;
using DevFreela.Application.Commands.UserCommands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators.UserValidator
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("É necessário informar um e-mail válido.");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("A senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma letra minúscula, e um caractere especial.");

            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome é obrigatório");
        }

        static bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}

