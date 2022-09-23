using System;
using DevFreela.Application.Queries.ProjectQueries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries.ProjectQueries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact(DisplayName = "Should return three project view model when three project exists.")]
        public async Task ThreeProjectsExists_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("DevFreela", "Descrição do projeto DevFreela", 12, 23, 5000),
                new Project("FindDev", "Descrição do projeto FindDev", 1, 5, 25000),
                new Project("SearchDev", "Descrição do projeto SearchDev", 2, 8, 30000)
            };

            var _projectRepositoryMock = new Mock<IProjectRepository>();
            _projectRepositoryMock.Setup(repository => repository.GetAllProjectsAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(_projectRepositoryMock.Object);

            // Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);
            _projectRepositoryMock.Verify(repositoryMock => repositoryMock.GetAllProjectsAsync().Result, Times.Once);
        }
    }
}

