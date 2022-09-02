using DevFreela.Core.DTOs;
using MediatR;

namespace DevFreela.Application.Queries.SkillQueries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillDTO>>
    {
        public GetAllSkillsQuery()
        {
        }
    }
}

