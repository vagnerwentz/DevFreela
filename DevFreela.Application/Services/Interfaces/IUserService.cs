using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModel;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);
        int SignUp(CreateUserInputModel inputModel);
    }
}

