using System;
namespace DevFreela.Application.ViewModel
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string title, DateTime createdAt)
        {
            Title = title;
            CreatedAt = createdAt;
        }

        public string Title { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}

