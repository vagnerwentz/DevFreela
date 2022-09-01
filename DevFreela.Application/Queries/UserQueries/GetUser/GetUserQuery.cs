using System;
using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Queries.UserQueries.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}

