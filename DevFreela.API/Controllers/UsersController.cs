using DevFreela.Application.Commands.UserCommands.CreateUser;
using DevFreela.Application.Queries.UserQueries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);

            var user = await _mediator.Send(query);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserCommand createUser
        )
        {
            var id = await _mediator.Send(createUser);

            return CreatedAtAction(nameof(GetById), new { id }, createUser);
        }

    }
}

