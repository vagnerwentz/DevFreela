using DevFreela.Application.Commands.ProjectCommands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators.ProjectValidator
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        private readonly int DESCRIPTION_MAXIUM_LENGTH = 255;
        private readonly int TITLE_MAXIUM_LENGTH = 30;

        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(DESCRIPTION_MAXIUM_LENGTH)
                .WithMessage($"O tamanho máximo da descrição é de {DESCRIPTION_MAXIUM_LENGTH} caracteres.");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage($"O tamanho máximo do título é de {TITLE_MAXIUM_LENGTH} caracteres.");
        }
    }
}

