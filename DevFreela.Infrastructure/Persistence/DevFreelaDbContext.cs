using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASP NET Core", "Projeto DevFreela", 1, 1, 10000),
                new Project("Meu projeto ASP NET Core 2", "Projeto DevFreela 2", 1, 1, 5240),
                new Project("Meu projeto ASP NET Core 3", "Projeto DevFreela 3", 1, 1, 37900)
            };

            User = new List<User>
            {
                new User("Vagner Wentz", "wentz.vagner@gmail.com", new DateTime(1998, 1, 1)),
                new User("Bruna Eloisa Wentz", "wentz.eloisa@gmail.com", new DateTime(1998, 1, 1)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("Apache Kafka"),
                new Skill("MongoDB"),
            };
        }

        public List<Project> Projects { get; set; }

        public List<User> User { get; set; }

        public List<Skill> Skills { get; set; }

        public List<ProjectComment> ProjectComments { get; set; }
    }
}

