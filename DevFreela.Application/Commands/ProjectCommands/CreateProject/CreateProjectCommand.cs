using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public int ClientId { get; set; }
        public string Title { get; set; }
        public int FreelancerId { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}

