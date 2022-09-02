using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;

        public SkillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreela");
        }


        public async Task<List<SkillDTO>> GetAllSkillsAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var query = "SELECT Id, Description FROM Skills";
                var skills = await sqlConnection.QueryAsync<SkillDTO>(query);

                return skills.ToList();
            }
        }
    }
}

