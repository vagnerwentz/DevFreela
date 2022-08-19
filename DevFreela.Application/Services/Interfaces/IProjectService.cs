using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModel;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        void Start(int id);
        void Delete(int id);
        void Finish(int id);
        ProjectDetailsViewModel GetById(int id);
        List<ProjectViewModel> GetAll(string query);
        int Create(NewProjectInputModel inputModel);
        void Update(UpdateProjectInputModel inputModel);
        void CreateComment(CreateCommentInputModel inputModel);
        
    }
}

