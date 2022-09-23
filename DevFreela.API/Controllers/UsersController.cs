using DevFreela.Application.Commands.SignInCommands;
using DevFreela.Application.Commands.UserCommands.CreateUser;
using DevFreela.Application.Queries.UserQueries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
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

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(
            [FromBody] CreateUserCommand createUser
        )
        {
            try
            {
                var id = await _mediator.Send(createUser);

                return CreatedAtAction(nameof(GetById), new { id }, createUser);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand signInData)
        {
            var signInViewModel = await _mediator.Send(signInData);

            if (signInViewModel is null) return BadRequest();

            return Ok(signInViewModel);
            //"email": "vagner.wentz@gmail.com",
            //"password": "9XEb@123",
            //"role": "Client",
            //"email": "bruna.wentz@gmail.com",
            //"password": "9XEb@123",
            //"role": "Freelancer",
        }

    }
}

