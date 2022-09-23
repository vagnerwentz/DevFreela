using System;
using DevFreela.Application.Commands.ProjectCommands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;
namespace DevFreela.UnitTests.Application.Commands.ProjectCommands.CreateProject
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var _projectRepositoryMock = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Título",
                Description = "Descrição",
                ClientId = 1,
                FreelancerId = 2,
                TotalCost = 5000
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(_projectRepositoryMock.Object);

            // Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);

            _projectRepositoryMock.Verify(repository => repository.CreateProjectAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}

