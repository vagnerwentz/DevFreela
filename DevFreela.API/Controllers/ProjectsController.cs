using DevFreela.Application.Commands.ProjectCommands.CreateComment;
using DevFreela.Application.Commands.ProjectCommands.CreateProject;
using DevFreela.Application.Commands.ProjectCommands.DeleteProject;
using DevFreela.Application.Commands.ProjectCommands.UpdateProject;
using DevFreela.Application.Queries.ProjectQueries.GetAllProjects;
using DevFreela.Application.Queries.ProjectQueries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create(
            [FromBody] CreateProjectCommand createProjectModel
        )
        {
            var id = await _mediator.Send(createProjectModel);

            return CreatedAtAction(
                nameof(GetById),
                new { id },
                createProjectModel
            );
        }

        [HttpPost("{id}/comments")]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> CreateComment(
            int id,
            [FromBody] CreateCommentCommand createCommentModel)
        {
            await _mediator.Send(createCommentModel);

            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null) return NotFound();

            return Ok(project);
        }

        

        [HttpPut("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateProjectCommand updateProjectCommand
        )
        {
            if (updateProjectCommand.Description.Length > 200) return BadRequest();

            await _mediator.Send(updateProjectCommand);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Cancel(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        

        [HttpPut("{id}/start")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Start(int id)
        {
            await _mediator.Send(id);
            
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Finish(int id)
        {
            await _mediator.Send(id);

            return NoContent();
        }
    }
}

