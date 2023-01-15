using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int clientId, int freelancerId, decimal totalCost)
        {
            Title = title;
            Description = description;
            ClientId = clientId;
            FreelancerId = freelancerId;
            TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public int ClientId { get; private set; }

        public User Client { get; set; }

        public int FreelancerId { get; private set; }

        public User Freelancer { get; set; }

        public decimal TotalCost { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? StartedAt { get; private set; }

        public DateTime? FinishedAt { get; private set; }

        public ProjectStatusEnum Status { get; private set; }

        public List<ProjectComment> Comments { get; private set; }

        public void CancelProject()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Created)
                Status = ProjectStatusEnum.Canceled;
        }

        public void FinishProject()
        {
            if (Status == ProjectStatusEnum.PaymentPending)
            {
                FinishedAt = DateTime.Now;
                Status = ProjectStatusEnum.Finished;
            }
                
        }

        public void StartProject()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                StartedAt = DateTime.Now;
                Status = ProjectStatusEnum.InProgress;
            }

        }

        public void UpdateProject(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public void SetPaymentPending()
        {
            Status = ProjectStatusEnum.PaymentPending;
            FinishedAt = null;
        }
    }
}

