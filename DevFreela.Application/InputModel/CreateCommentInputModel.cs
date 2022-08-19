using System;
namespace DevFreela.Application.InputModel
{
    public class CreateCommentInputModel
    {
        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public string Content { get; set; }

    }
}

