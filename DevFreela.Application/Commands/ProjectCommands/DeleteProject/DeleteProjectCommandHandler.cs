using MediatR;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.ProjectCommands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public DeleteProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(project => project.Id == request.Id);

            if (project == null)
            {
                throw new NotImplementedException();
            }

            project.CancelProject();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

