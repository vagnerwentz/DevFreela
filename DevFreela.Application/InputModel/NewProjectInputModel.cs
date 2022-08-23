namespace DevFreela.Application.InputModel
{
    public class NewProjectInputModel
    {
        public int ClientId { get; set; }
        public string Title { get; set; }
        public int FreelancerId { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}

