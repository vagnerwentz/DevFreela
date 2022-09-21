using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task CreateUser(User user, CancellationToken cancellationToken);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task<bool> FindEmailAsync(string email);
    }
}

