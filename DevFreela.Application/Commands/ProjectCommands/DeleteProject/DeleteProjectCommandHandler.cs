using MediatR;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.ProjectCommands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectByIdAsync(request.Id);

            await _projectRepository.DeleteProjectAsync(project);

            return Unit.Value;
        }
    }
}

