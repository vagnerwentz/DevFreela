using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task DeleteProjectAsync();
        Task UpdateProjectAsync();
        Task FinishProjectaAsync();
        Task StartProjectAsync(Project project);
        Task CreateProjectAsync(Project project);
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
    }
}

