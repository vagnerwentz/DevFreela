using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Queries.SkillQueries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
        public GetAllSkillsQuery()
        {
        }
    }
}

