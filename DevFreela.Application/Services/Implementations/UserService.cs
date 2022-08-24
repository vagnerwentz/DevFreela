using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        } 

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.User.SingleOrDefault(u => u.Id == id);

            if (user == null) return null;

            return new UserViewModel(user.FullName, user.Email);
        }

        public int SignUp(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.Birthdate);

            _dbContext.User.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }
    }
}

