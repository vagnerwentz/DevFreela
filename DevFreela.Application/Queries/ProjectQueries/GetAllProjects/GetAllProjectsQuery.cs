﻿using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Queries.ProjectQueries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}

