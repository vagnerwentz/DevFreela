using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public ProjectRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreela");
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(project => project.Id == id);
        }


        public async Task CreateProjectAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task StartProjectAsync(Project project)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var query = "UPDATE Project SET Status = @status, StartedAt = @startedAt WHERE Id = @id";
                await sqlConnection.ExecuteAsync(query, new { status = project.Status, startedAt = project.StartedAt, project.Id });
            }
        }

        public async Task FinishProjectaAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

