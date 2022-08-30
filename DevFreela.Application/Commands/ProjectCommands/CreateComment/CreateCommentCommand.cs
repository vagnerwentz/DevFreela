using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.CreateComment
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public string Content { get; set; }
    }
}

