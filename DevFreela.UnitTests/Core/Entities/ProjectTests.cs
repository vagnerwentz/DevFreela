using System;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;
namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        // Given When Then
        [Fact(DisplayName = "Project status should be equal Created when create a project.")]
        public void ProjectStatusShouldBeCreatedWhenCreateProject()
        {
            var project = new Project("DevFreela", "Descrição do projeto DevFreela", 1, 2, 50);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
        }

        [Fact(DisplayName = "Project status should be equal InProgress when StartProject is called.")]
        public void ProjectStatusShouldBeInProgressWhenStartProjectCalled()
        {
            var project = new Project("DevFreela", "Descrição do projeto DevFreela", 1, 2, 50);

            project.StartProject();

            Assert.NotNull(project.StartedAt);
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
        }

        [Fact(DisplayName = "Project status can not change when FinisihProject is called when the project status is not InProgress.")]
        public void ProjectStatusCanNotChangeToFinishedWhenStatusIsNotInProgress()
        {
            var project = new Project("DevFreela", "Descrição do projeto DevFreela", 1, 2, 50);

            project.FinishProject();

            Assert.NotEqual(ProjectStatusEnum.Finished, project.Status);
        }

        [Fact(DisplayName = "Project status should be Canceled when CancelProject is called when status is InProgress.")]
        public void ProjectStatusShouldBeCanceledWhenCancelProjectIsCalledWhenStatusIsInProgress()
        {
            var project = new Project("DevFreela", "Descrição do projeto DevFreela", 1, 2, 50);

            project.StartProject();
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);

            project.CancelProject();

            Assert.Equal(ProjectStatusEnum.Canceled, project.Status);
        }

        [Fact(DisplayName = "Project status should be Canceled when CancelProject is called when status is Created.")]
        public void ProjectStatusShouldBeCanceledWhenCancelProjectIsCalledWhenStatusIsCreated()
        {
            var project = new Project("DevFreela", "Descrição do projeto DevFreela", 1, 2, 50);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);

            project.CancelProject();

            Assert.Equal(ProjectStatusEnum.Canceled, project.Status);
        }

        [Fact(DisplayName = "Should be able to update the project.")]
        public void ShouldBeAbleToUpdateTheProject()
        {
            var project = new Project("DevFreela", "Descrição do projeto DevFreela", 1, 2, 50);

            project.UpdateProject("FindDev", "FindDev Descrição", 1000);

            Assert.Equal("FindDev", project.Title);
            Assert.Equal("FindDev Descrição", project.Description);
            Assert.Equal(1000, project.TotalCost);
        }
    }
}

