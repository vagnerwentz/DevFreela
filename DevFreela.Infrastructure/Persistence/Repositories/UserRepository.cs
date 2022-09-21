using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext.User.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateUser(User user, CancellationToken cancellationToken)
        {
            await _dbContext.User.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.User.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }

        public async Task<bool> FindEmailAsync(string email)
        {
            var user = await _dbContext.User.SingleOrDefaultAsync(u => u.Email == email);

            if (user is null) return false;

            return true;
        }
    }
}

